using LeaveManagementBackend.Models;

namespace LeaveManagementBackend.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
