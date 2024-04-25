using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personaapi_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Cc = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Cc);
                });

            migrationBuilder.CreateTable(
                name: "Profesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Operador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaCedula = table.Column<int>(type: "int", nullable: false),
                    PersonaCc = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Telefonos_Personas_PersonaCc",
                        column: x => x.PersonaCc,
                        principalTable: "Personas",
                        principalColumn: "Cc");
                });

            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaCedula = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Universidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaCc = table.Column<int>(type: "int", nullable: true),
                    ProfesionId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudios_Personas_PersonaCc",
                        column: x => x.PersonaCc,
                        principalTable: "Personas",
                        principalColumn: "Cc");
                    table.ForeignKey(
                        name: "FK_Estudios_Profesiones_ProfesionId1",
                        column: x => x.ProfesionId1,
                        principalTable: "Profesiones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_PersonaCc",
                table: "Estudios",
                column: "PersonaCc");

            migrationBuilder.CreateIndex(
                name: "IX_Estudios_ProfesionId1",
                table: "Estudios",
                column: "ProfesionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Cc",
                table: "Personas",
                column: "Cc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_Id",
                table: "Profesiones",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_Numero",
                table: "Telefonos",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_PersonaCc",
                table: "Telefonos",
                column: "PersonaCc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Profesiones");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
