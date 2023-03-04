using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class FinanceApproval2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Finances");

            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "Finances",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "Finances");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Finances",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
