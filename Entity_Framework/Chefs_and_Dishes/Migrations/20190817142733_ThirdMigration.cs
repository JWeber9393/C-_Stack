using Microsoft.EntityFrameworkCore.Migrations;

namespace Chefs_and_Dishes.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "_age",
                table: "chefs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_age",
                table: "chefs");
        }
    }
}
