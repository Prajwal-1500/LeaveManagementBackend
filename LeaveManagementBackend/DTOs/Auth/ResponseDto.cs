namespace LeaveManagementBackend.DTOs.Auth
{
    public class ResponseDto
    {
        public int UserId { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
