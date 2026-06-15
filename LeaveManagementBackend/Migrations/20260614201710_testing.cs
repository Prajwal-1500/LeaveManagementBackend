using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementBackend.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
