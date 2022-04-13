using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class AddCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 24, 18, 40, 30, 856, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 24, 18, 40, 30, 862, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 24, 18, 40, 30, 862, DateTimeKind.Local).AddTicks(3544));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 23, 19, 3, 31, 6, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 23, 19, 3, 31, 11, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 23, 19, 3, 31, 11, DateTimeKind.Local).AddTicks(7294));
        }
    }
}
