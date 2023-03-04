using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SavedConfigurations_SavedConfigurationId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SavedConfigurationId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SavedConfigurations_SavedConfigurationId",
                table: "Orders",
                column: "SavedConfigurationId",
                principalTable: "SavedConfigurations",
                principalColumn: "SavedConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SavedConfigurations_SavedConfigurationId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SavedConfigurationId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InventoryId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SavedConfigurations_SavedConfigurationId",
                table: "Orders",
                column: "SavedConfigurationId",
                principalTable: "SavedConfigurations",
                principalColumn: "SavedConfigurationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
