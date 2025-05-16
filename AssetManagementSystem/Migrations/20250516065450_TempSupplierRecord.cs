using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class TempSupplierRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] {"Id", "Name", "Email", "PhoneNumber", "Active"},
                values: new object[] {
                    Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    "Temp Supplier",
                    "temp@example.com",
                    "1234567890",
                    true

                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
