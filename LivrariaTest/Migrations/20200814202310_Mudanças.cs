using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaTest.Migrations
{
    public partial class Mudanças : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEditora",
                table: "Mt_Livros");

            migrationBuilder.AddColumn<int>(
                name: "Editora",
                table: "Mt_Livros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Mt_Livros");

            migrationBuilder.AddColumn<int>(
                name: "IdEditora",
                table: "Mt_Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
