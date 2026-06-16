using System.ComponentModel.DataAnnotations;

namespace LeaveManagementBackend.DTOs.Leave
{
    public class RejectLeaveDto
    {
        [Required]
        public string Reason { get; set; } = string.Empty;
    }
}
