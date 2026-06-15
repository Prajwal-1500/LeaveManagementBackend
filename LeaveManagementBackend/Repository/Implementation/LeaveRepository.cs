using LeaveManagementBackend.Data;
using LeaveManagementBackend.Enums;
using LeaveManagementBackend.Models;
using LeaveManagementBackend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementBackend.Repositories.Implementation
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LeaveRequest>> GetByUserIdAsync(int userId)
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .Include(l => l.LeaveType)
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int leaveRequestId)
        {
            return await _context.LeaveRequests
                .Include(l => l.LeaveType)
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == leaveRequestId);
        }

        public async Task AddAsync(LeaveRequest leaveRequest)
        {
            await _context.LeaveRequests.AddAsync(leaveRequest);
        }

        public async Task<List<LeaveRequest>> GetRepoteesRequestsAsync(int managerId)
        {
            return await _context.LeaveRequests
                .Include(l => l.User)
                .Include(l => l.LeaveType)
                .Where(l => l.User.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<LeaveBalance?> GetLeaveBalanceAsync(
            int userId,
            int leaveTypeId,
            int year)
        {
            return await _context.LeaveBalances
                .FirstOrDefaultAsync(lb =>
                    lb.UserId == userId &&
                    lb.LeaveTypeId == leaveTypeId &&
                    lb.Year == year);
        }

        public async Task<List<LeaveBalance>> GetBalancesByUserIdAsync(int userId)
        {
            return await _context.LeaveBalances
                .Include(lb => lb.LeaveType)
                .Where(lb => lb.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> HasOverlappingLeaveAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _context.LeaveRequests.AnyAsync(l =>
                 l.UserId == userId &&
                 l.Status != LeaveStatus.Cancelled &&
                 l.Status != LeaveStatus.Rejected &&
                 startDate <= l.EndDate &&
                 endDate >= l.StartDate
             );
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}