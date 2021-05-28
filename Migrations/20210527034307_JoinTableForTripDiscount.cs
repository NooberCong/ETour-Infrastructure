using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class JoinTableForTripDiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountTrip");

            migrationBuilder.CreateTable(
                name: "TripDiscount",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDiscount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TripDiscount_Discounts_DiscountID",
                        column: x => x.DiscountID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripDiscount_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripDiscount_DiscountID",
                table: "TripDiscount",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_TripDiscount_TripID",
                table: "TripDiscount",
                column: "TripID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDiscount");

            migrationBuilder.CreateTable(
                name: "DiscountTrip",
                columns: table => new
                {
                    DiscountsID = table.Column<int>(type: "int", nullable: false),
                    TripsAppliedID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountTrip", x => new { x.DiscountsID, x.TripsAppliedID });
                    table.ForeignKey(
                        name: "FK_DiscountTrip_Discounts_DiscountsID",
                        column: x => x.DiscountsID,
                        principalTable: "Discounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountTrip_Trips_TripsAppliedID",
                        column: x => x.TripsAppliedID,
                        principalTable: "Trips",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountTrip_TripsAppliedID",
                table: "DiscountTrip",
                column: "TripsAppliedID");
        }
    }
}
