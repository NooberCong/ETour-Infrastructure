using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveUnecessaryDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDiscounts_Discounts_DiscountID",
                table: "TripDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDiscounts_Trips_TripID",
                table: "TripDiscounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripDiscounts",
                table: "TripDiscounts");

            migrationBuilder.RenameTable(
                name: "TripDiscounts",
                newName: "TripDiscount");

            migrationBuilder.RenameIndex(
                name: "IX_TripDiscounts_DiscountID",
                table: "TripDiscount",
                newName: "IX_TripDiscount_DiscountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDiscount",
                table: "TripDiscount",
                columns: new[] { "TripID", "DiscountID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TripDiscount_Discounts_DiscountID",
                table: "TripDiscount",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDiscount_Trips_TripID",
                table: "TripDiscount",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripDiscount_Discounts_DiscountID",
                table: "TripDiscount");

            migrationBuilder.DropForeignKey(
                name: "FK_TripDiscount_Trips_TripID",
                table: "TripDiscount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripDiscount",
                table: "TripDiscount");

            migrationBuilder.RenameTable(
                name: "TripDiscount",
                newName: "TripDiscounts");

            migrationBuilder.RenameIndex(
                name: "IX_TripDiscount_DiscountID",
                table: "TripDiscounts",
                newName: "IX_TripDiscounts_DiscountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripDiscounts",
                table: "TripDiscounts",
                columns: new[] { "TripID", "DiscountID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TripDiscounts_Discounts_DiscountID",
                table: "TripDiscounts",
                column: "DiscountID",
                principalTable: "Discounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripDiscounts_Trips_TripID",
                table: "TripDiscounts",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
