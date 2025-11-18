using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Data; 
using SmartMotoRental.Models;
using System.Threading.Tasks;


namespace SmartMotoRental.Controllers;

public class MotorbikeController : Controller
{
    // Khởi tạo context để lấy dữ liệu từ database
    private readonly SmartMotoRentalContext _context;

    //Constructor để khởi tạo context
    public MotorbikeController(SmartMotoRentalContext context)
    {
        _context = context; 
    }

    // Action Index để hiển thị danh sách tất cả các motorbike
    public async Task<IActionResult> Index()
    {
        var allMotorbikes = await _context.Motorbikes
            .Where(m => m.Status == MotorbikeStatus.Available)
            .OrderByDescending(m => m.Year)
            .ThenBy(m => m.Name)
            .ToListAsync();
        return View(allMotorbikes);
    }

    // Action Details để hiển thị chi tiết của một motorbike
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var motorbike = await _context.Motorbikes.FirstOrDefaultAsync(m => m.BikeId == id);
        if (motorbike == null)
            return NotFound();
        return View(motorbike);
    }
    
}