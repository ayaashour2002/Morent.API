namespace Morent.API.Models;

public class Booking
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public int? UserId { get; set; }
    public User? User { get; set; }

    // Billing Info
    public string CustomerName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    // Rental Info
    public string PickupLocation { get; set; } = string.Empty;
    public DateTime PickupDate { get; set; }
    public string PickupTime { get; set; } = string.Empty;
    public string DropoffLocation { get; set; } = string.Empty;
    public DateTime DropoffDate { get; set; }
    public string DropoffTime { get; set; } = string.Empty;

    // Payment
    public string PaymentMethod { get; set; } = "CreditCard"; // CreditCard, PayPal, Bitcoin
    public string? CardNumber { get; set; }
    public string? CardHolder { get; set; }
    public string? ExpirationDate { get; set; }

    public decimal TotalPrice { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string BookingNumber { get; set; } = Guid.NewGuid().ToString("N")[..8].ToUpper();
}

public enum BookingStatus { Pending, Confirmed, Cancelled, Completed }

public class Review
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public string ReviewerName { get; set; } = string.Empty;
    public string ReviewerTitle { get; set; } = string.Empty;
    public string ReviewerAvatar { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
