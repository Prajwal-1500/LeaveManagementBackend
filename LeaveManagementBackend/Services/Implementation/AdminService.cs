using LeaveManagementBackend.DTOs.Admin;
using LeaveManagementBackend.Repository.Interfaces;
using LeaveManagementBackend.Services.Interfaces;

namespace LeaveManagementBackend.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;

        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<List<EmployeesDto>> GetEmployeesAsync()
        {
            var employees = await _adminRepo.GetEmployeesAsync();

            return employees.Select(e => new EmployeesDto
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.LastName,
                Email = e.Email,
                ManagerName = e.Manager == null
                    ? string.Empty
                    : e.Manager.FirstName + " " + e.Manager.LastName
            }).ToList();
        }
    }
}
