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
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminSvc;
    public AdminController(IAdminService adminSvc) => _adminSvc = adminSvc;

    [HttpGet("dashboard")]
    public async Task<ActionResult> GetDashboard()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        return Ok(await _adminSvc.GetDashboardAsync(userId));
    }

    [HttpGet("car-types-stats")]
    public async Task<ActionResult> GetCarTypesStats()
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        return Ok(await _adminSvc.GetCarTypesStatsAsync(userId));
    }
}
