using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InvoiceAdded_AuthorChangedToOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_AuthorID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_PointLog_Customers_AuthorID",
                table: "PointLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Employees_AuthorID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Customers_AuthorID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_AuthorID",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Reviews",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_AuthorID",
                table: "Reviews",
                newName: "IX_Reviews_OwnerID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Questions",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_AuthorID",
                table: "Questions",
                newName: "IX_Questions_OwnerID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Posts",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorID",
                table: "Posts",
                newName: "IX_Posts_OwnerID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "PointLog",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_PointLog_AuthorID",
                table: "PointLog",
                newName: "IX_PointLog_OwnerID");

            migrationBuilder.RenameColumn(
                name: "AuthorID",
                table: "Bookings",
                newName: "OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_AuthorID",
                table: "Bookings",
                newName: "IX_Bookings_OwnerID");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OwnerID",
                table: "Invoices",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_OwnerID",
                table: "Bookings",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointLog_Customers_OwnerID",
                table: "PointLog",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Employees_OwnerID",
                table: "Posts",
                column: "OwnerID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Customers_OwnerID",
                table: "Questions",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_OwnerID",
                table: "Reviews",
                column: "OwnerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_OwnerID",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_PointLog_Customers_OwnerID",
                table: "PointLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Employees_OwnerID",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Customers_OwnerID",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_OwnerID",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Reviews",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_OwnerID",
                table: "Reviews",
                newName: "IX_Reviews_AuthorID");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Questions",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_OwnerID",
                table: "Questions",
                newName: "IX_Questions_AuthorID");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Posts",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_OwnerID",
                table: "Posts",
                newName: "IX_Posts_AuthorID");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "PointLog",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_PointLog_OwnerID",
                table: "PointLog",
                newName: "IX_PointLog_AuthorID");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Bookings",
                newName: "AuthorID");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_OwnerID",
                table: "Bookings",
                newName: "IX_Bookings_AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_AuthorID",
                table: "Bookings",
                column: "AuthorID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PointLog_Customers_AuthorID",
                table: "PointLog",
                column: "AuthorID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Employees_AuthorID",
                table: "Posts",
                column: "AuthorID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Customers_AuthorID",
                table: "Questions",
                column: "AuthorID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_AuthorID",
                table: "Reviews",
                column: "AuthorID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
