using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaTest.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Mt_Livros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Codigo",
                table: "Mt_Livros",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
