using LeaveManagementBackend.Data;
using LeaveManagementBackend.Models;
using LeaveManagementBackend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementBackend.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
