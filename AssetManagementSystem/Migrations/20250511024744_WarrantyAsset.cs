using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class WarrantyAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HaveWarranty",
                table: "Assets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyEndDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyStartDate",
                table: "Assets",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaveWarranty",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "WarrantyEndDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "WarrantyStartDate",
                table: "Assets");
        }
    }
}
