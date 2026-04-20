// Services/CarService.cs
using Microsoft.EntityFrameworkCore;
using Morent.API.Core.DTOs;
using Morent.API.Core.Interfaces;
using Morent.API.Data;
using Morent.API.Core.DTOs;
using Morent.API.Models;

namespace Morent.API.Services;

public class CarService : ICarService
{
    private readonly AppDbContext _db;
    public CarService(AppDbContext db) => _db = db;

    public async Task<IEnumerable<CarDto>> GetAllAsync(CarFilterDto filter)
    {
        var query = _db.Cars.AsQueryable();

        if (filter.PickupDate.HasValue && filter.DropoffDate.HasValue)
        {
            var bookedCarIds = await _db.Bookings
                .Where(b => b.Status == BookingStatus.Confirmed
                    && b.PickupDate < filter.DropoffDate.Value
                    && b.DropoffDate > filter.PickupDate.Value)
                .Select(b => b.CarId)
                .ToListAsync();

            query = query.Where(c => !bookedCarIds.Contains(c.Id));
        }

        if (!string.IsNullOrEmpty(filter.Search))
            query = query.Where(c =>
                c.Name.Contains(filter.Search) ||
                c.Type.Contains(filter.Search));

        if (!string.IsNullOrEmpty(filter.Type))
            query = query.Where(c => c.Type == filter.Type);

        if (filter.MinCapacity.HasValue)
            query = query.Where(c => c.Capacity >= filter.MinCapacity);

        if (filter.MaxCapacity.HasValue)
            query = query.Where(c => c.Capacity <= filter.MaxCapacity);

        if (filter.MaxPrice.HasValue)
            query = query.Where(c => c.DiscountedPrice <= filter.MaxPrice);

        return await query.Select(c => ToDto(c)).ToListAsync();
    }

    public async Task<CarDto?> GetByIdAsync(int id)
    {
        var car = await _db.Cars.FindAsync(id);
        return car == null ? null : ToDto(car);
    }

    public async Task<IEnumerable<CarDto>> GetPopularAsync()
    {
        var cars = await _db.Cars
            .OrderByDescending(c => c.ReviewCount)
            .Take(4)
            .ToListAsync();
        return cars.Select(c => ToDto(c));
    }

    public async Task<IEnumerable<CarDto>> GetRecommendedAsync()
    {
        var cars = await _db.Cars
            .OrderBy(c => c.DiscountedPrice)
            .Take(8)
            .ToListAsync();
        return cars.Select(c => ToDto(c));
    }

    public async Task<IEnumerable<ReviewDto>> GetReviewsAsync(int id)
    {
        return await _db.Reviews
            .Where(r => r.CarId == id)
            .Select(r => new ReviewDto(
                r.Id, r.ReviewerName, r.ReviewerTitle,
                r.ReviewerAvatar, r.Comment, r.Rating, r.CreatedAt))
            .ToListAsync();
    }

    public async Task<IEnumerable<CarDto>> GetRelatedAsync(int id)
    {
        var car = await _db.Cars.FindAsync(id);
        if (car == null) return Enumerable.Empty<CarDto>();

        return await _db.Cars
            .Where(c => c.Id != id && c.Type == car.Type)
            .Take(4)
            .Select(c => ToDto(c))
            .ToListAsync();
    }

    public async Task<IEnumerable<object>> GetTypesAsync()
    {
        return await _db.Cars
            .GroupBy(c => c.Type)
            .Select(g => new { Type = g.Key, Count = g.Count() })
            .ToListAsync<object>();
    }

    public static CarDto ToDto(Car c) => new(
        c.Id, c.Name, c.Type, c.PricePerDay, c.DiscountedPrice,
        c.ImageUrl, c.Capacity, c.Transmission, c.FuelType,
        c.FuelCapacity, c.IsFavorite, c.IsAvailable,
        c.Rating, c.ReviewCount, c.Description
    );
}