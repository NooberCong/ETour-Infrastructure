using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class MergeEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_UserId",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmployeeRole");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                columns: new[] { "EmployeeId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_EmployeeId1",
                table: "EmployeeRole",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId",
                table: "EmployeeRole",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId1",
                table: "EmployeeRole",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId",
                table: "EmployeeRole");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRole_Employees_EmployeeId1",
                table: "EmployeeRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRole_EmployeeId1",
                table: "EmployeeRole");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeRole");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmployeeRole",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeRole",
                table: "EmployeeRole",
                columns: new[] { "UserId", "RoleId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRole_Employees_UserId",
                table: "EmployeeRole",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
