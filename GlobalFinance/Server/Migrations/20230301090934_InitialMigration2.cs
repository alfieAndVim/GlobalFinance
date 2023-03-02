using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Orders_OrderId",
                table: "Finances");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Finances",
                newName: "EnquiryId");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_OrderId",
                table: "Finances",
                newName: "IX_Finances_EnquiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Orders_EnquiryId",
                table: "Finances",
                column: "EnquiryId",
                principalTable: "Orders",
                principalColumn: "EnquiryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_Orders_EnquiryId",
                table: "Finances");

            migrationBuilder.RenameColumn(
                name: "EnquiryId",
                table: "Finances",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Finances_EnquiryId",
                table: "Finances",
                newName: "IX_Finances_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_Orders_OrderId",
                table: "Finances",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "EnquiryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
