using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityNumberColumnInRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantIdentityNumber",
                table: "DepositRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "DepositRequests",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "RequestDate", "TenantIdentityNumber" },
                values: new object[] { new DateTime(2025, 9, 3, 14, 35, 30, 170, DateTimeKind.Utc).AddTicks(4852), "10987654321" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantIdentityNumber",
                table: "DepositRequests");

            migrationBuilder.UpdateData(
                table: "DepositRequests",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "RequestDate",
                value: new DateTime(2025, 9, 3, 13, 5, 2, 315, DateTimeKind.Utc).AddTicks(5086));
        }
    }
}
