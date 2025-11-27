using Microsoft.AspNetCore.Mvc;
using CS434_Nhom5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS434_Nhom5.Controllers
{
    public class RentalOrderController : Controller
    {
        // Giả lập Database (Static list để giữ dữ liệu khi reload)
        private static List<RentalOrder> _orders = new List<RentalOrder>
        {
            new RentalOrder { Id = 1, OrderCode = "DH1001", CustomerName = "Nguyễn Văn A", BikeModel = "Yamaha Sirius", PickupDate = new DateTime(2025, 7, 1, 9, 0, 0), ReturnDate = new DateTime(2025, 7, 3, 18, 0, 0), BranchRoute = "Hà Nội -> TP.HCM", TotalAmount = 550000, Status = "Pending" },
            new RentalOrder { Id = 2, OrderCode = "DH1002", CustomerName = "Trần Thị B", BikeModel = "Honda Vision", PickupDate = new DateTime(2025, 7, 2, 8, 0, 0), ReturnDate = new DateTime(2025, 7, 5, 10, 0, 0), BranchRoute = "Đà Nẵng", TotalAmount = 600000, Status = "Confirmed" }
        };

        // GET: /RentalOrder
        public IActionResult Index(string searchString, string statusFilter)
        {
            var orders = from o in _orders select o;

            // 1. Logic Tìm kiếm (Server-side)
            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(s => s.CustomerName.Contains(searchString) || s.OrderCode.Contains(searchString));
            }

            // 2. Logic Lọc Trạng thái (Server-side)
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "All")
            {
                orders = orders.Where(x => x.Status == statusFilter);
            }

            // Lưu lại giá trị tìm kiếm để hiển thị lại trên View
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentStatus = statusFilter;

            return View(orders.ToList());
        }

        // POST: /RentalOrder/Confirm/5
        // Dùng POST form thay vì AJAX
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null && order.Status == "Pending")
            {
                order.Status = "Confirmed";
            }
            // Reload lại trang Index
            return RedirectToAction(nameof(Index)); 
        }

        // POST: /RentalOrder/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancel(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order != null && order.Status == "Pending")
            {
                order.Status = "Cancelled";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}