﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServicesDeskUCABWS.Data;

#nullable disable

namespace ServicesDeskUCABWS.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221124134936_porfa")]
    partial class porfa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Bitacora_Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha_Fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.HasIndex("TicketId");

                    b.ToTable("Bitacora_Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_eliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_ultima_edicion")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("id_tipo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre_departamental")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("id_tipo");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Departamento", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Tipo_TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_eliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_ultima_edicion")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("id_grupo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("Tipo_TicketId");

                    b.HasIndex("id_grupo");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Estado_PadreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_ultima_edic")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Estado_PadreId");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Etiqueta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.EtiquetaTipoEstado", b =>
                {
                    b.Property<Guid>("etiquetaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("tipoEstadoID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("etiquetaID", "tipoEstadoID");

                    b.HasIndex("tipoEstadoID");

                    b.ToTable("EtiquetasTipoEstados");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Familia_Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Familia_Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Flujo_Aprobacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrdenAprobacion")
                        .HasColumnType("int");

                    b.Property<Guid?>("Tipo_CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Tipo_TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Tipo_CargoId");

                    b.HasIndex("Tipo_TicketId");

                    b.ToTable("Flujos_Aprobaciones");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Grupo", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_eliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_ultima_edicion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.PlantillaNotificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TipoEstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TipoEstadoId")
                        .IsUnique()
                        .HasFilter("[TipoEstadoId] IS NOT NULL");

                    b.ToTable("PlantillasNotificaciones");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Prioridad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("fecha_descripcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_ultima_edic")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Rol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.RolUsuario", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Departamento_Destinoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EstadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Familia_TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IDEstado")
                        .HasColumnType("int");

                    b.Property<Guid>("PrioridadId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Ticket_PadreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Tipo_TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("clienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid?>("empleadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_eliminacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("Departamento_Destinoid");

                    b.HasIndex("EstadoId");

                    b.HasIndex("Familia_TicketId");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("Ticket_PadreId");

                    b.HasIndex("Tipo_TicketId");

                    b.HasIndex("clienteId");

                    b.HasIndex("empleadoId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_eliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_ult_edic")
                        .HasColumnType("datetime2");

                    b.Property<string>("nivel_jerarquia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tipos_Cargos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tipos_Estados");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Minimo_Aprobado")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_elim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_ult_edic")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tipos_Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("fecha_eliminacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha_nacimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fecha_ultima_edicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primer_apellido")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("primer_nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("segundo_apellido")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("segundo_nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("correo")
                        .IsUnique()
                        .HasFilter("[correo] IS NOT NULL");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Votos_Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmpleadoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("aprobado")
                        .HasColumnType("int");

                    b.Property<string>("comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Votos_Tickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Administrador", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Entities.Usuario");

                    b.Property<int>("NumeroDeCuentasBloqueadas")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("1");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Cliente", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Entities.Usuario");

                    b.HasDiscriminator().HasValue("3");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Empleado", b =>
                {
                    b.HasBaseType("ServicesDeskUCABWS.Entities.Usuario");

                    b.Property<Guid?>("CargoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CargoId");

                    b.HasDiscriminator().HasValue("2");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Bitacora_Ticket", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Estado", "Estado")
                        .WithMany("Bitacora_Tickets")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Entities.Ticket", "Ticket")
                        .WithMany("Bitacora_Tickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Cargo", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Cargo", "tipo")
                        .WithMany("cargos")
                        .HasForeignKey("id_tipo");

                    b.Navigation("tipo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Departamento", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Ticket", null)
                        .WithMany("Departamento")
                        .HasForeignKey("Tipo_TicketId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Grupo", "grupo")
                        .WithMany("departamentos")
                        .HasForeignKey("id_grupo");

                    b.Navigation("grupo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Estado", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Estado", "Estado_Padre")
                        .WithMany()
                        .HasForeignKey("Estado_PadreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado_Padre");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.EtiquetaTipoEstado", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Etiqueta", "etiqueta")
                        .WithMany("etiquetaTipoEstado")
                        .HasForeignKey("etiquetaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Estado", "tipoEstado")
                        .WithMany("etiquetaTipoEstado")
                        .HasForeignKey("tipoEstadoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("etiqueta");

                    b.Navigation("tipoEstado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Flujo_Aprobacion", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Cargo", "Tipo_Cargo")
                        .WithMany()
                        .HasForeignKey("Tipo_CargoId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Ticket", "Tipo_Ticket")
                        .WithMany("Flujo_Aprobacion")
                        .HasForeignKey("Tipo_TicketId");

                    b.Navigation("Tipo_Cargo");

                    b.Navigation("Tipo_Ticket");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.PlantillaNotificacion", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Estado", "TipoEstado")
                        .WithMany()
                        .HasForeignKey("TipoEstadoId");

                    b.Navigation("TipoEstado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.RolUsuario", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Entities.Usuario", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Ticket", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Departamento", "Departamento_Destino")
                        .WithMany()
                        .HasForeignKey("Departamento_Destinoid");

                    b.HasOne("ServicesDeskUCABWS.Entities.Estado", "Estado")
                        .WithMany("ListaTickets")
                        .HasForeignKey("EstadoId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Familia_Ticket", "Familia_Ticket")
                        .WithMany("Lista_Ticket")
                        .HasForeignKey("Familia_TicketId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Prioridad", "Prioridad")
                        .WithMany()
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Entities.Ticket", "Ticket_Padre")
                        .WithMany()
                        .HasForeignKey("Ticket_PadreId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Tipo_Ticket", "Tipo_Ticket")
                        .WithMany()
                        .HasForeignKey("Tipo_TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServicesDeskUCABWS.Entities.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Empleado", "empleado")
                        .WithMany("Lista_Ticket")
                        .HasForeignKey("empleadoId");

                    b.Navigation("Departamento_Destino");

                    b.Navigation("Estado");

                    b.Navigation("Familia_Ticket");

                    b.Navigation("Prioridad");

                    b.Navigation("Ticket_Padre");

                    b.Navigation("Tipo_Ticket");

                    b.Navigation("cliente");

                    b.Navigation("empleado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Votos_Ticket", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Empleado", null)
                        .WithMany("Votos_Ticket")
                        .HasForeignKey("EmpleadoId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Ticket", "Ticket")
                        .WithMany("Votos_Ticket")
                        .HasForeignKey("TicketId");

                    b.HasOne("ServicesDeskUCABWS.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Ticket");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Empleado", b =>
                {
                    b.HasOne("ServicesDeskUCABWS.Entities.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Estado", b =>
                {
                    b.Navigation("Bitacora_Tickets");

                    b.Navigation("ListaTickets");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Etiqueta", b =>
                {
                    b.Navigation("etiquetaTipoEstado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Familia_Ticket", b =>
                {
                    b.Navigation("Lista_Ticket");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Grupo", b =>
                {
                    b.Navigation("departamentos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Rol", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Ticket", b =>
                {
                    b.Navigation("Bitacora_Tickets");

                    b.Navigation("Votos_Ticket");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Cargo", b =>
                {
                    b.Navigation("cargos");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Estado", b =>
                {
                    b.Navigation("etiquetaTipoEstado");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Tipo_Ticket", b =>
                {
                    b.Navigation("Departamento");

                    b.Navigation("Flujo_Aprobacion");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Usuario", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("ServicesDeskUCABWS.Entities.Empleado", b =>
                {
                    b.Navigation("Lista_Ticket");

                    b.Navigation("Votos_Ticket");
                });
#pragma warning restore 612, 618
        }
    }
}
