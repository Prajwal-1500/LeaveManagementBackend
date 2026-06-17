using LeaveManagementBackend.Controllers;
using LeaveManagementBackend.DTOs.Admin;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace LeaveManagementBackend.Tests
{
    public class AdminControllerTests
    {
        private readonly Mock<IAdminService> _mockAdminService;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _mockAdminService = new Mock<IAdminService>();
            _controller = new AdminController(_mockAdminService.Object);
        }

        [Fact]
        public async Task GetEmployees_ReturnsOk_WithEmployeesList()
        {
            
            var employees = new List<EmployeesDto>
            {
                new EmployeesDto { Id = 1, FullName = "John Doe", Email = "john@example.com", ManagerName = "Manager Joe" },
                new EmployeesDto { Id = 2, FullName = "Jane Smith", Email = "jane@example.com", ManagerName = "Admin Prajwal" }
            };

            _mockAdminService
                .Setup(s => s.GetEmployeesAsync())
                .ReturnsAsync(employees);

            
            var result = await _controller.GetEmployees();

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEmployees = Assert.IsType<List<EmployeesDto>>(okResult.Value);
            Assert.Equal(2, returnedEmployees.Count);
            Assert.Equal("John Doe", returnedEmployees[0].FullName);
        }

        [Fact]
        public async Task GetMonthlySummary_ReturnsOk_WithSummaryList()
        {
            
            var summary = new List<LeaveSummaryDto>
            {
                new LeaveSummaryDto { EmployeeName = "John Doe", TotalRequests = 3, PendingLeaves = 1, ApprovedLeaves = 1, RejectedLeaves = 1, CancelledLeaves = 0 },
                new LeaveSummaryDto { EmployeeName = "Jane Smith", TotalRequests = 2, PendingLeaves = 0, ApprovedLeaves = 2, RejectedLeaves = 0, CancelledLeaves = 0 }
            };

            _mockAdminService
                .Setup(s => s.GetMonthlySummaryAsync(6, 2026))
                .ReturnsAsync(summary);

            
            var result = await _controller.GetMonthlySummary(6, 2026);

           
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSummary = Assert.IsType<List<LeaveSummaryDto>>(okResult.Value);
            Assert.Equal(2, returnedSummary.Count);
            Assert.Equal("John Doe", returnedSummary[0].EmployeeName);
        }
    }
}
