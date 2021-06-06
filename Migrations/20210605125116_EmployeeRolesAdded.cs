using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class EmployeeRolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EmployeeRole");
        }
    }
}
