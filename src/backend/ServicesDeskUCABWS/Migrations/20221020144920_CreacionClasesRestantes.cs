using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class CreacionClasesRestantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etiquetas_Tipos_Estados_Tipo_EstadoId",
                table: "Etiquetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipos_Estados_PlantillasNotificaciones_PlantillaNotificacionId",
                table: "Tipos_Estados");

            migrationBuilder.DropIndex(
                name: "IX_Etiquetas_Tipo_EstadoId",
                table: "Etiquetas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos_Estados",
                table: "Tipos_Estados");

            migrationBuilder.DropColumn(
                name: "rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Tipo_EstadoId",
                table: "Etiquetas");

            migrationBuilder.RenameTable(
                name: "Tipos_Estados",
                newName: "Tipo_Estado");

            migrationBuilder.RenameColumn(
                name: "genero",
                table: "Usuarios",
                newName: "gender");

            migrationBuilder.RenameIndex(
                name: "IX_Tipos_Estados_PlantillaNotificacionId",
                table: "Tipo_Estado",
                newName: "IX_Tipo_Estado_PlantillaNotificacionId");

            migrationBuilder.AlterColumn<int>(
                name: "aprobado",
                table: "Votos_Tickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpleadoId",
                table: "Votos_Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_nombre",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_apellido",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "primer_nombre",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "primer_apellido",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "correo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroDeCuentasBloqueadas",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tipo",
                table: "Tipos_Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Tipos_Tickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tipos_Tickets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Minimo_Aprobado",
                table: "Tipos_Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tickets",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Tipo_TicketId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PrioridadId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Departamento_DestinoId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmpleadoId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Familia_TicketId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDEstado",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Ticket_PadreId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "titulo",
                table: "Tickets",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Prioridades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Prioridades",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Estados",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Estados",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Estado_PadreId",
                table: "Estados",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo_Estado",
                table: "Tipo_Estado",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bitacora_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacora_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitacora_Tickets_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacora_Tickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtiquetaTipo_Estado",
                columns: table => new
                {
                    EtiquetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListaEstadosrelacionadosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtiquetaTipo_Estado", x => new { x.EtiquetaId, x.ListaEstadosrelacionadosId });
                    table.ForeignKey(
                        name: "FK_EtiquetaTipo_Estado_Etiquetas_EtiquetaId",
                        column: x => x.EtiquetaId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtiquetaTipo_Estado_Tipo_Estado_ListaEstadosrelacionadosId",
                        column: x => x.ListaEstadosrelacionadosId,
                        principalTable: "Tipo_Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Familia_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia_Tickets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_EmpleadoId",
                table: "Votos_Tickets",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Departamento_DestinoId",
                table: "Tickets",
                column: "Departamento_DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmpleadoId",
                table: "Tickets",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Familia_TicketId",
                table: "Tickets",
                column: "Familia_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Ticket_PadreId",
                table: "Tickets",
                column: "Ticket_PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Estado_PadreId",
                table: "Estados",
                column: "Estado_PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Tickets_EstadoId",
                table: "Bitacora_Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Tickets_TicketId",
                table: "Bitacora_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaTipo_Estado_ListaEstadosrelacionadosId",
                table: "EtiquetaTipo_Estado",
                column: "ListaEstadosrelacionadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Tipo_Estado_Estado_PadreId",
                table: "Estados",
                column: "Estado_PadreId",
                principalTable: "Tipo_Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Departamentos_Departamento_DestinoId",
                table: "Tickets",
                column: "Departamento_DestinoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Familia_Tickets_Familia_TicketId",
                table: "Tickets",
                column: "Familia_TicketId",
                principalTable: "Familia_Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tickets_Ticket_PadreId",
                table: "Tickets",
                column: "Ticket_PadreId",
                principalTable: "Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                table: "Tickets",
                column: "Tipo_TicketId",
                principalTable: "Tipos_Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Usuarios_EmpleadoId",
                table: "Tickets",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipo_Estado_PlantillasNotificaciones_PlantillaNotificacionId",
                table: "Tipo_Estado",
                column: "PlantillaNotificacionId",
                principalTable: "PlantillasNotificaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cargos_CargoId",
                table: "Usuarios",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Tickets_Usuarios_EmpleadoId",
                table: "Votos_Tickets",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Tipo_Estado_Estado_PadreId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Departamentos_Departamento_DestinoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Familia_Tickets_Familia_TicketId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tickets_Ticket_PadreId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Usuarios_EmpleadoId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipo_Estado_PlantillasNotificaciones_PlantillaNotificacionId",
                table: "Tipo_Estado");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cargos_CargoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Tickets_Usuarios_EmpleadoId",
                table: "Votos_Tickets");

            migrationBuilder.DropTable(
                name: "Bitacora_Tickets");

            migrationBuilder.DropTable(
                name: "EtiquetaTipo_Estado");

            migrationBuilder.DropTable(
                name: "Familia_Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Votos_Tickets_EmpleadoId",
                table: "Votos_Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Departamento_DestinoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EmpleadoId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Familia_TicketId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Ticket_PadreId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Estados_Estado_PadreId",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo_Estado",
                table: "Tipo_Estado");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Votos_Tickets");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NumeroDeCuentasBloqueadas",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Minimo_Aprobado",
                table: "Tipos_Tickets");

            migrationBuilder.DropColumn(
                name: "Departamento_DestinoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Familia_TicketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IDEstado",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Ticket_PadreId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "titulo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Estado_PadreId",
                table: "Estados");

            migrationBuilder.RenameTable(
                name: "Tipo_Estado",
                newName: "Tipos_Estados");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "Usuarios",
                newName: "genero");

            migrationBuilder.RenameIndex(
                name: "IX_Tipo_Estado_PlantillaNotificacionId",
                table: "Tipos_Estados",
                newName: "IX_Tipos_Estados_PlantillaNotificacionId");

            migrationBuilder.AlterColumn<bool>(
                name: "aprobado",
                table: "Votos_Tickets",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "segundo_nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "segundo_apellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "primer_nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "primer_apellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "correo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "Tipos_Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Tipos_Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tipos_Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<Guid>(
                name: "Tipo_TicketId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrioridadId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Prioridades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Prioridades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "Tipo_EstadoId",
                table: "Etiquetas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos_Estados",
                table: "Tipos_Estados",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_Tipo_EstadoId",
                table: "Etiquetas",
                column: "Tipo_EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Etiquetas_Tipos_Estados_Tipo_EstadoId",
                table: "Etiquetas",
                column: "Tipo_EstadoId",
                principalTable: "Tipos_Estados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Prioridades_PrioridadId",
                table: "Tickets",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                table: "Tickets",
                column: "Tipo_TicketId",
                principalTable: "Tipos_Tickets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipos_Estados_PlantillasNotificaciones_PlantillaNotificacionId",
                table: "Tipos_Estados",
                column: "PlantillaNotificacionId",
                principalTable: "PlantillasNotificaciones",
                principalColumn: "Id");
        }
    }
}
