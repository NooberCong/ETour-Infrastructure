using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RewardPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOrdered",
                table: "Orders",
                newName: "DatePaid");

            migrationBuilder.AddColumn<int>(
                name: "RewardPoints",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TourFollowing",
                columns: table => new
                {
                    TourID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourFollowing", x => new { x.TourID, x.CustomerID });
                    table.ForeignKey(
                        name: "FK_TourFollowing_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourFollowing_Tours_TourID",
                        column: x => x.TourID,
                        principalTable: "Tours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourFollowing_CustomerID",
                table: "TourFollowing",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourFollowing");

            migrationBuilder.DropColumn(
                name: "RewardPoints",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "DatePaid",
                table: "Orders",
                newName: "DateOrdered");
        }
    }
}
