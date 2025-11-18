using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartMotoRental.Models;

[Index(nameof(PlateNumber), IsUnique = true)]
public class Motorbike
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BikeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Type { get; set; }

    [MaxLength(50)]
    public string? Brand { get; set; }

    public int? Year { get; set; }

    [Required]
    [MaxLength(30)]
    public string? PlateNumber { get; set; }

    public MotorbikeCondition Condition { get; set; } = MotorbikeCondition.Good;

    public MotorbikeStatus Status { get; set; } = MotorbikeStatus.Available;

    [Column(TypeName = "decimal(12,2)")]
    public decimal? PricePerHour { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    public decimal? PricePerDay { get; set; }

    [MaxLength(150)]
    public string? Location { get; set; }

    public string? Description { get; set; }

    [MaxLength(255)]
    public string? ImageUrl { get; set; }

    // Navigation
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public ICollection<ReviewRating> Reviews { get; set; } = new List<ReviewRating>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    public ICollection<BikeImage> Images { get; set; } = new List<BikeImage>();
}


