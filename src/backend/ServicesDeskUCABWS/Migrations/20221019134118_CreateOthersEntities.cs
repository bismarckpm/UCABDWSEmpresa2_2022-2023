using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class CreateOthersEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votos_Ticket");

            migrationBuilder.DropColumn(
                name: "fecha_elim",
                table: "Departamentos");

            migrationBuilder.RenameColumn(
                name: "fecha_ult_edic",
                table: "Departamentos",
                newName: "fecha_ultima_edicion");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Tipos_Cargos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nivel_jerarquia",
                table: "Tipos_Cargos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Tipos_Cargos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tipos_Cargos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CargoId",
                table: "Tipos_Cargos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartamentoId",
                table: "Estados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Departamentos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Departamentos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GrupoId",
                table: "Departamentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Departamentos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre_departamental = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantillasNotificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillasNotificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Votos_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    aprobado = table.Column<bool>(type: "bit", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Tickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votos_Tickets_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PlantillaNotificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipos_Estados_PlantillasNotificaciones_PlantillaNotificacionId",
                        column: x => x.PlantillaNotificacionId,
                        principalTable: "PlantillasNotificaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo_EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etiquetas_Tipos_Estados_Tipo_EstadoId",
                        column: x => x.Tipo_EstadoId,
                        principalTable: "Tipos_Estados",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Cargos_CargoId",
                table: "Tipos_Cargos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_DepartamentoId",
                table: "Estados",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_GrupoId",
                table: "Departamentos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_Tipo_EstadoId",
                table: "Etiquetas",
                column: "Tipo_EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Estados_PlantillaNotificacionId",
                table: "Tipos_Estados",
                column: "PlantillaNotificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_TicketId",
                table: "Votos_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_UsuarioId",
                table: "Votos_Tickets",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Grupos_GrupoId",
                table: "Departamentos",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Departamentos_DepartamentoId",
                table: "Estados",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipos_Cargos_Cargos_CargoId",
                table: "Tipos_Cargos",
                column: "CargoId",
                principalTable: "Cargos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Grupos_GrupoId",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Departamentos_DepartamentoId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipos_Cargos_Cargos_CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Votos_Tickets");

            migrationBuilder.DropTable(
                name: "Tipos_Estados");

            migrationBuilder.DropTable(
                name: "PlantillasNotificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Tipos_Cargos_CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.DropIndex(
                name: "IX_Estados_DepartamentoId",
                table: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_GrupoId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Tipos_Cargos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Departamentos");

            migrationBuilder.RenameColumn(
                name: "fecha_ultima_edicion",
                table: "Departamentos",
                newName: "fecha_ult_edic");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Tipos_Cargos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "nivel_jerarquia",
                table: "Tipos_Cargos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Tipos_Cargos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Tipos_Cargos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Departamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Departamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_elim",
                table: "Departamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Votos_Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    aprobado = table.Column<bool>(type: "bit", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votos_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votos_Ticket_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votos_Ticket_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Ticket_TicketId",
                table: "Votos_Ticket",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Ticket_UsuarioId",
                table: "Votos_Ticket",
                column: "UsuarioId");
        }
    }
}
