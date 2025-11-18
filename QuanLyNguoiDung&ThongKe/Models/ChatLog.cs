using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMotoRental.Models;

public class ChatLog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ChatId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }

    public ChatSender Sender { get; set; } = ChatSender.User;

    public string? Message { get; set; }

    public string? Response { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


