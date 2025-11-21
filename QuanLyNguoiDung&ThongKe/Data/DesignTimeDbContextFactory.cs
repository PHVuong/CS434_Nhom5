using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartMotoRental.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SmartMotoRentalContext>
{
    public SmartMotoRentalContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SmartMotoRentalContext>();
        optionsBuilder.UseSqlite("Data Source=smart_moto.db");
        return new SmartMotoRentalContext(optionsBuilder.Options);
    }
}


