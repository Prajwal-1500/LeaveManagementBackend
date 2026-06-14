using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementBackend.Migrations
{
    /// <inheritdoc />
    public partial class seededLeaveBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveBalances",
                columns: new[] { "Id", "BalanceDays", "LeaveTypeId", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, 20m, 1, 3, 2026 },
                    { 2, 10m, 2, 3, 2026 },
                    { 3, 15m, 3, 3, 2026 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$FxY65N3/9F1p1CC3s4q5DO9v6up5RDb5eYA7LHJc8/sL/./YFUHTC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$8M178sJkEm0OcwWM7TJn.eLfqbTQBM.kQG3yC/ru8FaZxmS7bylIe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$jrcZHgUe3YRwmBjc22Fa5OVf.TXzER46kFaydBp20tMiYTZTdhSFy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$gC4hwP.m6jlcBq64W.JDuuzzoYonee48Cqki3/j4Qg1eUNp02r.m6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$6uYOZIQDqFDL0H/oq7xHke4qkOjHQ5CPQFdIZVlnYW49pX9Gh./zu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$P6pGQQD.78XwrHQzTFIiAu3viDRBZjntoVENerwHXfFc8kPEAzsUq");
        }
    }
}
