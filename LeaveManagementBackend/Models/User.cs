using LeaveManagementBackend.Enums;
namespace LeaveManagementBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public Role Role { get; set; }
        public int? ManagerId { get; set; }
        public User? Manager { get; set; }
        public ICollection<User> Reportees { get; set; } = new List<User>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
       = new List<LeaveRequest>();
        public ICollection<LeaveBalance> LeaveBalance { get; set; }
            = new List<LeaveBalance>();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

