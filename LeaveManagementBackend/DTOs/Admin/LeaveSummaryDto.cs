namespace LeaveManagementBackend.DTOs.Admin
{
    public class LeaveSummaryDto
    {

        public string EmployeeName { get; set; } = string.Empty;
        public int TotalRequests { get; set; }

        public int PendingLeaves { get; set; }

        public int ApprovedLeaves { get; set; }

        public int RejectedLeaves { get; set; }
        public int CancelledLeaves { get; set; }
    }
}
