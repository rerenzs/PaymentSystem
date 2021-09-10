using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentSystem.Persistence.Migrations
{
    public partial class Sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountNumber", "Balance", "Name" },
                values: new object[] { 1L, 2123123, 1200m, "Peter Parker" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "ID", "AccountNumber", "Balance", "Name" },
                values: new object[] { 2L, 65456453, 2000m, "John Doe" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "AccountID", "Amount", "Date", "Reason", "Status" },
                values: new object[] { 1L, 1L, 1000m, new DateTime(2021, 9, 10, 12, 44, 14, 133, DateTimeKind.Local).AddTicks(7954), "some reason", "Close" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "AccountID", "Amount", "Date", "Reason", "Status" },
                values: new object[] { 2L, 1L, 5000m, new DateTime(2021, 9, 10, 12, 44, 14, 134, DateTimeKind.Local).AddTicks(8232), "", "Close" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "AccountID", "Amount", "Date", "Reason", "Status" },
                values: new object[] { 3L, 2L, 500m, new DateTime(2021, 9, 10, 12, 44, 14, 134, DateTimeKind.Local).AddTicks(8264), "some reason", "Pending" });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountID",
                table: "Payments",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
