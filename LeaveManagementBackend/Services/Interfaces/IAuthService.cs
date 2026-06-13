using LeaveManagementBackend.DTOs.Auth;

namespace LeaveManagementBackend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginDto loginDto);
    }
}
