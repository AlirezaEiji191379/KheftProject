using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KheftProject.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removewriterfrombook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Writer",
                table: "BookEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Writer",
                table: "BookEntity",
                type: "text",
                nullable: true);
        }
    }
}
