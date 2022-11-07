using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class modificacion_entidad_ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_EmpleadoId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Tickets",
                newName: "empleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EmpleadoId",
                table: "Tickets",
                newName: "IX_Tickets_empleadoId");

            migrationBuilder.AddColumn<Guid>(
                name: "clienteId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_clienteId",
                table: "Tickets",
                column: "clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_clienteId",
                table: "Tickets",
                column: "clienteId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_empleadoId",
                table: "Tickets",
                column: "empleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_clienteId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_empleadoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_clienteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "empleadoId",
                table: "Tickets",
                newName: "EmpleadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_empleadoId",
                table: "Tickets",
                newName: "IX_Tickets_EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_EmpleadoId",
                table: "Tickets",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
