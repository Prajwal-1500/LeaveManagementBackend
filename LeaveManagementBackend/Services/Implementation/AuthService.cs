using LeaveManagementBackend.Data;
using LeaveManagementBackend.DTOs.Auth;
using LeaveManagementBackend.Repository.Interfaces;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementBackend.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository repo,
            IJwtService jwtService)
        {
            _repo = repo;
            _jwtService = jwtService;
        }

        public async Task<ResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _repo.GetByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

            if (!isPasswordValid)
                return null;

            var token = _jwtService.GenerateToken(user);

            return new ResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role.ToString(),
                FirstName = user.FirstName,
                Token = token
            };
        }
    }
}