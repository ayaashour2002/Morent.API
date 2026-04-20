namespace Morent.API.Core.DTOs;

public record CarDto(
    int Id, string Name, string Type,
    decimal PricePerDay, decimal DiscountedPrice,
    string ImageUrl, int Capacity, string Transmission,
    string FuelType, int FuelCapacity, bool IsFavorite,
    bool IsAvailable, double Rating, int ReviewCount, string? Description
);

public record CarFilterDto(
    string? Type,
    int? MinCapacity,
    int? MaxCapacity,
    decimal? MaxPrice,
    bool? IsAvailable,
    string? Search,
    DateTime? PickupDate,
    DateTime? DropoffDate
);

public record BookingCreateDto(
    int CarId,
    string CustomerName, string PhoneNumber, string Address, string City,
    string PickupLocation, DateTime PickupDate, string PickupTime,
    string DropoffLocation, DateTime DropoffDate, string DropoffTime,
    string PaymentMethod, string? CardNumber, string? CardHolder, string? ExpirationDate
);

public record BookingDto(
    int Id, string BookingNumber, int CarId, string CarName, string CarImage,
    string CustomerName, string PickupLocation, DateTime PickupDate,
    string DropoffLocation, DateTime DropoffDate, decimal TotalPrice,
    string Status, DateTime CreatedAt
);

public record ReviewDto(
    int Id, string ReviewerName, string ReviewerTitle,
    string ReviewerAvatar, string Comment, int Rating, DateTime CreatedAt
);

public record DashboardStatsDto(
    int TotalCars, int TotalBookings, int ActiveBookings,
    decimal TotalRevenue, List<RecentTransactionDto> RecentTransactions
);

public record RecentTransactionDto(
    string BookingNumber, string CarName, string CarImage,
    string CarType, decimal Amount, DateTime Date
);