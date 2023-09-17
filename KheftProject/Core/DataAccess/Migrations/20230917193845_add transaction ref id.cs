using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KheftProject.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addtransactionrefid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionEntity_Books_BookId",
                table: "TransactionEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionEntity",
                table: "TransactionEntity");

            migrationBuilder.RenameTable(
                name: "TransactionEntity",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionEntity_BookId",
                table: "Transactions",
                newName: "IX_Transactions_BookId");

            migrationBuilder.AddColumn<long>(
                name: "BankTransactionRefId",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Transactions_BankTransactionRefId",
                table: "Transactions",
                column: "BankTransactionRefId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Books_BookId",
                table: "Transactions",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Books_BookId",
                table: "Transactions");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Transactions_BankTransactionRefId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankTransactionRefId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "TransactionEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_BookId",
                table: "TransactionEntity",
                newName: "IX_TransactionEntity_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionEntity",
                table: "TransactionEntity",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionEntity_Books_BookId",
                table: "TransactionEntity",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
