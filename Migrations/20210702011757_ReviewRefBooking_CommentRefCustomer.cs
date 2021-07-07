using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ReviewRefBooking_CommentRefCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_OwnerID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Tours_TourID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OwnerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_TourID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Reviewed",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TourID",
                table: "Reviews",
                newName: "BookingID");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Comment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookingID",
                table: "Reviews",
                column: "BookingID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerID",
                table: "Reviews",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OwnerID",
                table: "Customers",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_OwnerID",
                table: "Comment",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Customers_OwnerID",
                table: "Comment",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_OwnerID",
                table: "Customers",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bookings_BookingID",
                table: "Reviews",
                column: "BookingID",
                principalTable: "Bookings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerID",
                table: "Reviews",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Customers_OwnerID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_OwnerID",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bookings_BookingID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_BookingID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_CustomerID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OwnerID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Comment_OwnerID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Reviews",
                newName: "TourID");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Reviewed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OwnerID",
                table: "Reviews",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TourID",
                table: "Reviews",
                column: "TourID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_OwnerID",
                table: "Reviews",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Tours_TourID",
                table: "Reviews",
                column: "TourID",
                principalTable: "Tours",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
