namespace LeaveManagementBackend.DTOs.Admin
{
    public class EmployeesDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ManagerName { get; set; } = string.Empty;
    }
}
