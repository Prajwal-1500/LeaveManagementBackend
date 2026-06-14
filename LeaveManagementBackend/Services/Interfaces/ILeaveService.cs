using LeaveManagementBackend.DTOs.Leave;

namespace LeaveManagementBackend.Services.Interfaces
{
    public interface ILeaveService
    {
        Task<MyLeaveRequestsDto> GetMyLeavesAsync(int userId);

        Task<bool> ApplyLeaveAsync(
            ApplyLeaveDto dto,
            int userId);

        Task<bool> CancelLeaveAsync(
            int leaveRequestId,
            int userId);

        Task<List<LeaveRequestDto>> GetRepoteesRequestsAsync(
            int managerId);

        Task<bool> RejectLeaveAsync(
            int leaveRequestId);

        Task<bool> ApproveLeaveAsync(
            int leaveRequestId);
    }
}
