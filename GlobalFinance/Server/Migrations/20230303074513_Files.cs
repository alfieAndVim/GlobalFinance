using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalFinance.Server.Migrations
{
    /// <inheritdoc />
    public partial class Files : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "File",
                table: "FinanceDocuments",
                newName: "FileContent");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FinanceDocuments",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "FinanceDocuments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "FinanceDocuments");

            migrationBuilder.RenameColumn(
                name: "FileContent",
                table: "FinanceDocuments",
                newName: "File");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "FinanceDocuments",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
