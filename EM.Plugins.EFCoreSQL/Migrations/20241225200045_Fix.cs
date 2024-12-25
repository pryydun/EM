using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Plugins.EFCoreSQLServer.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 22, 0, 45, 52, DateTimeKind.Local).AddTicks(8391), new DateTime(2024, 12, 25, 22, 0, 45, 50, DateTimeKind.Local).AddTicks(4846) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 22, 0, 45, 52, DateTimeKind.Local).AddTicks(9079), new DateTime(2024, 12, 30, 22, 0, 45, 52, DateTimeKind.Local).AddTicks(9069) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 21, 29, 1, 626, DateTimeKind.Local).AddTicks(3235), new DateTime(2024, 12, 25, 21, 29, 1, 624, DateTimeKind.Local).AddTicks(8211) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 21, 29, 1, 626, DateTimeKind.Local).AddTicks(3629), new DateTime(2024, 12, 30, 21, 29, 1, 626, DateTimeKind.Local).AddTicks(3623) });
        }
    }
}
