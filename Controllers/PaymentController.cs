using Microsoft.AspNetCore.Mvc;
using Morent.API.Core.DTOs;
using Morent.API.Data;
using Stripe;
using System.Security.Claims;

namespace Morent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _config;

    public PaymentController(AppDbContext db, IConfiguration config)
    {
        _db = db;
        _config = config;
    }

    [HttpPost("create-intent")]
    public async Task<ActionResult> CreateIntent([FromBody] CreateIntentDto dto)
    {
        try
        {
            var car = await _db.Cars.FindAsync(dto.CarId);
            if (car == null) return NotFound("Car not found");

            var days = (dto.DropoffDate - dto.PickupDate).Days;
            if (days <= 0) days = 1;

            var amount = (long)(car.DiscountedPrice * days * 100);

            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "usd",
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options);

            return Ok(new
            {
                clientSecret = intent.ClientSecret,
                amount = amount / 100,
                publishableKey = _config["Stripe:PublishableKey"]
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message + " | " + ex.InnerException?.Message);
        }
    }
    [HttpPost("confirm-booking")]
    public async Task<ActionResult> ConfirmBooking([FromBody] ConfirmBookingDto dto)
    {
        var service = new PaymentIntentService();
        var intent = await service.GetAsync(dto.PaymentIntentId);
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        if (intent.Status != "succeeded")
            return BadRequest("Payment not completed");

        var car = await _db.Cars.FindAsync(dto.CarId);
        if (car == null) return NotFound();

        var days = (dto.DropoffDate - dto.PickupDate).Days;
        var total = car.DiscountedPrice * days;

        var booking = new Models.Booking
        {
            UserId = userId,
            CarId = dto.CarId,
            CustomerName = dto.CustomerName,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            City = dto.City,
            PickupLocation = dto.PickupLocation,
            PickupDate = dto.PickupDate,
            PickupTime = dto.PickupTime,
            DropoffLocation = dto.DropoffLocation,
            CreatedAt = DateTime.UtcNow,
            DropoffDate = dto.DropoffDate,
            DropoffTime = dto.DropoffTime,
            PaymentMethod = "CreditCard",
            TotalPrice = total,
            Status = Models.BookingStatus.Confirmed,
            BookingNumber = Guid.NewGuid().ToString("N")[..8].ToUpper()
        };

        car.IsAvailable = false;
        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();

        return Ok(new { bookingNumber = booking.BookingNumber });
    }
}