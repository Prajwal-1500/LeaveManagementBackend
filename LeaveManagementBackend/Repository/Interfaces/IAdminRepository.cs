using LeaveManagementBackend.Models;

namespace LeaveManagementBackend.Repository.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<User>> GetEmployeesAsync();
    }
}
