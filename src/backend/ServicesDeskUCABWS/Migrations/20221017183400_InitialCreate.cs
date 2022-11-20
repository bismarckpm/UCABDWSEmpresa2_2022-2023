using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ult_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_elim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_descripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nivel_jerarquia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ult_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ult_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_elim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    primer_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundo_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primer_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundo_apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    genero = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartamentoTipo_Ticket",
                columns: table => new
                {
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo_TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoTipo_Ticket", x => new { x.DepartamentoId, x.Tipo_TicketId });
                    table.ForeignKey(
                        name: "FK_DepartamentoTipo_Ticket_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentoTipo_Ticket_Tipos_Tickets_Tipo_TicketId",
                        column: x => x.Tipo_TicketId,
                        principalTable: "Tipos_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flujos_Aprobaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrdenAprobacion = table.Column<int>(type: "int", nullable: false),
                    Tipo_CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo_TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flujos_Aprobaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flujos_Aprobaciones_Tipos_Cargos_Tipo_CargoId",
                        column: x => x.Tipo_CargoId,
                        principalTable: "Tipos_Cargos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flujos_Aprobaciones_Tipos_Tickets_Tipo_TicketId",
                        column: x => x.Tipo_TicketId,
                        principalTable: "Tipos_Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrioridadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo_TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Prioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                        column: x => x.Tipo_TicketId,
                        principalTable: "Tipos_Tickets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Votos_Ticket",
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
                name: "IX_DepartamentoTipo_Ticket_Tipo_TicketId",
                table: "DepartamentoTipo_Ticket",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Aprobaciones_Tipo_CargoId",
                table: "Flujos_Aprobaciones",
                column: "Tipo_CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Aprobaciones_Tipo_TicketId",
                table: "Flujos_Aprobaciones",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EstadoId",
                table: "Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadId",
                table: "Tickets",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tipo_TicketId",
                table: "Tickets",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Ticket_TicketId",
                table: "Votos_Ticket",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Ticket_UsuarioId",
                table: "Votos_Ticket",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentoTipo_Ticket");

            migrationBuilder.DropTable(
                name: "Flujos_Aprobaciones");

            migrationBuilder.DropTable(
                name: "Votos_Ticket");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Tipos_Cargos");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Tipos_Tickets");
        }
    }
}
