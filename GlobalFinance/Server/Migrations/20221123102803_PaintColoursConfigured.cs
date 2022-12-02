using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class PaintColoursConfigured : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaintColours",
                columns: table => new
                {
                    PaintId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PriceIncrease = table.Column<int>(type: "INTEGER", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintColours", x => x.PaintId);
                    table.ForeignKey(
                        name: "FK_PaintColours_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PaintColours",
                columns: new[] { "PaintId", "CarId", "Name", "PriceIncrease" },
                values: new object[,]
                {
                    { 1, 1, "Solid White", 0 },
                    { 2, 1, "Crystal Silver", 600 },
                    { 3, 1, "Crimson Red", 700 },
                    { 4, 2, "Solid White", 0 },
                    { 5, 2, "Crystal Silver", 600 },
                    { 6, 2, "Cobalt Blue", 600 },
                    { 7, 3, "Solid White", 0 },
                    { 8, 3, "Voltaic Blue", 600 },
                    { 9, 3, "Iconic Green", 700 },
                    { 10, 4, "Solid White", 0 },
                    { 11, 4, "Contrast Grey", 600 },
                    { 12, 4, "Cobalt Blue", 700 },
                    { 13, 5, "Solid White", 0 },
                    { 14, 5, "Melbourne Red Metallic", 695 },
                    { 15, 5, "Black Sapphire Metallic", 695 },
                    { 16, 6, "Solid White", 0 },
                    { 17, 6, "Sunset Orange", 695 },
                    { 18, 6, "Black Sapphire Metallic", 695 },
                    { 19, 7, "Solid White", 0 },
                    { 20, 7, "Mineral White Metallic", 900 },
                    { 21, 7, "Black Sapphire Metallic", 900 },
                    { 22, 8, "Solid White", 0 },
                    { 23, 8, "Black Sapphire Metallic", 0 },
                    { 24, 8, "Oxide Grey", 1100 },
                    { 25, 9, "Solid White", 0 },
                    { 26, 9, "Python Yellow", 575 },
                    { 27, 9, "Mythos Black", 575 },
                    { 28, 10, "Solid White", 0 },
                    { 29, 10, "Forest Silver", 575 },
                    { 30, 10, "Mythos Black", 575 },
                    { 31, 11, "Solid White", 0 },
                    { 32, 11, "Forest Silver", 675 },
                    { 33, 11, "Navarra Blue", 675 },
                    { 34, 12, "Solid White", 0 },
                    { 35, 12, "Glacier White", 675 },
                    { 36, 12, "Tango Red", 675 },
                    { 37, 13, "Solid White", 0 },
                    { 38, 13, "Forest Silver", 685 },
                    { 39, 13, "Tango red", 685 },
                    { 40, 14, "Solid White", 0 },
                    { 41, 14, "Forest Grey", 685 },
                    { 42, 14, "Tango Red", 685 },
                    { 43, 15, "Solid White", 0 },
                    { 44, 15, "Firmament Blue", 0 },
                    { 45, 15, "Mythos Black", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaintColours_CarId",
                table: "PaintColours",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaintColours");
        }
    }
}
