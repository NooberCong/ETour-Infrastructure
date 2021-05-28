using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class OrderAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_BookerID",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookerID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookerID",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "BookerID",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookerID",
                table: "Bookings",
                column: "BookerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_BookerID",
                table: "Bookings",
                column: "BookerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
