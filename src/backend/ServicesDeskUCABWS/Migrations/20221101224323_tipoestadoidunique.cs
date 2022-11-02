using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class tipoestadoidunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlantillasNotificaciones_TipoEstadoId",
                table: "PlantillasNotificaciones");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasNotificaciones_TipoEstadoId",
                table: "PlantillasNotificaciones",
                column: "TipoEstadoId",
                unique: true,
                filter: "[TipoEstadoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PlantillasNotificaciones_TipoEstadoId",
                table: "PlantillasNotificaciones");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasNotificaciones_TipoEstadoId",
                table: "PlantillasNotificaciones",
                column: "TipoEstadoId");
        }
    }
}
