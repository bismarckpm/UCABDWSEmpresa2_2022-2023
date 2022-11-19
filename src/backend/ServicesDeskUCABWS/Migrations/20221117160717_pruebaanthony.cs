using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class pruebaanthony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.CreateTable(
                name: "Prioridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_descripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridad", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prioridad_Id",
                table: "Prioridad",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridad_PrioridadId",
                table: "Tickets",
                column: "PrioridadId",
                principalTable: "Prioridad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridad_PrioridadId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Prioridad");

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_descripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
