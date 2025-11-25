using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Models;

namespace SmartMotoRental.Data
{
    public class SmartMotoRentalContext : DbContext
    {
        public SmartMotoRentalContext(DbContextOptions<SmartMotoRentalContext> options)
            : base(options)
        {
        }

        public DbSet<Motorbike> Motorbikes { get; set; }

        // 👉 Thêm dòng này cho chức năng Đặt Thuê Xe
        public DbSet<RentalOrder> RentalOrders { get; set; }
    }
}
