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
                    EmployeeName = r.User.FirstName + " " + r.User.LastName,
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

        public async Task<bool> ApplyLeaveAsync( ApplyLeaveDto dto, int userId)
        {
            if (dto.StartDate.Date < DateTime.Today)
            {
                return false;
            }

            if (dto.EndDate < dto.StartDate)
            {
                return false;
            }

            var hasOverlap = await _leaveRepo.HasOverlappingLeaveAsync(userId, dto.StartDate,dto.EndDate);

            if (hasOverlap)
            {
                return false;
            }

            var requestedDays = (dto.EndDate - dto.StartDate).Days + 1;
            var leaveBalance = await _leaveRepo.GetLeaveBalanceAsync(userId, dto.LeaveTypeId, dto.StartDate.Year);
            
            if (leaveBalance == null || leaveBalance.BalanceDays < requestedDays)
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

        public async Task<bool> CancelLeaveAsync(int leaveRequestId,  int userId)
        {
            var leaveRequest = await _leaveRepo
                .GetByIdAsync(leaveRequestId);

            if (leaveRequest == null)
            {
                return false;
            }

            if (leaveRequest.UserId != userId)
            {
                return false;
            }

            if (leaveRequest.Status != LeaveStatus.Pending)
            {
                return false;
            }

            leaveRequest.Status = LeaveStatus.Cancelled;

            await _leaveRepo.SaveChangesAsync();

            return true;
        }

        public async Task<List<LeaveRequestDto>> GetRepoteesRequestsAsync(int managerId)
        {
            var requests = await _leaveRepo.GetRepoteesRequestsAsync(managerId);

            return requests.Select(r => new LeaveRequestDto
            {
                Id = r.Id,
                EmployeeName = $"{r.User.FirstName} {r.User.LastName}",
                LeaveType = r.LeaveType.Name,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Reason = r.Reason,
                Status = r.Status.ToString()
            }).ToList();
        }

        public async Task<bool> ApproveLeaveAsync(int leaveRequestId)
        {
            var leaveRequest = await _leaveRepo
                .GetByIdAsync(leaveRequestId);

            if (leaveRequest == null)
            {
                return false;
            }

            if (leaveRequest.Status != LeaveStatus.Pending)
            {
                return false;
            }

            var leaveBalance = await _leaveRepo.GetLeaveBalanceAsync(
                leaveRequest.UserId,
                leaveRequest.LeaveTypeId,
                DateTime.Now.Year);

            if (leaveBalance == null)
            {
                return false;
            }

            var requestedDays =
                (leaveRequest.EndDate - leaveRequest.StartDate).Days + 1;

            if (leaveBalance.BalanceDays < requestedDays)
            {
                return false;
            }

            leaveBalance.BalanceDays -= requestedDays;

            leaveRequest.Status = LeaveStatus.Approved;

            await _leaveRepo.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectLeaveAsync(int leaveRequestId)
        {
            var leaveRequest = await _leaveRepo.GetByIdAsync(leaveRequestId);

            if (leaveRequest == null)
                return false;

            if (leaveRequest.Status != LeaveStatus.Pending)
                return false;

            leaveRequest.Status = LeaveStatus.Rejected;

            await _leaveRepo.SaveChangesAsync();

            return true;
        }


    }
}
