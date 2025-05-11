using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class IDforAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Assets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Warranty",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
