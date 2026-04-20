namespace Morent.API.Core.DTOs;

public record CreateIntentDto(
    int CarId,
    DateTime PickupDate,
    DateTime DropoffDate,
    string CustomerName
);

public record ConfirmBookingDto(
    string PaymentIntentId,
    int CarId,
    string CustomerName,
    string PhoneNumber,
    string Address,
    string City,
    string PickupLocation,
    DateTime PickupDate,
    string PickupTime,
    string DropoffLocation,
    DateTime DropoffDate,
    string DropoffTime
);