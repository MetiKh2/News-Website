using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class Slider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSlider",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 0, 29, 56, 99, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 0, 29, 56, 119, DateTimeKind.Local).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 0, 29, 56, 119, DateTimeKind.Local).AddTicks(7587));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSlider",
                table: "News");

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
    }
}
