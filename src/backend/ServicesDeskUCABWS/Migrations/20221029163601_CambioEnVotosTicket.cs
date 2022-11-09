using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class CambioEnVotosTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votos_Tickets",
                table: "Votos_Tickets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Votos_Tickets",
                newName: "IdTicket");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUsuario",
                table: "Votos_Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votos_Tickets",
                table: "Votos_Tickets",
                columns: new[] { "IdUsuario", "IdTicket" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Votos_Tickets",
                table: "Votos_Tickets");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Votos_Tickets");

            migrationBuilder.RenameColumn(
                name: "IdTicket",
                table: "Votos_Tickets",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votos_Tickets",
                table: "Votos_Tickets",
                column: "Id");
        }
    }
}
