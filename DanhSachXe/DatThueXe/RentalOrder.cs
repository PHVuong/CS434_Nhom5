using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMotoRental.Models
{
    public enum RentalStatus
    {
        Pending = 0,     // Chờ xác nhận
        Confirmed = 1,   // Đã xác nhận
        Cancelled = 2    // Đã huỷ
    }

    public class RentalOrder
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string PickupLocation { get; set; } = string.Empty;      // Địa điểm nhận xe

        [Required, StringLength(200)]
        public string ReturnLocation { get; set; } = string.Empty;      // Địa điểm trả xe

        [Required]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }                        // Ngày nhận

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan PickupTime { get; set; }                        // Giờ nhận

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }                        // Ngày trả

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan ReturnTime { get; set; }                        // Giờ trả

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public RentalStatus Status { get; set; } = RentalStatus.Pending;
    }
}
