using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddPointLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointLog_Customers_OwnerID",
                table: "PointLog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointLog",
                table: "PointLog");

            migrationBuilder.RenameTable(
                name: "PointLog",
                newName: "PointLogs");

            migrationBuilder.RenameIndex(
                name: "IX_PointLog_OwnerID",
                table: "PointLogs",
                newName: "IX_PointLogs_OwnerID");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Reviews",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointLogs",
                table: "PointLogs",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PointLogs_Customers_OwnerID",
                table: "PointLogs",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointLogs_Customers_OwnerID",
                table: "PointLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PointLogs",
                table: "PointLogs");

            migrationBuilder.RenameTable(
                name: "PointLogs",
                newName: "PointLog");

            migrationBuilder.RenameIndex(
                name: "IX_PointLogs_OwnerID",
                table: "PointLog",
                newName: "IX_PointLog_OwnerID");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PointLog",
                table: "PointLog",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PointLog_Customers_OwnerID",
                table: "PointLog",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
