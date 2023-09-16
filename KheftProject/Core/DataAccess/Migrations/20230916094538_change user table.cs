using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KheftProject.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeusertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.AddColumn<long>(
                name: "TelegramSerialId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TelegramSerialId",
                table: "Users",
                column: "TelegramSerialId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_TelegramSerialId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TelegramSerialId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }
    }
}
