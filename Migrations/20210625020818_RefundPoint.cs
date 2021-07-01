using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RefundPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_OwnerID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OwnerID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "Refunded",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Refunded",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OwnerID",
                table: "Invoices",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_OwnerID",
                table: "Invoices",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
