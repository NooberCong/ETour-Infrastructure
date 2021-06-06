using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveEmployeeRolesFromEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId1",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_EmployeeId1",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_EmployeeId1",
                table: "EmployeeRole",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId1",
                table: "EmployeeRole",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
