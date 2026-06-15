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
                    PasswordHash = "$2a$11$SFpxXxGU5fvbEplsiJHDBOXB1oBXK4AszGlq/NYgNssdax35QKScm",
                    Role = Role.HRAdmin
                },
                 new User
                 {
                     Id = 2,
                     FirstName = "Dhruv",
                     LastName = "Manager",
                     Email = "dhruv@tx.com",
                     PasswordHash = "$2a$11$KlyHJ58LYt64WwHmIJpc4uiZI1WjdJnlPuZY6tG3iM7JvfAdvXqVq",
                     Role = Role.Manager
                 },
                  new User
                  {
                      Id = 3,
                      FirstName = "Rajat",
                      LastName = "Emp",
                      Email = "rajat@tx.com",
                      PasswordHash = "$2a$11$zxd3qBptSGxmYSYxWAX12ezaF6U0NFhQUh04yzqKoFLZ7EBa/Xk4a",
                      Role = Role.Employee,
                      ManagerId = 2
                  },
                   new User
                   {
                       Id = 4,
                       FirstName = "Jasneet",
                       LastName = "Emp",
                       Email = "jasneet@tx.com",
                       PasswordHash = "$2a$11$LUn4hYzS/8KdNoO9/bgJZOaYIT6NNBYz4gmmbMXKN0vJDVZw3YreC",
                       Role = Role.Employee,
                       ManagerId = 2
                   },
                   new User
                   {
                       Id = 5,
                       FirstName = "Raghav",
                       LastName = "Emp",
                       Email = "raghav@tx.com",
                       PasswordHash = "$2a$11$jm.xcSXsIYMyEl02IwuhE.1/yOcTmEkriLZciVfTzQgrg7j6D2vnW",
                       Role = Role.Employee,
                       ManagerId = 2
                   },
                    new User
                    {
                        Id = 6,
                        FirstName = "Hardil",
                        LastName = "Emp",
                        Email = "hardil@tx.com",
                        PasswordHash = "$2a$11$20Lh2SMf2TOGRYzUWL6HDOOw0kj/ymH1YqLdm8RxB8FBP27sCTCsK",
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
                },

    
                new LeaveBalance
                {
                    Id = 4,
                    UserId = 2,
                    LeaveTypeId = 1,
                    BalanceDays = 20,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 5,
                    UserId = 2,
                    LeaveTypeId = 2,
                    BalanceDays = 10,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 6,
                    UserId = 2,
                    LeaveTypeId = 3,
                    BalanceDays = 15,
                    Year = 2026
                },

    
                new LeaveBalance
                {
                    Id = 7,
                    UserId = 4,
                    LeaveTypeId = 1,
                    BalanceDays = 20,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 8,
                    UserId = 4,
                    LeaveTypeId = 2,
                    BalanceDays = 10,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 9,
                    UserId = 4,
                    LeaveTypeId = 3,
                    BalanceDays = 15,
                    Year = 2026
                },

    
                new LeaveBalance
                {
                    Id = 10,
                    UserId = 5,
                    LeaveTypeId = 1,
                    BalanceDays = 20,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 11,
                    UserId = 5,
                    LeaveTypeId = 2,
                    BalanceDays = 10,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 12,
                    UserId = 5,
                    LeaveTypeId = 3,
                    BalanceDays = 15,
                    Year = 2026
                },

    
                new LeaveBalance
                {
                    Id = 13,
                    UserId = 6,
                    LeaveTypeId = 1,
                    BalanceDays = 20,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 14,
                    UserId = 6,
                    LeaveTypeId = 2,
                    BalanceDays = 10,
                    Year = 2026
                },
                new LeaveBalance
                {
                    Id = 15,
                    UserId = 6,
                    LeaveTypeId = 3,
                    BalanceDays = 15,
                    Year = 2026
                }
            );

        }
    }
}
