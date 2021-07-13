using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Remove_Customer_Owner_Again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Customers_OwnerID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_OwnerID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OwnerID",
                table: "Customers",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Customers_OwnerID",
                table: "Customers",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
