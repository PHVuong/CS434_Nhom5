using Microsoft.EntityFrameworkCore;
using SmartMotoRental.Models;

namespace SmartMotoRental.Data;

public class SmartMotoRentalContext : DbContext
{
    public SmartMotoRentalContext(DbContextOptions<SmartMotoRentalContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Motorbike> Motorbikes => Set<Motorbike>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<ReviewRating> ReviewsRatings => Set<ReviewRating>();
    public DbSet<Suggestion> Suggestions => Set<Suggestion>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<ChatLog> ChatLogs => Set<ChatLog>();
    public DbSet<BikeImage> BikeImages => Set<BikeImage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Favorites: composite primary key
        modelBuilder.Entity<Favorite>()
            .HasKey(f => new { f.UserId, f.BikeId });

        // Relationships
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.User)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Motorbike)
            .WithMany(b => b.Rentals)
            .HasForeignKey(r => r.BikeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Motorbike)
            .WithMany(b => b.Favorites)
            .HasForeignKey(f => f.BikeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReviewRating>()
            .HasOne(rr => rr.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(rr => rr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ReviewRating>()
            .HasOne(rr => rr.Motorbike)
            .WithMany(b => b.Reviews)
            .HasForeignKey(rr => rr.BikeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Suggestion>()
            .HasOne(s => s.User)
            .WithMany(u => u.Suggestions)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Suggestion>()
            .HasOne(s => s.Motorbike)
            .WithMany(b => b.Suggestions)
            .HasForeignKey(s => s.BikeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany(u => u.Notifications)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ChatLog>()
            .HasOne(c => c.User)
            .WithMany(u => u.ChatLogs)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BikeImage>()
            .HasOne(i => i.Motorbike)
            .WithMany(b => b.Images)
            .HasForeignKey(i => i.BikeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Decimal precision (ensures consistency even if provider ignores Column attribute)
        modelBuilder.Entity<Rental>()
            .Property(r => r.TotalPrice)
            .HasColumnType("decimal(12,2)");

        modelBuilder.Entity<Motorbike>()
            .Property(b => b.PricePerHour)
            .HasColumnType("decimal(12,2)");

        modelBuilder.Entity<Motorbike>()
            .Property(b => b.PricePerDay)
            .HasColumnType("decimal(12,2)");
    }
}


