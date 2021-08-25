using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtmDb.Migrations
{
    public partial class CreatDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bvn = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Cvv = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    LoginId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_LoginDetails_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoginDetails",
                columns: new[] { "Id", "CVV", "Name", "Password" },
                values: new object[] { 1, 123, "Alex", "1234" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountBalance", "AccountNumber", "Bvn", "Cvv", "FirstName", "LastName", "LoginId", "Password", "TimeStamp", "isActive" },
                values: new object[] { 1, 1234453636m, 760015555, 12345678m, 123, "Alex", "Ogubuike", 1, "1234", new DateTime(2021, 8, 25, 23, 15, 35, 608, DateTimeKind.Local).AddTicks(5650), true });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LoginId",
                table: "Accounts",
                column: "LoginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "LoginDetails");
        }
    }
}
