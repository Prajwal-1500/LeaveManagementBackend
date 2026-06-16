using LeaveManagementBackend.Enums;
namespace LeaveManagementBackend.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public LeaveStatus Status { get; set; }
        public string? RejectionReason { get; set; }

    }
}
