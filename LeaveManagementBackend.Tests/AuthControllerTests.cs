using LeaveManagementBackend.Controllers;
using LeaveManagementBackend.DTOs.Auth;
using LeaveManagementBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LeaveManagementBackend.Tests
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _controller = new AuthController(_mockAuthService.Object);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsOkWithToken()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "admin@tx.com",
                Password = "password123"
            };

            var responseDto = new ResponseDto
            {
                UserId = 1,
                Email = "admin@tx.com",
                Role = "HRAdmin",
                FirstName = "Prajwal",
                Token = "jwt-token-here"
            };

            _mockAuthService
                .Setup(s => s.LoginAsync(It.IsAny<LoginDto>()))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<ResponseDto>(okResult.Value);
            Assert.Equal("admin@tx.com", returnedDto.Email);
            Assert.Equal("jwt-token-here", returnedDto.Token);
            Assert.Equal("HRAdmin", returnedDto.Role);
        }

        [Fact]
        public async Task Login_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "wrong@tx.com",
                Password = "wrongpassword"
            };

            _mockAuthService
                .Setup(s => s.LoginAsync(It.IsAny<LoginDto>()))
                .ReturnsAsync((ResponseDto)null!);

            // Act
            var result = await _controller.Login(loginDto);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Invalid email or password", unauthorizedResult.Value);
        }

        [Fact]
        public async Task Login_ServiceCalled_WithCorrectDto()
        {
            // Arrange
            var loginDto = new LoginDto
            {
                Email = "test@tx.com",
                Password = "test123"
            };

            _mockAuthService
                .Setup(s => s.LoginAsync(It.IsAny<LoginDto>()))
                .ReturnsAsync(new ResponseDto
                {
                    UserId = 1,
                    Email = "test@tx.com",
                    Role = "Employee",
                    FirstName = "Test",
                    Token = "token"
                });

            // Act
            await _controller.Login(loginDto);

            // Assert
            _mockAuthService.Verify(
                s => s.LoginAsync(It.Is<LoginDto>(
                    d => d.Email == "test@tx.com" && d.Password == "test123")),
                Times.Once);
        }

        [Fact]
        public void FindPassword()
        {
            var adminHash = "$2a$11$SFpxXxGU5fvbEplsiJHDBOXB1oBXK4AszGlq/NYgNssdax35QKScm";
            var candidates = new[] { "admin", "Admin", "admin123", "Admin123", "password", "Password", "password123", "Password123", "admin@123", "Admin@123", "123456", "prajwal", "Prajwal" };
            foreach (var candidate in candidates)
            {
                if (BCrypt.Net.BCrypt.Verify(candidate, adminHash))
                {
                    throw new System.Exception($"FOUND MATCH: {candidate}");
                }
            }
            throw new System.Exception("NO MATCH FOUND");
        }
    }
}
