using LeaveManagementBackend.Controllers;
using LeaveManagementBackend.DTOs.Leave;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace LeaveManagementBackend.Tests
{
    public class LeaveControllerTests
    {
        private readonly Mock<ILeaveService> _mockLeaveService;
        private readonly LeavesController _controller;

        public LeaveControllerTests()
        {
            _mockLeaveService = new Mock<ILeaveService>();
            
           
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "123")
            };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext
            {
                User = claimsPrincipal
            };

            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            _controller = new LeavesController(_mockLeaveService.Object)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task GetMyLeaves_ReturnsOk_WithMyLeaveRequests()
        {
            
            var expectedDto = new MyLeaveRequestsDto
            {
                LeaveBalances = new List<LeaveBalanceDto>(),
                Requests = new List<LeaveRequestDto>()
            };

            _mockLeaveService
                .Setup(s => s.GetMyLeavesAsync(123))
                .ReturnsAsync(expectedDto);

            var result = await _controller.GetMyLeaves();

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<MyLeaveRequestsDto>(okResult.Value);
            Assert.Same(expectedDto, returnedDto);
        }

        [Fact]
        public async Task ApplyLeave_ValidRequest_ReturnsOk()
        {
          
            var dto = new ApplyLeaveDto
            {
                LeaveTypeId = 1,
                StartDate = System.DateTime.Today,
                EndDate = System.DateTime.Today.AddDays(2),
                Reason = "Sick"
            };

            _mockLeaveService
                .Setup(s => s.ApplyLeaveAsync(dto, 123))
                .ReturnsAsync(true);

           
            var result = await _controller.ApplyLeave(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Leave request submitted.", okResult.Value);
        }

        [Fact]
        public async Task ApplyLeave_InvalidRequest_ReturnsBadRequest()
        {
           
            var dto = new ApplyLeaveDto();

            _mockLeaveService
                .Setup(s => s.ApplyLeaveAsync(dto, 123))
                .ReturnsAsync(false);

          
            var result = await _controller.ApplyLeave(dto);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid leave request.", badRequestResult.Value);
        }

        [Fact]
        public async Task CancelLeave_Success_ReturnsOk()
        {
            
            _mockLeaveService
                .Setup(s => s.CancelLeaveAsync(10, 123))
                .ReturnsAsync(true);

            
            var result = await _controller.CancelLeave(10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Leave cancelled successfully.", okResult.Value);
        }

        [Fact]
        public async Task CancelLeave_Failure_ReturnsBadRequest()
        {
           
            _mockLeaveService
                .Setup(s => s.CancelLeaveAsync(10, 123))
                .ReturnsAsync(false);

            
            var result = await _controller.CancelLeave(10);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetTeamRequests_ReturnsOk_WithTeamRequests()
        {
          
            var teamRequests = new List<LeaveRequestDto>
            {
                new LeaveRequestDto { Id = 1, EmployeeName = "Emp A", LeaveType = "Casual", StartDate = System.DateTime.Today, EndDate = System.DateTime.Today, Status = "Pending" }
            };

            _mockLeaveService
                .Setup(s => s.GetTeamRequestsAsync(123))
                .ReturnsAsync(teamRequests);

            
            var result = await _controller.GetTeamRequests();

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRequests = Assert.IsType<List<LeaveRequestDto>>(okResult.Value);
            Assert.Single(returnedRequests);
            Assert.Equal("Emp A", returnedRequests[0].EmployeeName);
        }

        [Fact]
        public async Task ApproveLeave_Success_ReturnsOk()
        {
            
            _mockLeaveService
                .Setup(s => s.ApproveLeaveAsync(10))
                .ReturnsAsync(true);

            
            var result = await _controller.ApproveLeave(10);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Leave approved successfully.", okResult.Value);
        }

        [Fact]
        public async Task ApproveLeave_Failure_ReturnsBadRequest()
        {
            
            _mockLeaveService
                .Setup(s => s.ApproveLeaveAsync(10))
                .ReturnsAsync(false);

            
            var result = await _controller.ApproveLeave(10);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unable to approve leave request.", badRequestResult.Value);
        }

        [Fact]
        public async Task RejectLeave_Success_ReturnsOk()
        {
            
            var dto = new RejectLeaveDto { Reason = "Reject reason" };
            _mockLeaveService
                .Setup(s => s.RejectLeaveAsync(10, "Reject reason"))
                .ReturnsAsync(true);

            
            var result = await _controller.RejectLeave(10, dto);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Leave rejected successfully.", okResult.Value);
        }

        [Fact]
        public async Task RejectLeave_Failure_ReturnsBadRequest()
        {
            
            var dto = new RejectLeaveDto { Reason = "Reject reason" };
            _mockLeaveService
                .Setup(s => s.RejectLeaveAsync(10, "Reject reason"))
                .ReturnsAsync(false);

            
            var result = await _controller.RejectLeave(10, dto);

            
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Unable to reject leave request.", badRequestResult.Value);
        }
    }
}
