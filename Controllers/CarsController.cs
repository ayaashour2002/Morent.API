using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morent.API.Core.DTOs;
using Morent.API.Core.Interfaces;
using Morent.API.Data;
using Morent.API.Models;

namespace Morent.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carSvc;
    public CarsController(ICarService carSvc) => _carSvc = carSvc;

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] CarFilterDto filter)
        => Ok(await _carSvc.GetAllAsync(filter));

    [HttpGet("popular")]
    public async Task<ActionResult> GetPopular()
        => Ok(await _carSvc.GetPopularAsync());

    [HttpGet("recommended")]
    public async Task<ActionResult> GetRecommended()
        => Ok(await _carSvc.GetRecommendedAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var car = await _carSvc.GetByIdAsync(id);
        return car == null ? NotFound() : Ok(car);
    }

    [HttpGet("{id}/reviews")]
    public async Task<ActionResult> GetReviews(int id)
        => Ok(await _carSvc.GetReviewsAsync(id));

    [HttpGet("{id}/related")]
    public async Task<ActionResult> GetRelated(int id)
        => Ok(await _carSvc.GetRelatedAsync(id));

    [HttpGet("types")]
    public async Task<ActionResult> GetTypes()
        => Ok(await _carSvc.GetTypesAsync());
}