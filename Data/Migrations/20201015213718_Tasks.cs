using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckList.Data.Migrations
{
    public partial class Tasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AddByUserId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaskGroups_AspNetUsers_AddByUserId",
                        column: x => x.AddByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TaskTitle = table.Column<string>(nullable: true),
                    TaskComplete = table.Column<bool>(nullable: false),
                    TaskDue = table.Column<DateTime>(nullable: true),
                    AddDate = table.Column<DateTime>(nullable: false),
                    AddByUserId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateByUserId = table.Column<string>(nullable: true),
                    TaskGroupID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_AddByUserId",
                        column: x => x.AddByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskGroups_TaskGroupID",
                        column: x => x.TaskGroupID,
                        principalTable: "TaskGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UpdateByUserId",
                        column: x => x.UpdateByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskGroups_AddByUserId",
                table: "TaskGroups",
                column: "AddByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AddByUserId",
                table: "Tasks",
                column: "AddByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskGroupID",
                table: "Tasks",
                column: "TaskGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UpdateByUserId",
                table: "Tasks",
                column: "UpdateByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskGroups");
        }
    }
}
