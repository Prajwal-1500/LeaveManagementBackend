using LeaveManagementBackend.DTOs.Leave;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LeaveManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeavesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyLeaves()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Unauthorized();
            }

            var userId = int.Parse(userIdClaim.Value);

            var result = await _leaveService.GetMyLeavesAsync(userId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyLeave(ApplyLeaveDto dto)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _leaveService
                .ApplyLeaveAsync(dto, userId);

            if (!result)
            {
                return BadRequest(
                    "Invalid leave request.");
            }

            return Ok("Leave request submitted successfully.");
        }
    }
}