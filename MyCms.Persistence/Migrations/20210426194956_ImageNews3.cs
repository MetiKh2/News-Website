using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class ImageNews3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisPlayed",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ViewCount",
                table: "News",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 19, 55, 355, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 19, 55, 360, DateTimeKind.Local).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 19, 55, 360, DateTimeKind.Local).AddTicks(7114));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisPlayed",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "News");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 12, 44, 908, DateTimeKind.Local).AddTicks(2852));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 12, 44, 914, DateTimeKind.Local).AddTicks(2641));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 27, 0, 12, 44, 914, DateTimeKind.Local).AddTicks(2879));
        }
    }
}
