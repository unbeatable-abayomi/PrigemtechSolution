using Microsoft.EntityFrameworkCore.Migrations;

namespace PrigemtechSolution.Migrations
{
    public partial class seedEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Deparment", "Email", "Name" },
                values: new object[] { 1, 2, "grace@mail.com", "Abayomi" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Deparment", "Email", "Name" },
                values: new object[] { 2, 1, "prue@mail.com", "comfort" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Deparment", "Email", "Name" },
                values: new object[] { 3, 3, "kunle@mail.com", "adekunle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
