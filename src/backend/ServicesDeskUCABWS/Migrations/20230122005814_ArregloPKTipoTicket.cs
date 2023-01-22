using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class ArregloPKTipoTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Flujos_Aprobaciones",
                table: "Flujos_Aprobaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flujos_Aprobaciones",
                table: "Flujos_Aprobaciones",
                columns: new[] { "IdTicket", "IdCargo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Flujos_Aprobaciones",
                table: "Flujos_Aprobaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flujos_Aprobaciones",
                table: "Flujos_Aprobaciones",
                column: "IdTicket");
        }
    }
}
