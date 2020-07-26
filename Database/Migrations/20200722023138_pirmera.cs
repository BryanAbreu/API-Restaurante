using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class pirmera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreIngrediente = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadPersonas = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Estado = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesa = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Platos = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Subtotal = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePlato = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Precio = table.Column<int>(nullable: false),
                    CantidadPersonas = table.Column<int>(nullable: false),
                    Ingredientes = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    Categoria = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plato", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Plato");
        }
    }
}
