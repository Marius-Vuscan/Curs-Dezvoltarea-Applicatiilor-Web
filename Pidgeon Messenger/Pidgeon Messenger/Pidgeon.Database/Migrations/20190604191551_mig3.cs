using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pidgeon.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserVsgroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    GroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVsgroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVsgroup_UsersGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UsersGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserVsgroup_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserVsgroupId = table.Column<string>(nullable: true),
                    Message1 = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_UserVsgroup_UserVsgroupId",
                        column: x => x.UserVsgroupId,
                        principalTable: "UserVsgroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserVsgroupId",
                table: "Message",
                column: "UserVsgroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVsgroup_GroupId",
                table: "UserVsgroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVsgroup_UserId",
                table: "UserVsgroup",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "UserVsgroup");

            migrationBuilder.DropTable(
                name: "UsersGroup");
        }
    }
}
