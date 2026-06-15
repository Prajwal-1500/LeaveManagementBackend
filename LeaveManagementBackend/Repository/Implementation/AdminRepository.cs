using LeaveManagementBackend.Enums;
using LeaveManagementBackend.Models;
using LeaveManagementBackend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeaveManagementBackend.Repository.Interfaces;



namespace LeaveManagementBackend.Repository.Implementation
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetEmployeesAsync()
        {
            return await _context.Users
                .Include(u => u.Manager)
                .Where(u =>
                    u.Role == Role.Employee ||
                    u.Role == Role.Manager)
                .ToListAsync();
         }
    }
}
