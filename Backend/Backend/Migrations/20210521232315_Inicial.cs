using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    CiudadOrigen = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editorial",
                columns: table => new
                {
                    IdEditorial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(20)", nullable: false),
                    MaxLibrosRegistrados = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editorial", x => x.IdEditorial);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(type: "varchar(20)", nullable: false),
                    NumPaginas = table.Column<int>(nullable: false),
                    IdEditorial = table.Column<int>(nullable: false),
                    IdAutor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Editorial_IdEditorial",
                        column: x => x.IdEditorial,
                        principalTable: "Editorial",
                        principalColumn: "IdEditorial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdAutor",
                table: "Libro",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdEditorial",
                table: "Libro",
                column: "IdEditorial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Editorial");
        }
    }
}
