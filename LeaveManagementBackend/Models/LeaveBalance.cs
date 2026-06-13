namespace LeaveManagementBackend.Models
{
    public class LeaveBalance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public decimal BalanceDays { get; set; }
        public int Year { get; set; }

    }
}
