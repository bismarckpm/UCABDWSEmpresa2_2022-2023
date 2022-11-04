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
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
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
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_descripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ult_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_elim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Minimo_Aprobado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GrupoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Estado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PlantillaNotificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipo_Estado_PlantillasNotificaciones_PlantillaNotificacionId",
                        column: x => x.PlantillaNotificacionId,
                        principalTable: "PlantillasNotificaciones",
                        principalColumn: "Id");
                });

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
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado_PadreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estados_Tipo_Estado_Estado_PadreId",
                        column: x => x.Estado_PadreId,
                        principalTable: "Tipo_Estado",
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
                name: "Tipos_Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    nivel_jerarquia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ult_edic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Cargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipos_Cargos_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    primer_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    segundo_nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    primer_apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    segundo_apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_ultima_edicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDeCuentasBloqueadas = table.Column<int>(type: "int", nullable: true),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id");
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
                    titulo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_eliminacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDEstado = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrioridadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo_TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Departamento_DestinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Familia_TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ticket_PadreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Departamentos_Departamento_DestinoId",
                        column: x => x.Departamento_DestinoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Familia_Tickets_Familia_TicketId",
                        column: x => x.Familia_TicketId,
                        principalTable: "Familia_Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Prioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Tickets_Ticket_PadreId",
                        column: x => x.Ticket_PadreId,
                        principalTable: "Tickets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Tipos_Tickets_Tipo_TicketId",
                        column: x => x.Tipo_TicketId,
                        principalTable: "Tipos_Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

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
                name: "Votos_Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    aprobado = table.Column<int>(type: "int", nullable: false),
                    comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        name: "FK_Votos_Tickets_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Votos_Tickets_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Tickets_EstadoId",
                table: "Bitacora_Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacora_Tickets_TicketId",
                table: "Bitacora_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_DepartamentoId",
                table: "Cargos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_GrupoId",
                table: "Departamentos",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentoTipo_Ticket_Tipo_TicketId",
                table: "DepartamentoTipo_Ticket",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_DepartamentoId",
                table: "Estados",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Estado_PadreId",
                table: "Estados",
                column: "Estado_PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_EtiquetaTipo_Estado_ListaEstadosrelacionadosId",
                table: "EtiquetaTipo_Estado",
                column: "ListaEstadosrelacionadosId");

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Aprobaciones_Tipo_CargoId",
                table: "Flujos_Aprobaciones",
                column: "Tipo_CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Aprobaciones_Tipo_TicketId",
                table: "Flujos_Aprobaciones",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Departamento_DestinoId",
                table: "Tickets",
                column: "Departamento_DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmpleadoId",
                table: "Tickets",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EstadoId",
                table: "Tickets",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Familia_TicketId",
                table: "Tickets",
                column: "Familia_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PrioridadId",
                table: "Tickets",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Ticket_PadreId",
                table: "Tickets",
                column: "Ticket_PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Tipo_TicketId",
                table: "Tickets",
                column: "Tipo_TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Estado_PlantillaNotificacionId",
                table: "Tipo_Estado",
                column: "PlantillaNotificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipos_Cargos_CargoId",
                table: "Tipos_Cargos",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoId",
                table: "Usuarios",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_EmpleadoId",
                table: "Votos_Tickets",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_TicketId",
                table: "Votos_Tickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Votos_Tickets_UsuarioId",
                table: "Votos_Tickets",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacora_Tickets");

            migrationBuilder.DropTable(
                name: "DepartamentoTipo_Ticket");

            migrationBuilder.DropTable(
                name: "EtiquetaTipo_Estado");

            migrationBuilder.DropTable(
                name: "Flujos_Aprobaciones");

            migrationBuilder.DropTable(
                name: "Votos_Tickets");

            migrationBuilder.DropTable(
                name: "Etiquetas");

            migrationBuilder.DropTable(
                name: "Tipos_Cargos");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Familia_Tickets");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Tipos_Tickets");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tipo_Estado");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "PlantillasNotificaciones");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Grupos");
        }
    }
}
