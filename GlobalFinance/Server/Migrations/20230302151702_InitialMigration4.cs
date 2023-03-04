using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FinanceTotalCost",
                table: "Finances",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanceTotalCost",
                table: "Finances");
        }
    }
}
