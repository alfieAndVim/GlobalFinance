using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class SQLServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMakeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarStartingPrice = table.Column<int>(type: "int", nullable: false),
                    CarOutrightStartingPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressFirstLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressSecondLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressThirdLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPostcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ModelVariants",
                columns: table => new
                {
                    ModelVariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceIncrease = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferPrice = table.Column<int>(type: "int", nullable: false),
                    OfferExpiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PaintColours",
                columns: table => new
                {
                    PaintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceIncrease = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customisations",
                columns: table => new
                {
                    CustomisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ModelVariantId = table.Column<int>(type: "int", nullable: false),
                    PaintId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customisations", x => x.CustomisationId);
                    table.ForeignKey(
                        name: "FK_Customisations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customisations_ModelVariants_ModelVariantId",
                        column: x => x.ModelVariantId,
                        principalTable: "ModelVariants",
                        principalColumn: "ModelVariantId");
                    table.ForeignKey(
                        name: "FK_Customisations_PaintColours_PaintId",
                        column: x => x.PaintId,
                        principalTable: "PaintColours",
                        principalColumn: "PaintId");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryMileage = table.Column<int>(type: "int", nullable: false),
                    InventoryPrice = table.Column<int>(type: "int", nullable: false),
                    CustomisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Customisations_CustomisationId",
                        column: x => x.CustomisationId,
                        principalTable: "Customisations",
                        principalColumn: "CustomisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedConfigurations",
                columns: table => new
                {
                    SavedConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationPrice = table.Column<int>(type: "int", nullable: false),
                    CustomisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedConfigurations", x => x.SavedConfigurationId);
                    table.ForeignKey(
                        name: "FK_SavedConfigurations_Customisations_CustomisationId",
                        column: x => x.CustomisationId,
                        principalTable: "Customisations",
                        principalColumn: "CustomisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    EnquiryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SavedConfigurationId = table.Column<int>(type: "int", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.EnquiryId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId");
                    table.ForeignKey(
                        name: "FK_Orders_SavedConfigurations_SavedConfigurationId",
                        column: x => x.SavedConfigurationId,
                        principalTable: "SavedConfigurations",
                        principalColumn: "SavedConfigurationId");
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    FinanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancePrice = table.Column<double>(type: "float", nullable: false),
                    FinanceInterestRate = table.Column<double>(type: "float", nullable: false),
                    FinanceMonths = table.Column<int>(type: "int", nullable: false),
                    FinanceInitialPayment = table.Column<double>(type: "float", nullable: false),
                    FinanceTotalCost = table.Column<double>(type: "float", nullable: false),
                    Approval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnquiryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.FinanceId);
                    table.ForeignKey(
                        name: "FK_Finances_Orders_EnquiryId",
                        column: x => x.EnquiryId,
                        principalTable: "Orders",
                        principalColumn: "EnquiryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinanceDocuments",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoredFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceDocuments", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FinanceDocuments_Finances_FinanceId",
                        column: x => x.FinanceId,
                        principalTable: "Finances",
                        principalColumn: "FinanceId",
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
                table: "ModelVariants",
                columns: new[] { "ModelVariantId", "CarId", "Name", "PriceIncrease" },
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

            migrationBuilder.InsertData(
                table: "Customisations",
                columns: new[] { "CustomisationId", "CarId", "ModelVariantId", "PaintId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                columns: new[] { "InventoryId", "CustomisationId", "InventoryMileage", "InventoryPrice" },
                values: new object[,]
                {
                    { 1, 1, 12000, 12000 },
                    { 2, 2, 12000, 12000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customisations_CarId",
                table: "Customisations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Customisations_ModelVariantId",
                table: "Customisations",
                column: "ModelVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Customisations_PaintId",
                table: "Customisations",
                column: "PaintId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceDocuments_FinanceId",
                table: "FinanceDocuments",
                column: "FinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_EnquiryId",
                table: "Finances",
                column: "EnquiryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CustomisationId",
                table: "Inventory",
                column: "CustomisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVariants_CarId",
                table: "ModelVariants",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CarId",
                table: "Offers",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InventoryId",
                table: "Orders",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SavedConfigurationId",
                table: "Orders",
                column: "SavedConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintColours_CarId",
                table: "PaintColours",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedConfigurations_CustomisationId",
                table: "SavedConfigurations",
                column: "CustomisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceDocuments");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "SavedConfigurations");

            migrationBuilder.DropTable(
                name: "Customisations");

            migrationBuilder.DropTable(
                name: "ModelVariants");

            migrationBuilder.DropTable(
                name: "PaintColours");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
