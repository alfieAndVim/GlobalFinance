using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddModelVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelVariants",
                columns: table => new
                {
                    ModelVariantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelVariantName = table.Column<string>(type: "TEXT", nullable: false),
                    PriceIncrease = table.Column<int>(type: "INTEGER", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVariants", x => x.ModelVariantId);
                    table.ForeignKey(
                        name: "FK_ModelVariants_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ModelVariants",
                columns: new[] { "ModelVariantId", "CarId", "ModelVariantName", "PriceIncrease" },
                values: new object[,]
                {
                    { 1, 1, "Design", 0 },
                    { 2, 1, "GS Line", 2000 },
                    { 3, 1, "Ultimate", 6000 },
                    { 4, 2, "Design", 0 },
                    { 5, 2, "GS Line", 3000 },
                    { 6, 2, "Ultimate", 6000 },
                    { 7, 3, "Design", 0 },
                    { 8, 3, "GS Line", 3000 },
                    { 9, 3, "Ultimate", 6000 },
                    { 10, 4, "Design", 0 },
                    { 11, 4, "GS Line", 3000 },
                    { 12, 4, "Ultimate", 6000 },
                    { 13, 5, "Sport", 0 },
                    { 14, 5, "M Sport", 6000 },
                    { 15, 6, "Sport", 0 },
                    { 16, 6, "M Sport", 6000 },
                    { 17, 7, "Sport", 0 },
                    { 18, 7, "M Sport", 6000 },
                    { 19, 8, "Sport", 0 },
                    { 20, 8, "M Sport", 6000 },
                    { 21, 9, "Technik", 0 },
                    { 22, 9, "Sport", 4000 },
                    { 23, 9, "S Line", 6000 },
                    { 24, 10, "Technik", 0 },
                    { 25, 10, "Sport", 4000 },
                    { 26, 10, "S Line", 6000 },
                    { 27, 11, "Technik", 0 },
                    { 28, 11, "Sport", 4000 },
                    { 29, 11, "S Line", 6000 },
                    { 30, 12, "Technik", 0 },
                    { 31, 12, "Sport", 4000 },
                    { 32, 12, "S Line", 6000 },
                    { 33, 13, "Technik", 0 },
                    { 34, 13, "Sport", 4000 },
                    { 35, 13, "S Line", 6000 },
                    { 36, 14, "Technik", 0 },
                    { 37, 14, "Sport", 4000 },
                    { 38, 14, "S Line", 6000 },
                    { 39, 15, "Technik", 0 },
                    { 40, 15, "Sport", 4000 },
                    { 41, 15, "S Line", 6000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelVariants_CarId",
                table: "ModelVariants",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelVariants");
        }
    }
}
