using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminPacientes.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObraSociales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraSociales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Apellido = table.Column<string>(maxLength: 30, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: true),
                    FechaBaja = table.Column<DateTime>(nullable: true),
                    NumeroAfiliado = table.Column<int>(nullable: true),
                    ObraSocialId = table.Column<int>(nullable: true),
                    Telefono = table.Column<int>(nullable: true),
                    Parentezco = table.Column<string>(nullable: true),
                    EstadoCivil = table.Column<string>(nullable: true),
                    Ocupacion = table.Column<string>(nullable: true),
                    PacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_ObraSociales_ObraSocialId",
                        column: x => x.ObraSocialId,
                        principalTable: "ObraSociales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calle = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Piso = table.Column<int>(nullable: false),
                    Dpto = table.Column<string>(nullable: true),
                    CodigoPostal = table.Column<int>(nullable: false),
                    Localidad = table.Column<string>(nullable: true),
                    Provincia = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    PersonaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaAtencion = table.Column<DateTime>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_PersonaId",
                table: "Domicilios",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ObraSocialId",
                table: "Personas",
                column: "ObraSocialId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PacienteId",
                table: "Personas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_PacienteId",
                table: "Registros",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "ObraSociales");
        }
    }
}
