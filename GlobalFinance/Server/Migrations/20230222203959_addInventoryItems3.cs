using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class addInventoryItems3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryId", "CarId", "InventoryMileage", "InventoryPrice" },
                values: new object[] { 2, 1, 12000, 12000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2);
        }
    }
}
