using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLynn_GymDb.Migrations
{
    public partial class IDtoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employee_EmployeeID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Member_MemberID",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Transaction_TransactionId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "MemberTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TransactionId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_EmployeeID",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_MemberID",
                table: "Attendances",
                newName: "IX_Attendances_MemberID");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeFirstName",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberFirstName",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "AttendanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transactions",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MemberID",
                table: "Transactions",
                column: "MemberID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MemberID",
                table: "Attendances",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MemberID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_MemberID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeeID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MemberID",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EmployeeID",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "EmployeeFirstName",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "MemberFirstName",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_MemberID",
                table: "Attendance",
                newName: "IX_Attendance_MemberID");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendanceID");

            migrationBuilder.CreateTable(
                name: "MemberTransaction",
                columns: table => new
                {
                    MembersMemberId = table.Column<int>(type: "int", nullable: false),
                    TransactionsTransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTransaction", x => new { x.MembersMemberId, x.TransactionsTransactionId });
                    table.ForeignKey(
                        name: "FK_MemberTransaction_Member_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberTransaction_Transaction_TransactionsTransactionId",
                        column: x => x.TransactionsTransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TransactionId",
                table: "Employee",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmployeeID",
                table: "Attendance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTransaction_TransactionsTransactionId",
                table: "MemberTransaction",
                column: "TransactionsTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employee_EmployeeID",
                table: "Attendance",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Member_MemberID",
                table: "Attendance",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Transaction_TransactionId",
                table: "Employee",
                column: "TransactionId",
                principalTable: "Transaction",
                principalColumn: "TransactionId");
        }
    }
}
