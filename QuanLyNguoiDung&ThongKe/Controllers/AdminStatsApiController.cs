using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Data;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace SmartMotoRental.Controllers
{
    [Route("admin/api/stats")]
    [ApiController]
    public class AdminStatsApiController : ControllerBase
    {
        private readonly SmartMotoRentalContext _db;
        public AdminStatsApiController(SmartMotoRentalContext db) { _db = db; }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersStats()
        {
            var total = await _db.Users.CountAsync();
            var from = DateTime.UtcNow.AddMonths(-5);
            var newUsers = await _db.Users
                .Where(u => u.CreatedAt >= from)
                .GroupBy(u => new { u.CreatedAt.Year, u.CreatedAt.Month })
                .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToListAsync();

            var dict = new Dictionary<string,int>();
            foreach(var item in newUsers) dict[$"{item.Year}-{item.Month:D2}"] = item.Count;

            return Ok(new { totalUsers = total, newUsersByMonth = dict });
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue()
        {
            var from = DateTime.UtcNow.AddMonths(-5);
            var q = await _db.Rentals
                .Where(r => r.CreatedAt >= from)
                .GroupBy(r => new { r.CreatedAt.Year, r.CreatedAt.Month })
                .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Revenue = g.Sum(x => x.TotalPrice) })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToListAsync();
            var dict = new Dictionary<string, decimal>();
            foreach(var item in q) dict[$"{item.Year}-{item.Month:D2}"] = item.Revenue;
            return Ok(dict);
        }

        [HttpGet("top-users")]
        public async Task<IActionResult> GetTopUsers([FromQuery]int limit = 10)
        {
            var q = await _db.Rentals
                .GroupBy(r => r.UserId)
                .Select(g => new { UserId = g.Key, TotalSpent = g.Sum(x => x.TotalPrice), Count = g.Count() })
                .OrderByDescending(x => x.TotalSpent)
                .Take(limit)
                .Join(_db.Users, r => r.UserId, u => u.UserId, (r,u) => new { u.UserId, u.FullName, r.TotalSpent, r.Count })
                .ToListAsync();

            var result = q.Select(x => new { userId = x.UserId, name = x.FullName, totalSpent = x.TotalSpent, totalRentals = x.Count });
            return Ok(result);
        }
    }
}
