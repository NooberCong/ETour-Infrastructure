using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddImageUrlsForPost_RenameIsDeletedToIsSoftDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banned",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Questions",
                newName: "IsSoftDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Posts",
                newName: "IsSoftDeleted");

            migrationBuilder.RenameColumn(
                name: "Banned",
                table: "Employees",
                newName: "IsSoftDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Customers",
                newName: "IsSoftDeleted");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "IsSoftDeleted",
                table: "Questions",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsSoftDeleted",
                table: "Posts",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsSoftDeleted",
                table: "Employees",
                newName: "Banned");

            migrationBuilder.RenameColumn(
                name: "IsSoftDeleted",
                table: "Customers",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<bool>(
                name: "Banned",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
