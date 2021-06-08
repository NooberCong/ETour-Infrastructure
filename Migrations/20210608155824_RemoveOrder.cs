using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemoveOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Orders_OrderID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OrderID",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Bookings",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorID",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeposited",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepositPaymentType",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Deposited",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullPaymentType",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDeadline",
                table: "Bookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Bookings",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgeGroup = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerInfo_Bookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Bookings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AuthorID",
                table: "Bookings",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfo_BookingID",
                table: "CustomerInfo",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_AuthorID",
                table: "Bookings",
                column: "AuthorID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_AuthorID",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AuthorID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DateDeposited",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DepositPaymentType",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Deposited",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "FullPaymentType",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentDeadline",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Bookings");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeposited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deposited = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OrderID",
                table: "Bookings",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Orders_OrderID",
                table: "Bookings",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
