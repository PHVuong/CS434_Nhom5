using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMotoRental.Models;

public class ReviewRating
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReviewId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey(nameof(Motorbike))]
    public int BikeId { get; set; }
    public Motorbike? Motorbike { get; set; }

    [Range(1, 5)]
    public byte Rating { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    public string? Body { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


