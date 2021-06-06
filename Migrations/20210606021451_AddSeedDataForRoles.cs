using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddSeedDataForRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Permissions" },
                values: new object[] { "admin", "23423424", "Admin", "ADMIN", "Manage accounts,View analytics" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Permissions" },
                values: new object[] { "customer", "84938594", "Customer Relation Employee", "CUSTOMER RELATION EMPLOYEE", "Manage Blog,Manage User Questions & Answers" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "Permissions" },
                values: new object[] { "travel", "34938493", "Travel Employee", "TRAVEL EMPLOYEE", "Manage Tours,Manage Trips,Manage Itineraries,Manage Discounts,Manage Orders" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "customer");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "travel");
        }
    }
}
