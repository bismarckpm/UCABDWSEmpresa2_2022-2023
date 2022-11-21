using Microsoft.EntityFrameworkCore;
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

        public DataContext()
        {
        }

        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flujo_Aprobacion>().HasKey(x => new { x.IdTicket, x.IdTipo_cargo });
            modelBuilder.Entity<Votos_Ticket>().HasKey(x => new { x.IdUsuario, x.IdTicket });
        }

        //Creacion de los DbSeT
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
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
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<PlantillaNotificacion> PlantillasNotificaciones { get; set; }
        public DbSet<Tipo_Estado> Tipos_Estados { get; set; }
        public DbSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public DbSet<Familia_Ticket> Familia_Tickets { get; set; }
        public DbSet<Tipo_Estado> Tipo_Estados { get; set; }

        public DbContext DbContext { get
            {
                return this;
            }
        }
    }
}
