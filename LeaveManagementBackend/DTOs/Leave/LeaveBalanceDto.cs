namespace LeaveManagementBackend.DTOs.Leave
{
    public class LeaveBalanceDto
    {
        public string LeaveType { get; set; } = string.Empty;

        public decimal BalanceDays { get; set; }

        public int Year { get; set; }
    }
}
