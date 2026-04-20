// Services/AdminService.cs
using Morent.API.Core.Interfaces;
using Morent.API.Data;
using Morent.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Morent.API.Services;

public class AdminService : IAdminService
{
    private readonly AppDbContext _db;
    public AdminService(AppDbContext db) => _db = db;

    public async Task<object> GetDashboardAsync(int userId)
    {
        var totalCars = await _db.Cars.CountAsync();
        var totalBookings = await _db.Bookings
            .CountAsync(b => b.UserId == userId);
        var activeBookings = await _db.Bookings
            .CountAsync(b => b.UserId == userId && b.Status == BookingStatus.Confirmed);
        var totalRevenue = await _db.Bookings
            .Where(b => b.UserId == userId && b.Status == BookingStatus.Confirmed)
            .SumAsync(b => (decimal?)b.TotalPrice) ?? 0;

        var recentTransactions = await _db.Bookings
            .Include(b => b.Car)
            .Where(b => b.UserId == userId)
            .OrderByDescending(b => b.Id)
            .Take(5)
            .Select(b => new
            {
                bookingNumber = b.BookingNumber,
                carName = b.Car.Name,
                carType = b.Car.Type,
                carImage = b.Car.ImageUrl,
                amount = b.TotalPrice,
                date = b.CreatedAt.ToString("yyyy-MM-dd"),
                pickupLocation = b.PickupLocation,
                dropoffLocation = b.DropoffLocation,
                pickupDate = b.PickupDate.ToString("yyyy-MM-dd"),
                dropoffDate = b.DropoffDate.ToString("yyyy-MM-dd"),
                pickupTime = b.PickupTime,
                dropoffTime = b.DropoffTime,
            })
            .ToListAsync();

        return new
        {
            totalCars,
            totalBookings,
            activeBookings,
            totalRevenue,
            recentTransactions
        };
    }

    public async Task<IEnumerable<object>> GetCarTypesStatsAsync(int userId)
    {
        return await _db.Bookings
            .Include(b => b.Car)
            .Where(b => b.UserId == userId &&
                       (b.Status == BookingStatus.Confirmed ||
                        b.Status == BookingStatus.Completed))
            .GroupBy(b => b.Car.Type)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .ToListAsync<object>();
    }
}