using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class porfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tipos_Cargos_Cargos_CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Tipos_Cargos_CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.AddColumn<Guid>(
                name: "id_tipo",
                table: "Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_id_tipo",
                table: "Cargos",
                column: "id_tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargos_Tipos_Cargos_id_tipo",
                table: "Cargos",
                column: "id_tipo",
                principalTable: "Tipos_Cargos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargos_Tipos_Cargos_id_tipo",
                table: "Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Cargos_id_tipo",
                table: "Cargos");

            migrationBuilder.DropColumn(
                name: "id_tipo",
                table: "Cargos");

            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "Tipos_Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Cargos_CargoId",
                table: "Tipos_Cargos",
                column: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipos_Cargos_Cargos_CargoId",
                table: "Tipos_Cargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");
        }
    }
}
