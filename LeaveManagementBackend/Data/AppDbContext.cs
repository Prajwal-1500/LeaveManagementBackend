using LeaveManagementBackend.Enums;
using LeaveManagementBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace LeaveManagementBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(uo => uo.Manager)
                .WithMany(uo => uo.Reportees)
                .HasForeignKey(uo => uo.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveBalance>()
               .HasOne(lb => lb.LeaveType)
               .WithMany(lto => lto.LeaveBalance)
               .HasForeignKey(lbo => lbo.LeaveTypeId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lro => lro.LeaveType)
                .WithMany(lto => lto.LeaveRequests)
                .HasForeignKey(lro => lro.LeaveTypeId);

            modelBuilder.Entity<LeaveRequest>()
               .HasOne(lro => lro.User)
               .WithMany(uo => uo.LeaveRequests)
               .HasForeignKey(lro => lro.UserId);

            modelBuilder.Entity<LeaveBalance>()
               .HasOne(lbo => lbo.User)
               .WithMany(uo => uo.LeaveBalance)
               .HasForeignKey(lbo => lbo.UserId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Prajwal",
                    LastName = "Admin",
                    Email = "admin@tx.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123"),
                    Role = Role.HRAdmin
                },
                 new User
                 {
                     Id = 2,
                     FirstName = "Dhruv",
                     LastName = "Manager",
                     Email = "dhruv@tx.com",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("Dhruv123"),
                     Role = Role.Manager
                 },
                  new User
                  {
                      Id = 3,
                      FirstName = "Rajat",
                      LastName = "Emp",
                      Email = "rajat@tx.com",
                      PasswordHash = BCrypt.Net.BCrypt.HashPassword("Rajat123"),
                      Role = Role.Employee,
                      ManagerId = 2
                  }
            );


            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType
                {
                    Id = 1,
                    Name = "Annual Leave"
                },
                new LeaveType
                {
                    Id = 2,
                    Name = "Unpaid Leave"
                },
                new LeaveType
                {
                    Id = 3,
                    Name = "Sick Leave"
                }
            );

            modelBuilder.Entity<LeaveBalance>().HasData(

                new LeaveBalance
                {
                    Id = 1,
                    UserId = 3, 
                    LeaveTypeId = 1, 
                    BalanceDays = 20,
                    Year = 2026
                },

                new LeaveBalance
                {
                    Id = 2,
                    UserId = 3,
                    LeaveTypeId = 2, 
                    BalanceDays = 10,
                    Year = 2026
                },

                new LeaveBalance
                {
                    Id = 3,
                    UserId = 3,
                    LeaveTypeId = 3, 
                    BalanceDays = 15,
                    Year = 2026
                }
            );
        }
    }
}
