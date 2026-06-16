using LeaveManagementBackend.Models;
namespace LeaveManagementBackend.Repository.Interfaces
{
    public interface ILeaveRepository
    {
        Task<List<LeaveRequest>> GetByUserIdAsync(int userId);
        Task<LeaveRequest?> GetByIdAsync(int leaveRequestId);
        Task AddAsync(LeaveRequest leaveRequest);

        Task<List<LeaveRequest>> GetTeamRequestsAsync(int managerId);

        Task<LeaveBalance?> GetLeaveBalanceAsync(
            int userId,
            int leaveTypeId,
            int year);

        Task<List<LeaveBalance>> GetBalancesByUserIdAsync(int userId);

        Task<bool> HasOverlappingLeaveAsync(
            int userId,
            DateTime startDate,
            DateTime endDate
        );

        Task SaveChangesAsync();

    }
}
