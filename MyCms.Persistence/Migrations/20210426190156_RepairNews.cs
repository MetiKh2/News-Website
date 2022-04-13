using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class RepairNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "News");

            migrationBuilder.AddColumn<long>(
                name: "NewsCount",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 31, 55, 296, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 31, 55, 301, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 31, 55, 301, DateTimeKind.Local).AddTicks(6823));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsCount",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 25, 14, 62, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 25, 14, 67, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 26, 23, 25, 14, 67, DateTimeKind.Local).AddTicks(5458));
        }
    }
}
