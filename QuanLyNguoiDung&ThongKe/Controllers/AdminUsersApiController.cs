using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Data;
using SmartMotoRental.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace SmartMotoRental.Controllers
{
    [Route("admin/api/users")]
    [ApiController]
    public class AdminUsersApiController : ControllerBase
    {
        private readonly SmartMotoRentalContext _db;
        public AdminUsersApiController(SmartMotoRentalContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]int page=1,[FromQuery]int pageSize=20,[FromQuery]string role=null,[FromQuery]bool? isLocked=null,[FromQuery]string q=null)
        {
            var query = _db.Users.AsQueryable();
            if (!string.IsNullOrEmpty(role) && Enum.TryParse<UserRole>(role, out var parsedRole)) query = query.Where(u => u.Role == parsedRole);
            if (isLocked.HasValue) query = query.Where(u => u.IsLocked == isLocked.Value);
            if (!string.IsNullOrEmpty(q)) query = query.Where(u => u.FullName.Contains(q) || u.Email.Contains(q));

            var total = await query.CountAsync();
            var items = await query.OrderByDescending(u => u.CreatedAt)
                .Skip((page-1)*pageSize).Take(pageSize)
                .Select(u => new {
                    id = u.UserId,
                    fullName = u.FullName,
                    email = u.Email,
                    role = u.Role.ToString(),
                    isLocked = u.IsLocked,
                    createdAt = u.CreatedAt
                }).ToListAsync();

            return Ok(new { items, total });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _db.Users.Include(u => u.Rentals).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null) return NotFound();
            var totalRentals = user.Rentals?.Count ?? 0;
            var totalSpent = user.Rentals?.Sum(r => r.TotalPrice) ?? 0;
            return Ok(new { user = new {
                id = user.UserId,
                fullName = user.FullName,
                email = user.Email,
                role = user.Role.ToString(),
                isLocked = user.IsLocked,
                createdAt = user.CreatedAt
            }, totalRentals, totalSpent });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password)) return BadRequest("Email/Password required");
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email)) return BadRequest("Email exists");
            var u = new User {
                FullName = dto.Name ?? dto.Email,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role != null && Enum.TryParse<UserRole>(dto.Role, out var r) ? r : UserRole.Customer
            };
            _db.Users.Add(u);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = u.UserId }, new { id = u.UserId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto dto)
        {
            var u = await _db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (u == null) return NotFound();
            u.FullName = dto.Name ?? u.FullName;
            if (dto.Role != null && Enum.TryParse<UserRole>(dto.Role, out var r)) u.Role = r;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}/lock")]
        public async Task<IActionResult> LockUser(int id, [FromBody] LockDto body)
        {
            var u = await _db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (u == null) return NotFound();
            u.IsLocked = body.IsLocked;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var u = await _db.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (u == null) return NotFound();
            _db.Users.Remove(u);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

    public class CreateUserDto { public string Name {get;set;} public string Email {get;set;} public string Password {get;set;} public string Role {get;set;} }
    public class UpdateUserDto { public string Name {get;set;} public string Role {get;set;} }
    public class LockDto { public bool IsLocked { get; set; } }
}
