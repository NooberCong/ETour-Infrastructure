using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InvoiceBookingRefAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingID",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BookingID",
                table: "Invoices",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Bookings_BookingID",
                table: "Invoices",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Bookings_BookingID",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_BookingID",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "BookingID",
                table: "Invoices");
        }
    }
}
