using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMotoRental.Models;

public class BikeImage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ImageId { get; set; }

    [ForeignKey(nameof(Motorbike))]
    public int BikeId { get; set; }
    public Motorbike? Motorbike { get; set; }

    [Required]
    [MaxLength(255)]
    public string ImageUrl { get; set; } = string.Empty;

    public bool IsMain { get; set; } = false;

    public int? SortOrder { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


