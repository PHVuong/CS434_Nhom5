using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMotoRental.Models;

public class Rental
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentalId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey(nameof(Motorbike))]
    public int BikeId { get; set; }
    public Motorbike? Motorbike { get; set; }

    public DateTime? PickupTime { get; set; }
    public DateTime? ReturnTime { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    public decimal? TotalPrice { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }
    public DateTime? PaymentPaidAt { get; set; }

    public RentalStatus Status { get; set; } = RentalStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


