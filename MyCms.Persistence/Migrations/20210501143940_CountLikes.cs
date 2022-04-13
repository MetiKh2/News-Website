using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class CountLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "LikeCount",
                table: "News",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 19, 9, 39, 602, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 19, 9, 39, 609, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 19, 9, 39, 609, DateTimeKind.Local).AddTicks(4455));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "News");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 17, 30, 10, 345, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 17, 30, 10, 395, DateTimeKind.Local).AddTicks(1487));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 5, 1, 17, 30, 10, 395, DateTimeKind.Local).AddTicks(1700));
        }
    }
}
