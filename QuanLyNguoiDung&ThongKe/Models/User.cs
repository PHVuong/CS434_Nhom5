using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SmartMotoRental.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Customer;

    public bool IsLocked { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<ReviewRating> Reviews { get; set; } = new List<ReviewRating>();
    public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
    public ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
    public ICollection<ChatLog> ChatLogs { get; set; } = new List<ChatLog>();
}


