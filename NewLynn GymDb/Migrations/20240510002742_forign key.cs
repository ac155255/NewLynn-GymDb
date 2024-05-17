using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLynn_GymDb.Migrations
{
    public partial class forignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Attendance_AttendanceID",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AttendanceID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AttendanceID",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_EmployeeID",
                table: "Attendance",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Employee_EmployeeID",
                table: "Attendance",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Employee_EmployeeID",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_EmployeeID",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AttendanceID",
                table: "Employee",
                column: "AttendanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Attendance_AttendanceID",
                table: "Employee",
                column: "AttendanceID",
                principalTable: "Attendance",
                principalColumn: "AttendanceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
