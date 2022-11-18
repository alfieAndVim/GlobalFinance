using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarMakeName = table.Column<string>(type: "TEXT", nullable: false),
                    CarModelName = table.Column<string>(type: "TEXT", nullable: false),
                    CarStartingPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    CarOutrightStartingPrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OfferPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    OfferExpiry = table.Column<string>(type: "TEXT", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[,]
                {
                    { 1, "Vauxhall", "Corsa", 16995, 400 },
                    { 2, "Vauxhall", "Astra", 16995, 450 },
                    { 3, "Vauxhall", "Mokka", 21000, 450 },
                    { 4, "Vauxhall", "Grandland", 26000, 460 },
                    { 5, "BMW", "3-Series", 32000, 480 },
                    { 6, "BMW", "4-Series", 40000, 490 },
                    { 7, "BMW", "5-Series", 42000, 495 },
                    { 8, "BMW", "7-Series", 105000, 750 },
                    { 9, "Audi", "A1", 19000, 300 },
                    { 10, "Audi", "A3", 26000, 350 },
                    { 11, "Audi", "A4", 33000, 400 },
                    { 12, "Audi", "A5", 39000, 420 },
                    { 13, "Audi", "A6", 42000, 480 },
                    { 14, "Audi", "A7", 51000, 540 },
                    { 15, "Audi", "A8", 74000, 730 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[,]
                {
                    { 1, 1, "2/12/2002", 300 },
                    { 2, 2, "2/12/2002", 340 },
                    { 3, 3, "2/12/2002", 350 },
                    { 4, 4, "2/12/2002", 290 },
                    { 5, 5, "2/12/2002", 300 },
                    { 6, 6, "2/12/2002", 360 },
                    { 7, 7, "2/12/2002", 390 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
