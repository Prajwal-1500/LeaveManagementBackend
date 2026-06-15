using LeaveManagementBackend.DTOs.Admin;
using LeaveManagementBackend.Enums;
using LeaveManagementBackend.Repository.Interfaces;
using LeaveManagementBackend.Services.Interfaces;

namespace LeaveManagementBackend.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;

        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<List<EmployeesDto>> GetEmployeesAsync()
        {
            var employees = await _adminRepo.GetEmployeesAsync();

            return employees.Select(e => new EmployeesDto
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.LastName,
                Email = e.Email,
                ManagerName = e.Manager == null
                    ? string.Empty
                    : e.Manager.FirstName + " " + e.Manager.LastName
            }).ToList();
        }

        public async Task<List<LeaveSummaryDto>> GetMonthlySummaryAsync(
    int month,
    int year)
        {
            var requests = await _adminRepo
                .GetMonthlyLeaveRequestsAsync(month, year);

            var summary = requests
                .GroupBy(r => r.User.FirstName + " " + r.User.LastName)
                .Select(group => new LeaveSummaryDto
                {
                    EmployeeName = group.Key,

                    TotalRequests = group.Count(),

                    PendingLeaves = group.Count(r =>
                        r.Status == LeaveStatus.Pending),

                    ApprovedLeaves = group.Count(r =>
                        r.Status == LeaveStatus.Approved),

                    RejectedLeaves = group.Count(r =>
                        r.Status == LeaveStatus.Rejected),

                    CancelledLeaves = group.Count(r =>
                        r.Status == LeaveStatus.Cancelled)
                })
                .ToList();

            return summary;
        }
    }
}
