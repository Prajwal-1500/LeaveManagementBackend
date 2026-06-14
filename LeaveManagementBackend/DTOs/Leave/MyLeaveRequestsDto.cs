namespace LeaveManagementBackend.DTOs.Leave
{
    public class MyLeaveRequestsDto
    {
        public List<LeaveRequestDto> Requests { get; set; }
        = new();

        public List<LeaveBalanceDto> LeaveBalances { get; set; }
       = new();
    }
}
