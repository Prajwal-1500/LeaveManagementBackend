using LeaveManagementBackend.DTOs.Auth;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(result);
        }
    }
}
