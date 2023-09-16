using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KheftProject.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addgeneralbookstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookStatus",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookStatus",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Books",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Books",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
