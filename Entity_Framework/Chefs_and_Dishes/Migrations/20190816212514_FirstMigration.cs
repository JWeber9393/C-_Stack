using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chefs_and_Dishes.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "chefs",
                columns: table => new
                {
                    ChefId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    _fname = table.Column<string>(nullable: false),
                    _lname = table.Column<string>(nullable: false),
                    _birthday = table.Column<DateTime>(nullable: false),
                    DishId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chefs", x => x.ChefId);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    _name = table.Column<string>(maxLength: 45, nullable: false),
                    _tastiness = table.Column<int>(nullable: false),
                    _calories = table.Column<int>(nullable: false),
                    _description = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ChefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.DishId);
                    table.ForeignKey(
                        name: "FK_dishes_chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "chefs",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_ChefId",
                table: "dishes",
                column: "ChefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "chefs");
        }
    }
}
