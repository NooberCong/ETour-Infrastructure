using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class TripIsNowOwned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Trips",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_OwnerID",
                table: "Trips",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Employees_OwnerID",
                table: "Trips",
                column: "OwnerID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Employees_OwnerID",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_OwnerID",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Trips");
        }
    }
}
