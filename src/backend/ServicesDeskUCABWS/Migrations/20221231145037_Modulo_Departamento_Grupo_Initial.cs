using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class Modulo_Departamento_Grupo_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("8c8a156b-7383-4610-8539-30ccf7298164"),
                column: "fecha_creacion",
                value: new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("8c8a156b-7383-4610-8539-30ccf7298164"),
                column: "fecha_creacion",
                value: new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
