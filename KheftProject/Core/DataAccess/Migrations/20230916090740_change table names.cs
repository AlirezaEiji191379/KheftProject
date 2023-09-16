using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KheftProject.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changetablenames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookEntity_UserEntity_OwnerId",
                table: "BookEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity");

            migrationBuilder.RenameTable(
                name: "UserEntity",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "BookEntity",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_TelegramUsername",
                table: "Users",
                newName: "IX_Users_TelegramUsername");

            migrationBuilder.RenameIndex(
                name: "IX_UserEntity_PhoneNumber",
                table: "Users",
                newName: "IX_Users_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_BookEntity_OwnerId",
                table: "Books",
                newName: "IX_Books_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_OwnerId",
                table: "Books",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_OwnerId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserEntity");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "BookEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TelegramUsername",
                table: "UserEntity",
                newName: "IX_UserEntity_TelegramUsername");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PhoneNumber",
                table: "UserEntity",
                newName: "IX_UserEntity_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OwnerId",
                table: "BookEntity",
                newName: "IX_BookEntity_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntity",
                table: "UserEntity",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookEntity",
                table: "BookEntity",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookEntity_UserEntity_OwnerId",
                table: "BookEntity",
                column: "OwnerId",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
