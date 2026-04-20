using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Morent.API.Core.DTOs;
using Morent.API.Core.Interfaces;

namespace Morent.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authSvc;
        public AuthController(IAuthService authSvc) => _authSvc = authSvc;

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            try
            {
                var result = await _authSvc.RegisterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            try
            {
                var result = await _authSvc.LoginAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
