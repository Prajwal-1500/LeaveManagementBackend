using Microsoft.EntityFrameworkCore;
using LeaveManagementBackend.Models;
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

        }
    }
}
