using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Data;
using SmartMotoRental.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMotoRental.Controllers
{
    public class DatThueXeController : Controller
    {
        private readonly SmartMotoRentalContext _context;

        public DatThueXeController(SmartMotoRentalContext context)
        {
            _context = context;
        }

        // GET: /DatThueXe
        // Hiển thị form đặt thuê xe (giao diện DatThueXe.html của bạn chuyển sang Razor)
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // View: Views/DatThueXe/Index.cshtml
        }

        // POST: /DatThueXe
        // Nhận dữ liệu từ form đặt xe và lưu vào database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind(
            "CustomerName,PhoneNumber,PickupLocation,ReturnLocation,PickupDate,PickupTime,ReturnDate,ReturnTime"
        )] RentalOrder order)
        {
            // Kiểm tra dữ liệu hợp lệ
            if (!ModelState.IsValid)
            {
                // Nếu form nhập sai -> trả lại view kèm lỗi
                return View(order);
            }

            // Kiểm tra logic ngày giờ: ngày trả phải >= ngày nhận
            var pickupDateTime = order.PickupDate.Date + order.PickupTime;
            var returnDateTime = order.ReturnDate.Date + order.ReturnTime;

            if (returnDateTime <= pickupDateTime)
            {
                ModelState.AddModelError(string.Empty, "Thời gian trả xe phải sau thời gian nhận xe.");
                return View(order);
            }

            // Thiết lập trạng thái đơn
            order.Status = RentalStatus.Pending;
            order.CreatedAt = DateTime.Now;

            // Lưu vào database
            _context.RentalOrders.Add(order);
            await _context.SaveChangesAsync();

            // Chuyển sang trang xác nhận / cảm ơn
            return RedirectToAction(nameof(Confirm), new { id = order.Id });
        }

        // GET: /DatThueXe/Confirm/5
        // Trang xác nhận sau khi đặt xe thành công
        public async Task<IActionResult> Confirm(int id)
        {
            var order = await _context.RentalOrders
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            return View(order); // View: Views/DatThueXe/Confirm.cshtml
        }

        // (Tuỳ chọn) Admin xem danh sách các đơn đặt xe
        // GET: /DatThueXe/Manage
        public async Task<IActionResult> Manage()
        {
            var orders = await _context.RentalOrders
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return View(orders); // View: Views/DatThueXe/Manage.cshtml
        }
    }
}
