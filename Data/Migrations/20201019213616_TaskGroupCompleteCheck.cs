using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckList.Data.Migrations
{
    public partial class TaskGroupCompleteCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "TaskGroups",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complete",
                table: "TaskGroups");
        }
    }
}
