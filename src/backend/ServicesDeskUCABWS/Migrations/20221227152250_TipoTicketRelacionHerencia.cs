using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class TipoTicketRelacionHerencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Tipos_Tickets",
                newName: "Discriminator");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("8c8a156b-7383-4610-8539-30ccf7298164"),
                column: "fecha_creacion",
                value: new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Tipos_Tickets",
                newName: "tipo");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("8c8a156b-7383-4610-8539-30ccf7298164"),
                column: "fecha_creacion",
                value: new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
