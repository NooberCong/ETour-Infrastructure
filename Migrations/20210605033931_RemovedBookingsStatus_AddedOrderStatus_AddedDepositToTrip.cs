using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RemovedBookingsStatus_AddedOrderStatus_AddedDepositToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalPaid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "DatePaid",
                table: "Orders",
                newName: "PaymentDeadline");

            migrationBuilder.AddColumn<float>(
                name: "Deposit",
                table: "Trips",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeposited",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Deposited",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateDeposited",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Deposited",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "PaymentDeadline",
                table: "Orders",
                newName: "DatePaid");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
