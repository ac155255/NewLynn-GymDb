using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLynn_GymDb.Migrations
{
    public partial class erros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_MemberID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_MemberID",
                table: "Transaction",
                newName: "IX_Transaction_MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transaction",
                newName: "IX_Transaction_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Employees_EmployeeID",
                table: "Transaction",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Members_MemberID",
                table: "Transaction",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Employees_EmployeeID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Members_MemberID",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_MemberID",
                table: "Transactions",
                newName: "IX_Transactions_MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_EmployeeID",
                table: "Transactions",
                newName: "IX_Transactions_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeeID",
                table: "Transactions",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_MemberID",
                table: "Transactions",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
