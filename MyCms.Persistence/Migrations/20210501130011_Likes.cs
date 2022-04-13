using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCms.Persistence.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsLikes",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    NewsID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLikes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsLikesUser",
                columns: table => new
                {
                    LikesID = table.Column<long>(type: "bigint", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLikesUser", x => new { x.LikesID, x.UserID });
                    table.ForeignKey(
                        name: "FK_NewsLikesUser_NewsLikes_LikesID",
                        column: x => x.LikesID,
                        principalTable: "NewsLikes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsLikesUser_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsNewsLikes",
                columns: table => new
                {
                    LikesID = table.Column<long>(type: "bigint", nullable: false),
                    NewsID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsNewsLikes", x => new { x.LikesID, x.NewsID });
                    table.ForeignKey(
                        name: "FK_NewsNewsLikes_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsNewsLikes_NewsLikes_LikesID",
                        column: x => x.LikesID,
                        principalTable: "NewsLikes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NewsLikesUser_UserID",
                table: "NewsLikesUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsNewsLikes_NewsID",
                table: "NewsNewsLikes",
                column: "NewsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsLikesUser");

            migrationBuilder.DropTable(
                name: "NewsNewsLikes");

            migrationBuilder.DropTable(
                name: "NewsLikes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 17, 30, 56, 845, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 17, 30, 56, 850, DateTimeKind.Local).AddTicks(2342));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2021, 4, 30, 17, 30, 56, 850, DateTimeKind.Local).AddTicks(2567));
        }
    }
}
