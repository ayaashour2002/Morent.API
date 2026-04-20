namespace Morent.API.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;       // Sport, SUV, Sedan, Hatchback, MPV, Coupe
    public decimal PricePerDay { get; set; }
    public decimal DiscountedPrice { get; set; }       
    public string ImageUrl { get; set; } = string.Empty;
    public int Capacity { get; set; }                       // number of people
    public string Transmission { get; set; } = string.Empty; // Manual / Automatic
    public string FuelType { get; set; } = string.Empty;   // Gasoline / Electric / Diesel
    public int FuelCapacity { get; set; }                   // in Liters
    public bool IsFavorite { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string? Description { get; set; }
    public double Rating { get; set; }
    public int ReviewCount { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
}
