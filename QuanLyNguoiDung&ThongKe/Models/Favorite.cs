using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMotoRental.Models;

public class Favorite
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey(nameof(Motorbike))]
    public int BikeId { get; set; }
    public Motorbike? Motorbike { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


