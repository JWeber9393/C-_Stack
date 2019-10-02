using Microsoft.EntityFrameworkCore.Migrations;

namespace Chefs_and_Dishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DishId",
                table: "chefs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "chefs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
