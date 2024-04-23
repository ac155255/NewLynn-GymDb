using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLynn_GymDb.Migrations
{
    public partial class Member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Attendence_AttendenceID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Attendence_AttendenceID",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendence",
                table: "Attendence");

            migrationBuilder.RenameTable(
                name: "Attendence",
                newName: "Attendance");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Member",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Member",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "AttendenceID");

            migrationBuilder.InsertData(
                table: "Attendance",
                columns: new[] { "AttendenceID", "AttendenceDate", "EmployeeID", "MemberID", "Status" },
                values: new object[,]
                {
                    { 123, new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1500), 12, 12, "Present" },
                    { 321, new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1556), 5, 123, "Absent" },
                    { 576, new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1561), 22, 345, "Absent" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "AttendenceID", "Email", "FirstName", "HireDate", "LastName", "PhoneNumber", "Position", "Salary", "TransactionId" },
                values: new object[,]
                {
                    { 5, "1634 Great North Road", null, "wfuw3hf@gmail.com", "Ranav", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1835), "Singh", "022383968", "Front Desk", "$27.50/Hr", null },
                    { 12, "1603 Great South Road", null, "ac7egc33@gmail.com", "Sarah", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1825), "Dawon", "0223583943", "Manager", "$27.50/Hr", null },
                    { 22, "1603 Great South Road", null, "ac7egc33@gmail.com", "Sarah", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1840), "Dawon", "0223583943", "Manager", "$27.50/Hr", null }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "Address", "AttendenceID", "DateOfBirth", "Email", "FirstName", "JoinDate", "LastName", "MembershipType", "PaymentInformation", "PhoneNumber" },
                values: new object[,]
                {
                    { 12, "1603 Great South Road", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987), "ac7egc33@gmail.com", "Sarah", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1981), "Dawon", "Monthly", "4929 1234 5678 9012", "0223583943" },
                    { 123, "1603 Great South Road", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987), "ac7egc33@gmail.com", "Sarah", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1988), "Dawon", "Monthly", "4929 1234 5678 9012", "0223583943" },
                    { 345, "1603 Great South Road", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1987), "ac7egc33@gmail.com", "Sarah", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(1992), "Dawon", "Monthly", "4929 1234 5678 9012", "0223583943" }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionId", "Amount", "EmployeeID", "MemberID", "PaymentMethod", "TransactionDate" },
                values: new object[,]
                {
                    { 321, "100.00", 12, 12, "Credit Card", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(2074) },
                    { 654, "100.00", 22, 345, "Credit Card", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(2083) },
                    { 987, "100.00", 5, 123, "Credit Card", new DateTime(2024, 4, 9, 10, 8, 16, 345, DateTimeKind.Local).AddTicks(2079) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Attendance_AttendenceID",
                table: "Employee",
                column: "AttendenceID",
                principalTable: "Attendance",
                principalColumn: "AttendenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Attendance_AttendenceID",
                table: "Member",
                column: "AttendenceID",
                principalTable: "Attendance",
                principalColumn: "AttendenceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Attendance_AttendenceID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Attendance_AttendenceID",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendenceID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendenceID",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Attendance",
                keyColumn: "AttendenceID",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "TransactionId",
                keyValue: 987);

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendence");

            migrationBuilder.AlterColumn<string>(
                name: "JoinDate",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendence",
                table: "Attendence",
                column: "AttendenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Attendence_AttendenceID",
                table: "Employee",
                column: "AttendenceID",
                principalTable: "Attendence",
                principalColumn: "AttendenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Attendence_AttendenceID",
                table: "Member",
                column: "AttendenceID",
                principalTable: "Attendence",
                principalColumn: "AttendenceID");
        }
    }
}
