using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameTenantPhoneColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantPhone",
                table: "DepositRequests",
                newName: "TenantPhoneNumber");

            migrationBuilder.UpdateData(
                table: "DepositRequests",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "RentalEndDate", "RentalStartDate", "RequestDate" },
                values: new object[] { new DateTime(2025, 10, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 18, 14, 8, 57, 479, DateTimeKind.Utc).AddTicks(7328) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantPhoneNumber",
                table: "DepositRequests",
                newName: "TenantPhone");

            migrationBuilder.UpdateData(
                table: "DepositRequests",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "RentalEndDate", "RentalStartDate", "RequestDate" },
                values: new object[] { new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 3, 14, 35, 30, 170, DateTimeKind.Utc).AddTicks(4852) });
        }
    }
}
