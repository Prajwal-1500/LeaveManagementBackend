using LeaveManagementBackend.DTOs.Leave;
using LeaveManagementBackend.Enums;
using LeaveManagementBackend.Models;
using LeaveManagementBackend.Repository.Interfaces;
using LeaveManagementBackend.Services.Interfaces;

namespace LeaveManagementBackend.Services.Implementation
{
    public class LeaveService : ILeaveService
    {
        private readonly ILeaveRepository _leaveRepo;

        public LeaveService(ILeaveRepository leaveRepo)
        {
            _leaveRepo = leaveRepo;
        }

        public async Task<MyLeaveRequestsDto> GetMyLeavesAsync(int userId)
        {
            var requests = await _leaveRepo
                .GetByUserIdAsync(userId);

            var balances = await _leaveRepo
                .GetBalancesByUserIdAsync(userId);

            return new MyLeaveRequestsDto
            {
                Requests = requests.Select(r => new LeaveRequestDto
                {
                    Id = r.Id,
                    LeaveType = r.LeaveType.Name,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate,
                    Reason = r.Reason,
                    Status = r.Status.ToString()
                }).ToList(),

                LeaveBalances = balances.Select(b => new LeaveBalanceDto
                {
                    LeaveType = b.LeaveType.Name,
                    BalanceDays = b.BalanceDays,
                    Year = b.Year
                }).ToList()
            };
        }

        public async Task<bool> ApplyLeaveAsync(
    ApplyLeaveDto dto,
    int userId)
        {
            if (dto.StartDate.Date < DateTime.Today)
            {
                return false;
            }

            if (dto.EndDate < dto.StartDate)
            {
                return false;
            }

            var hasOverlap = await _leaveRepo.HasOverlappingLeaveAsync(
                userId,
                dto.StartDate,
                dto.EndDate);

            if (hasOverlap)
            {
                return false;
            }

            var leaveRequest = new LeaveRequest
            {
                UserId = userId,
                LeaveTypeId = dto.LeaveTypeId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = LeaveStatus.Pending
            };

            await _leaveRepo.AddAsync(leaveRequest);

            await _leaveRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelLeaveAsync(
            int leaveRequestId,
            int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaveRequestDto>> GetRepoteesRequestsAsync(
            int managerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ApproveLeaveAsync(
            int leaveRequestId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RejectLeaveAsync(
            int leaveRequestId)
        {
            throw new NotImplementedException();
        }


    }
}
