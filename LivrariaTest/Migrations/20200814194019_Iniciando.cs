using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaTest.Migrations
{
    public partial class Iniciando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mt_Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mt_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Mt_Editora",
                columns: table => new
                {
                    IdEditora = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mt_Editora", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Mt_Livros",
                columns: table => new
                {
                    IdLivro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Mt_Autor = table.Column<int>(nullable: true),
                    Autor = table.Column<int>(nullable: false),
                    Mt_Editora = table.Column<int>(nullable: true),
                    IdEditora = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 700, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mt_Livros", x => x.IdLivro);
                    table.ForeignKey(
                        name: "FK_Mt_Livros_Mt_Autor_Mt_Autor",
                        column: x => x.Mt_Autor,
                        principalTable: "Mt_Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mt_Livros_Mt_Editora_Mt_Editora",
                        column: x => x.Mt_Editora,
                        principalTable: "Mt_Editora",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mt_Livros_Mt_Autor",
                table: "Mt_Livros",
                column: "Mt_Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Mt_Livros_Mt_Editora",
                table: "Mt_Livros",
                column: "Mt_Editora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mt_Livros");

            migrationBuilder.DropTable(
                name: "Mt_Autor");

            migrationBuilder.DropTable(
                name: "Mt_Editora");
        }
    }
}
