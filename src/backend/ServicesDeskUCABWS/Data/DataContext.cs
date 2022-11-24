using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Entities;
using System.Diagnostics.Contracts;
using static ServicesDeskUCABWS.Entities.RolUsuario;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServicesDeskUCABWS.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace ServicesDeskUCABWS.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flujo_Aprobacion>().HasKey(x => new { x.IdTicket, x.IdTipo_cargo });
            modelBuilder.Entity<Votos_Ticket>().HasKey(x => new { x.IdUsuario, x.IdTicket });

            modelBuilder.Entity<Usuario>().HasIndex(u=>u.correo).IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Administrador>("1")
                .HasValue<Empleado>("2")
                .HasValue<Cliente>("3");

            modelBuilder.Entity<RolUsuario>().HasKey(sc => new { sc.UserId, sc.RolId });

            modelBuilder.Entity<RolUsuario>()
                .HasOne<Usuario>(sc => sc.User)
                .WithMany(s => s.Roles)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<RolUsuario>()
                .HasOne<Rol>(sc => sc.Rol)
                .WithMany(s => s.Usuarios)
                .HasForeignKey(sc => sc.RolId);

            modelBuilder.Entity<EtiquetaTipoEstado>().HasKey(x => new { x.etiquetaID, x.tipoEstadoID });
            modelBuilder.Entity<PlantillaNotificacion>().HasIndex(u => u.TipoEstadoId).IsUnique();
            modelBuilder.Entity<Departamento>().HasIndex(u => u.nombre).IsUnique();
            modelBuilder.Entity<Grupo>().HasIndex(u => u.nombre).IsUnique();
		}

        
        

        //Creacion de los DbSeT

        public DbSet<RolUsuario> RolUsuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipo_Ticket> Tipos_Tickets { get; set; }
        public DbSet<Tipo_Cargo> Tipos_Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Flujo_Aprobacion> Flujos_Aprobaciones { get; set; }
        public DbSet<Votos_Ticket> Votos_Tickets { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Etiqueta> Etiquetas { get; set; }
        public DbSet<EtiquetaTipoEstado> EtiquetasTipoEstados { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<PlantillaNotificacion> PlantillasNotificaciones { get; set; }
        public DbSet<Tipo_Estado> Tipos_Estados { get; set; }
        public DbSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public DbSet<Familia_Ticket> Familia_Tickets { get; set; }
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
    }
}
