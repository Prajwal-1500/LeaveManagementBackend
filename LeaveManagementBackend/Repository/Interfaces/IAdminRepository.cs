using LeaveManagementBackend.Models;

namespace LeaveManagementBackend.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<User>> GetEmployeesAsync();
        Task<List<LeaveRequest>> GetMonthlyLeaveRequestsAsync(int month, int year);
    }
}
