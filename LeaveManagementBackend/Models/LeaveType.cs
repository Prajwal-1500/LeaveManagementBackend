namespace LeaveManagementBackend.Models
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
        = new List<LeaveRequest>();
        public ICollection<LeaveBalance> LeaveBalance { get; set; }
        = new List<LeaveBalance>();

    }
}
