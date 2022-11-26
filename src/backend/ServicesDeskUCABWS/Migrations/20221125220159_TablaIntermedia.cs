using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class TablaIntermedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Tipos_Tickets_Tipo_TicketId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_Tipo_TicketId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Tipo_TicketId",
                table: "Departamentos");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "DepartamentoTipo_Ticket",
                columns: table => new
                {
                    Departamentosid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo_TicketsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoTipo_Ticket", x => new { x.Departamentosid, x.Tipo_TicketsId });
                    table.ForeignKey(
                        name: "FK_DepartamentoTipo_Ticket_Departamentos_Departamentosid",
                        column: x => x.Departamentosid,
                        principalTable: "Departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentoTipo_Ticket_Tipos_Tickets_Tipo_TicketsId",
                        column: x => x.Tipo_TicketsId,
                        principalTable: "Tipos_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_nombre",
                table: "Grupos",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_nombre",
                table: "Departamentos",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoTipo_Ticket_Tipo_TicketsId",
                table: "DepartamentoTipo_Ticket",
                column: "Tipo_TicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentoTipo_Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_nombre",
                table: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_nombre",
                table: "Departamentos");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Estados",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "Tipo_TicketId",
                table: "Departamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Tipo_TicketId",
                table: "Departamentos",
                column: "Tipo_TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Tipos_Tickets_Tipo_TicketId",
                table: "Departamentos",
                column: "Tipo_TicketId",
                principalTable: "Tipos_Tickets",
                principalColumn: "Id");
        }
    }
}
