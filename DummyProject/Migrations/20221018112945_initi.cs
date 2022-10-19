using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DummyProject.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Key = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_No = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Logins_UserName",
                        column: x => x.UserName,
                        principalTable: "Logins",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Admin_UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_LoanDetails_Logins_Admin_UserName",
                        column: x => x.Admin_UserName,
                        principalTable: "Logins",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    UserLoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone_No = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LoanNo = table.Column<int>(type: "int", nullable: true),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoans", x => x.UserLoanId);
                    table.ForeignKey(
                        name: "FK_UserLoans_Customers_UserId",
                        column: x => x.UserId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLoans_LoanDetails_LoanNo",
                        column: x => x.LoanNo,
                        principalTable: "LoanDetails",
                        principalColumn: "LoanId");
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Username", "Key", "Password", "PasswordHash", "Role" },
                values: new object[] { "Admin123", null, "abcde", null, "admin" });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Username", "Key", "Password", "PasswordHash", "Role" },
                values: new object[] { "user123", null, "abcd", null, "user" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "First_Name", "Last_Name", "Phone_No", "UserName" },
                values: new object[] { 101, "India", "Shivi", "Vani", 999, "user123" });

            migrationBuilder.InsertData(
                table: "LoanDetails",
                columns: new[] { "LoanId", "Admin_UserName", "Amount", "LoanType" },
                values: new object[] { 45, "Admin123", 30000f, "Home Loan" });

            migrationBuilder.InsertData(
                table: "UserLoans",
                columns: new[] { "UserLoanId", "LoanNo", "LoanStatus", "Phone_No", "UserId" },
                values: new object[] { 1, 45, "Pending", 0, 101 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserName",
                table: "Customers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_Admin_UserName",
                table: "LoanDetails",
                column: "Admin_UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_LoanNo",
                table: "UserLoans",
                column: "LoanNo");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoans_UserId",
                table: "UserLoans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoans");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
