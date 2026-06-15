using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementBackend.Migrations
{
    /// <inheritdoc />
    public partial class testingMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$QOYuXt1uXfcfNsTDkRgTD.hVpqiKEzDXzY5DyiTJPBhf5ZKk2qrZe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$CXQPj1xhjpLVNIR4x2Bl5.DQLUuUTQ7cfVy0/6w.LeNnDGZy2uYFC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$D7L/OJQC3U7NmGAIUuGE.exAleb2FEw42Eb.L4N2/Bqe63cJxi1e.");
        }
    }
}
