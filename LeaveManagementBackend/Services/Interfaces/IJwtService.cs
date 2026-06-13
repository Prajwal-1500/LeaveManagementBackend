using LeaveManagementBackend.Models;

namespace LeaveManagementBackend.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
