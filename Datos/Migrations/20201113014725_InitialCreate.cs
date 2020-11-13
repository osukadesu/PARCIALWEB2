using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "varchar(12)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(12)", nullable: true),
                    Apellido = table.Column<string>(type: "varchar(12)", nullable: true),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(25)", nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(14)", nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdEstudiante = table.Column<string>(type: "varchar(12)", nullable: true),
                    NombreAcudiente = table.Column<string>(type: "varchar(12)", nullable: true),
                    Colegio = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    IdVacuna = table.Column<string>(type: "varchar(4)", nullable: false),
                    TipoVacuna = table.Column<string>(type: "varchar(30)", nullable: true),
                    FechaVacuna = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cedula = table.Column<string>(type: "varchar(12)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.IdVacuna);
                    table.ForeignKey(
                        name: "FK_Vacunas_Personas_Cedula",
                        column: x => x.Cedula,
                        principalTable: "Personas",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_Cedula",
                table: "Vacunas",
                column: "Cedula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
