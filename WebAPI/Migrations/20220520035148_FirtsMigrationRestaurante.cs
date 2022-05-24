using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIMD.Migrations
{
    public partial class FirtsMigrationRestaurante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteItems",
                columns: table => new
                {
                    ClientelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteItems", x => x.ClientelId);
                });

            migrationBuilder.CreateTable(
                name: "MesaItems",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reservada = table.Column<bool>(type: "bit", nullable: false),
                    Puestos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaItems", x => x.MesaId);
                });

            migrationBuilder.CreateTable(
                name: "MeseroItems",
                columns: table => new
                {
                    MeseroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Antiguedad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeseroItems", x => x.MeseroId);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorItems",
                columns: table => new
                {
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Antiguedad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorItems", x => x.SupervisorId);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturaItems",
                columns: table => new
                {
                    DetalleFacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturaItems", x => x.DetalleFacturaId);
                    table.ForeignKey(
                        name: "FK_DetalleFacturaItems_SupervisorItems_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "SupervisorItems",
                        principalColumn: "SupervisorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaItems",
                columns: table => new
                {
                    FacturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DetalleFacturaId = table.Column<int>(type: "int", nullable: false),
                    MesaId = table.Column<int>(type: "int", nullable: false),
                    MeseroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaItems", x => x.FacturaId);
                    table.ForeignKey(
                        name: "FK_FacturaItems_ClienteItems_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteItems",
                        principalColumn: "ClientelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaItems_DetalleFacturaItems_DetalleFacturaId",
                        column: x => x.DetalleFacturaId,
                        principalTable: "DetalleFacturaItems",
                        principalColumn: "DetalleFacturaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaItems_MesaItems_MesaId",
                        column: x => x.MesaId,
                        principalTable: "MesaItems",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaItems_MeseroItems_MeseroId",
                        column: x => x.MeseroId,
                        principalTable: "MeseroItems",
                        principalColumn: "MeseroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFacturaItems_SupervisorId",
                table: "DetalleFacturaItems",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaItems_ClienteId",
                table: "FacturaItems",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaItems_DetalleFacturaId",
                table: "FacturaItems",
                column: "DetalleFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaItems_MesaId",
                table: "FacturaItems",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaItems_MeseroId",
                table: "FacturaItems",
                column: "MeseroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaItems");

            migrationBuilder.DropTable(
                name: "ClienteItems");

            migrationBuilder.DropTable(
                name: "DetalleFacturaItems");

            migrationBuilder.DropTable(
                name: "MesaItems");

            migrationBuilder.DropTable(
                name: "MeseroItems");

            migrationBuilder.DropTable(
                name: "SupervisorItems");
        }
    }
}
