using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementBackend.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(Roles = "HRAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _service.GetEmployeesAsync();

            return Ok(employees);
        }
    }
}
