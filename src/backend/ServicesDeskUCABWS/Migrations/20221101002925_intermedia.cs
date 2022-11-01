using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class intermedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiquetaTipo_Estado");

            migrationBuilder.CreateTable(
                name: "EtiquetasTipoEstados",
                columns: table => new
                {
                    etiquetaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoEstadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetasTipoEstados", x => new { x.etiquetaID, x.tipoEstadoID });
                    table.ForeignKey(
                        name: "FK_EtiquetasTipoEstados_Etiquetas_etiquetaID",
                        column: x => x.etiquetaID,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetasTipoEstados_Tipo_Estado_tipoEstadoID",
                        column: x => x.tipoEstadoID,
                        principalTable: "Tipo_Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetasTipoEstados_tipoEstadoID",
                table: "EtiquetasTipoEstados",
                column: "tipoEstadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtiquetasTipoEstados");

            migrationBuilder.CreateTable(
                name: "EtiquetaTipo_Estado",
                columns: table => new
                {
                    EtiquetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListaEstadosrelacionadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaTipo_Estado", x => new { x.EtiquetaId, x.ListaEstadosrelacionadosId });
                    table.ForeignKey(
                        name: "FK_EtiquetaTipo_Estado_Etiquetas_EtiquetaId",
                        column: x => x.EtiquetaId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaTipo_Estado_Tipo_Estado_ListaEstadosrelacionadosId",
                        column: x => x.ListaEstadosrelacionadosId,
                        principalTable: "Tipo_Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaTipo_Estado_ListaEstadosrelacionadosId",
                table: "EtiquetaTipo_Estado",
                column: "ListaEstadosrelacionadosId");
        }
    }
}
