using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EM.Plugins.EFCoreSQLServer.Migrations
{
    /// <inheritdoc />
    public partial class FixUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 22, 1, 31, 70, DateTimeKind.Local).AddTicks(8616), new DateTime(2024, 12, 25, 22, 1, 31, 69, DateTimeKind.Local).AddTicks(1718) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 22, 1, 31, 70, DateTimeKind.Local).AddTicks(9046), new DateTime(2024, 12, 30, 22, 1, 31, 70, DateTimeKind.Local).AddTicks(9040) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
