using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class EliminacionTipoEstadoSobrante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tipo_Estado_Estado_PadreId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetasTipoEstados_Tipo_Estado_tipoEstadoID",
                table: "EtiquetasTipoEstados");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantillasNotificaciones_Tipo_Estado_TipoEstadoId",
                table: "PlantillasNotificaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo_Estado",
                table: "Tipo_Estado");

            migrationBuilder.RenameTable(
                name: "Tipo_Estado",
                newName: "Tipos_Estados");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos_Estados",
                table: "Tipos_Estados",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Tipos_Estados_Estado_PadreId",
                table: "Estados",
                column: "Estado_PadreId",
                principalTable: "Tipos_Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetasTipoEstados_Tipos_Estados_tipoEstadoID",
                table: "EtiquetasTipoEstados",
                column: "tipoEstadoID",
                principalTable: "Tipos_Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantillasNotificaciones_Tipos_Estados_TipoEstadoId",
                table: "PlantillasNotificaciones",
                column: "TipoEstadoId",
                principalTable: "Tipos_Estados",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tipos_Estados_Estado_PadreId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_EtiquetasTipoEstados_Tipos_Estados_tipoEstadoID",
                table: "EtiquetasTipoEstados");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantillasNotificaciones_Tipos_Estados_TipoEstadoId",
                table: "PlantillasNotificaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos_Estados",
                table: "Tipos_Estados");

            migrationBuilder.RenameTable(
                name: "Tipos_Estados",
                newName: "Tipo_Estado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo_Estado",
                table: "Tipo_Estado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Tipo_Estado_Estado_PadreId",
                table: "Estados",
                column: "Estado_PadreId",
                principalTable: "Tipo_Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EtiquetasTipoEstados_Tipo_Estado_tipoEstadoID",
                table: "EtiquetasTipoEstados",
                column: "tipoEstadoID",
                principalTable: "Tipo_Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantillasNotificaciones_Tipo_Estado_TipoEstadoId",
                table: "PlantillasNotificaciones",
                column: "TipoEstadoId",
                principalTable: "Tipo_Estado",
                principalColumn: "Id");
        }
    }
}
