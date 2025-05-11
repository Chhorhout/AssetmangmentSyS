using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddKilogramToCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Kilogram",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilogram",
                table: "Categories");
        }
    }
}
