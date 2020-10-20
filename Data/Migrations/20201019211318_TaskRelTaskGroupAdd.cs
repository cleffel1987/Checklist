using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckList.Data.Migrations
{
    public partial class TaskRelTaskGroupAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskGroupID",
                table: "Tasks",
                newName: "TaskGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskGroupID",
                table: "Tasks",
                newName: "IX_Tasks_TaskGroupId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskGroupId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupId",
                table: "Tasks",
                column: "TaskGroupId",
                principalTable: "TaskGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskGroupId",
                table: "Tasks",
                newName: "TaskGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_TaskGroupId",
                table: "Tasks",
                newName: "IX_Tasks_TaskGroupID");

            migrationBuilder.AlterColumn<Guid>(
                name: "TaskGroupID",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskGroups_TaskGroupID",
                table: "Tasks",
                column: "TaskGroupID",
                principalTable: "TaskGroups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
