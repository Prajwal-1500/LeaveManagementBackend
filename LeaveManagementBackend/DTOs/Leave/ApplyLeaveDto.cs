namespace LeaveManagementBackend.DTOs.Leave
{
    public class ApplyLeaveDto
    {
        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;
    }
}
