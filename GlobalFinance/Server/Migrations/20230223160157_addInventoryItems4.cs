using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class addInventoryItems4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelVariantId",
                table: "Inventory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaintId",
                table: "Inventory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 1,
                columns: new[] { "ModelVariantId", "PaintId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Inventory",
                keyColumn: "InventoryId",
                keyValue: 2,
                columns: new[] { "ModelVariantId", "PaintId" },
                values: new object[] { 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModelVariantId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "PaintId",
                table: "Inventory");
        }
    }
}
