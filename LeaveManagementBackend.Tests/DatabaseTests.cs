using LeaveManagementBackend.Data;
using LeaveManagementBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace LeaveManagementBackend.Tests
{
    public class DatabaseTests
    {
        private readonly ITestOutputHelper _output;

        public DatabaseTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task TestRealDatabaseQueries()
        {
            var connectionString = "server=localhost;port=3306;database=LeaveManagementDb;user=root;password=PrajwalCode#15;";
            
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using var context = new AppDbContext(optionsBuilder.Options);

            try
            {
                await context.Database.ExecuteSqlRawAsync("DELETE FROM __EFMigrationsHistory WHERE MigrationId = '20260616094525_rejReason'");
            }
            catch { }

            await context.Database.MigrateAsync();

            _output.WriteLine("=== TESTING USERS ===");
            try
            {
                var users = await context.Users.ToListAsync();
                _output.WriteLine($"Successfully loaded {users.Count} users.");
                foreach (var u in users)
                {
                    _output.WriteLine($"- User {u.Id}: {u.FirstName} {u.LastName} ({u.Email}), ManagerId: {u.ManagerId}");
                }
            }
            catch (Exception ex)
            {
                _output.WriteLine($"ERROR LOADING USERS: {ex}");
            }

            _output.WriteLine("=== TESTING LEAVE TYPES ===");
            try
            {
                var types = await context.LeaveTypes.ToListAsync();
                _output.WriteLine($"Successfully loaded {types.Count} leave types.");
            }
            catch (Exception ex)
            {
                _output.WriteLine($"ERROR LOADING LEAVE TYPES: {ex}");
            }

            _output.WriteLine("=== TESTING LEAVE REQUESTS ===");
            try
            {
                var requests = await context.LeaveRequests
                    .Include(l => l.User)
                    .Include(l => l.LeaveType)
                    .ToListAsync();
                _output.WriteLine($"Successfully loaded {requests.Count} leave requests.");
                foreach (var r in requests)
                {
                    _output.WriteLine($"- Request {r.Id}: User: {r.User?.FirstName} {r.User?.LastName}, LeaveType: {r.LeaveType?.Name}, Status: {r.Status}");
                    if (r.User == null)
                    {
                        _output.WriteLine($"  WARNING: User is null for Request {r.Id} (UserId: {r.UserId})");
                    }
                    if (r.LeaveType == null)
                    {
                        _output.WriteLine($"  WARNING: LeaveType is null for Request {r.Id} (LeaveTypeId: {r.LeaveTypeId})");
                    }
                }
            }
            catch (Exception ex)
            {
                _output.WriteLine($"ERROR LOADING LEAVE REQUESTS: {ex}");
            }

            _output.WriteLine("=== TESTING LEAVE BALANCES ===");
            try
            {
                var balances = await context.LeaveBalances
                    .Include(b => b.User)
                    .Include(b => b.LeaveType)
                    .ToListAsync();
                _output.WriteLine($"Successfully loaded {balances.Count} leave balances.");
            }
            catch (Exception ex)
            {
                _output.WriteLine($"ERROR LOADING LEAVE BALANCES: {ex}");
            }
        }
    }
}
