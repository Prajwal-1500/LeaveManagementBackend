using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementBackend.Migrations
{
    /// <inheritdoc />
    public partial class addedLeaveBalancseededEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveBalances",
                columns: new[] { "Id", "BalanceDays", "LeaveTypeId", "UserId", "Year" },
                values: new object[,]
                {
                    { 4, 20m, 1, 2, 2026 },
                    { 5, 10m, 2, 2, 2026 },
                    { 6, 15m, 3, 2, 2026 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$SFpxXxGU5fvbEplsiJHDBOXB1oBXK4AszGlq/NYgNssdax35QKScm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$KlyHJ58LYt64WwHmIJpc4uiZI1WjdJnlPuZY6tG3iM7JvfAdvXqVq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$zxd3qBptSGxmYSYxWAX12ezaF6U0NFhQUh04yzqKoFLZ7EBa/Xk4a");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "ManagerId", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jasneet@tx.com", "Jasneet", "Emp", 2, "$2a$11$LUn4hYzS/8KdNoO9/bgJZOaYIT6NNBYz4gmmbMXKN0vJDVZw3YreC", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "raghav@tx.com", "Raghav", "Emp", 2, "$2a$11$jm.xcSXsIYMyEl02IwuhE.1/yOcTmEkriLZciVfTzQgrg7j6D2vnW", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hardil@tx.com", "Hardil", "Emp", 2, "$2a$11$20Lh2SMf2TOGRYzUWL6HDOOw0kj/ymH1YqLdm8RxB8FBP27sCTCsK", 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LeaveBalances",
                columns: new[] { "Id", "BalanceDays", "LeaveTypeId", "UserId", "Year" },
                values: new object[,]
                {
                    { 7, 20m, 1, 4, 2026 },
                    { 8, 10m, 2, 4, 2026 },
                    { 9, 15m, 3, 4, 2026 },
                    { 10, 20m, 1, 5, 2026 },
                    { 11, 10m, 2, 5, 2026 },
                    { 12, 15m, 3, 5, 2026 },
                    { 13, 20m, 1, 6, 2026 },
                    { 14, 10m, 2, 6, 2026 },
                    { 15, 15m, 3, 6, 2026 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$W5PEMkt5qwgNzrqnyq.Yk.MKFVpdXma1378jZWKwMplo77ohxjgW.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$Xp.0B2SDKpASuo2rQkqjP.DvmEM1/6rg0YJcXQqurFeIMUFUxIBRC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$03IjxoRl8BmB3LxSVOu6XuKxRjqe6PmLNCGNkV956EnhRpDkQ5chG");
        }
    }
}
