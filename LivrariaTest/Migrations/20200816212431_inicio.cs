using Microsoft.EntityFrameworkCore.Migrations;

namespace LivrariaTest.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mt_Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
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
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mt_Editora", x => x.IdEditora);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mt_Livros",
                columns: table => new
                {
                    IdLivro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 40, nullable: false),
                    Autor = table.Column<int>(nullable: false),
                    Editora = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mt_Livros", x => x.IdLivro);
                    table.ForeignKey(
                        name: "FK_Mt_Livros_Mt_Autor_Autor",
                        column: x => x.Autor,
                        principalTable: "Mt_Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mt_Livros_Mt_Editora_Editora",
                        column: x => x.Editora,
                        principalTable: "Mt_Editora",
                        principalColumn: "IdEditora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mt_Livros_Autor",
                table: "Mt_Livros",
                column: "Autor");

            migrationBuilder.CreateIndex(
                name: "IX_Mt_Livros_Editora",
                table: "Mt_Livros",
                column: "Editora");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mt_Livros");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Mt_Autor");

            migrationBuilder.DropTable(
                name: "Mt_Editora");
        }
    }
}
