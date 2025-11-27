using System;

namespace CS434_Nhom5.Models
{
    public class RentalOrder
    {
        public int Id { get; set; }
        public string OrderCode { get; set; } // Mã đơn
        public string CustomerName { get; set; } // Khách hàng
        public string BikeModel { get; set; } // Xe
        public DateTime PickupDate { get; set; } // Nhận xe
        public DateTime ReturnDate { get; set; } // Trả xe
        public string BranchRoute { get; set; } // Chi nhánh
        public decimal TotalAmount { get; set; } // Tổng tiền
        public string Status { get; set; } // "Pending", "Confirmed", "Cancelled"
    }
}