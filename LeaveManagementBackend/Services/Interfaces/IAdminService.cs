using LeaveManagementBackend.DTOs.Admin;

namespace LeaveManagementBackend.Services.Interfaces
{
    public interface IAdminService
    {
        Task<List<EmployeesDto>> GetEmployeesAsync();
        Task<List<LeaveSummaryDto>> GetMonthlySummaryAsync(int month, int year);
    }
}
