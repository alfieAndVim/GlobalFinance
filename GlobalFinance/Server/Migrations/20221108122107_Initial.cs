using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    public partial class Initial : Migration
    {
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
                values: new object[] { 1, "Vauxhall", "Corsa", 16995, 400 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 2, "Vauxhall", "Astra", 16995, 450 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 3, "Vauxhall", "Mokka", 21000, 450 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 4, "Vauxhall", "Grandland", 26000, 460 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 5, "BMW", "3-Series", 32000, 480 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 6, "BMW", "4-Series", 40000, 490 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 7, "BMW", "5-Series", 42000, 495 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 8, "BMW", "7-Series", 105000, 750 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 9, "Audi", "A1", 19000, 300 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 10, "Audi", "A3", 26000, 350 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 11, "Audi", "A4", 33000, 400 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 12, "Audi", "A5", 39000, 420 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 13, "Audi", "A6", 42000, 480 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 14, "Audi", "A7", 51000, 540 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "CarMakeName", "CarModelName", "CarOutrightStartingPrice", "CarStartingPrice" },
                values: new object[] { 15, "Audi", "A8", 74000, 730 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 1, 1, "2/12/2002", 300 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 2, 2, "2/12/2002", 340 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 3, 3, "2/12/2002", 350 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 4, 4, "2/12/2002", 290 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 5, 5, "2/12/2002", 300 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 6, 6, "2/12/2002", 360 });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "CarId", "OfferExpiry", "OfferPrice" },
                values: new object[] { 7, 7, "2/12/2002", 390 });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
