// Services/BookingService.cs
using Microsoft.EntityFrameworkCore;
using Morent.API.Core.DTOs;
using Morent.API.Core.Interfaces;
using Morent.API.Data;
using Morent.API.Models;


namespace Morent.API.Services;

public class BookingService : IBookingService
{
    private readonly AppDbContext _db;
    public BookingService(AppDbContext db) => _db = db;

    public async Task<IEnumerable<BookingDto>> GetAllAsync()
    {
        return await _db.Bookings
            .Include(b => b.Car)
            .OrderByDescending(b => b.CreatedAt)
            .Select(b => ToDto(b))
            .ToListAsync();
    }

    public async Task<BookingDto?> GetByIdAsync(int id)
    {
        var b = await _db.Bookings
            .Include(b => b.Car)
            .FirstOrDefaultAsync(b => b.Id == id);
        return b == null ? null : ToDto(b);
    }

    public async Task<BookingDto> CreateAsync(BookingCreateDto dto, int userId)
    {
        var car = await _db.Cars.FindAsync(dto.CarId)
            ?? throw new Exception("Car not found");

        var days = (dto.DropoffDate - dto.PickupDate).Days;
        if (days <= 0) days = 1;

        var booking = new Booking
        {
            UserId = userId,
            BookingNumber = Guid.NewGuid().ToString("N")[..8].ToUpper(),
            CarId = dto.CarId,
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            City = dto.City,
            PickupLocation = dto.PickupLocation,
            PickupDate = dto.PickupDate,
            PickupTime = dto.PickupTime,
            DropoffLocation = dto.DropoffLocation,
            DropoffDate = dto.DropoffDate,
            DropoffTime = dto.DropoffTime,
            PaymentMethod = dto.PaymentMethod,
            CardHolder = dto.CardHolder,
            ExpirationDate = dto.ExpirationDate,
            TotalPrice = car.PricePerDay * days,
            Status = BookingStatus.Confirmed,
            CreatedAt = DateTime.UtcNow
        };

        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();
        await _db.Entry(booking).Reference(b => b.Car).LoadAsync();

        return ToDto(booking);
    }

    public async Task UpdateStatusAsync(int id, string status)
    {
        var booking = await _db.Bookings.FindAsync(id)
            ?? throw new Exception("Booking not found");

        if (Enum.TryParse<BookingStatus>(status, out var s))
            booking.Status = s;

        await _db.SaveChangesAsync();
    }

    public static BookingDto ToDto(Booking b) => new(
        b.Id, b.BookingNumber, b.CarId, b.Car.Name, b.Car.ImageUrl,
        b.CustomerName, b.PickupLocation, b.PickupDate,
        b.DropoffLocation, b.DropoffDate, b.TotalPrice,
        b.Status.ToString(), b.CreatedAt
    );
}