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
            var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

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

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelLeave(int id)
        {
            var userId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _leaveService
                .CancelLeaveAsync(id, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok("Leave cancelled successfully.");
        }

        [HttpGet("repotees")]
        public async Task<IActionResult> GetRepoteesRequests()
        {
            var managerId = int.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _leaveService
                .GetRepoteesRequestsAsync(managerId);

            return Ok(result);
        }

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            var result = await _leaveService
                .ApproveLeaveAsync(id);

            if (!result)
            {
                return BadRequest(
                    "Unable to approve leave request.");
            }

            return Ok("Leave approved successfully.");
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            var result = await _leaveService
                .RejectLeaveAsync(id);

            if (!result)
            {
                return BadRequest(
                    "Unable to reject leave request.");
            }

            return Ok("Leave rejected successfully.");
        }
    }
}