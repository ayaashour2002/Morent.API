using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morent.API.Core.DTOs;
using Morent.API.Core.Interfaces;
using Morent.API.Data;
using Morent.API.Models;
using System.Security.Claims;
namespace Morent.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingSvc;
    public BookingsController(IBookingService bookingSvc) => _bookingSvc = bookingSvc;

    [HttpGet]
    public async Task<ActionResult> GetAll()
        => Ok(await _bookingSvc.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var booking = await _bookingSvc.GetByIdAsync(id);
        return booking == null ? NotFound() : Ok(booking);
    }


    [HttpPost]
    public async Task<ActionResult> Create(BookingCreateDto dto)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var booking = await _bookingSvc.CreateAsync(dto, userId);
        return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
    {
        await _bookingSvc.UpdateStatusAsync(id, status);
        return NoContent();
    }
}