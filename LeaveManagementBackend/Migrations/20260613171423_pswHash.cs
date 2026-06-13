using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementBackend.Migrations
{
    /// <inheritdoc />
    public partial class pswHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "Admin123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "Dhruv123");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "Rajat123");
        }
    }
}
