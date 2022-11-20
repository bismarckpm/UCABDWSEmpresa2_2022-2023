using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prioridad>().HasKey(x => new { x.Id });
            modelBuilder.Entity<Prioridad>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Prioridad>().HasCheckConstraint("prioridad_nombre_chk", "nombre = 'URGENTE' or nombre = 'ALTA' or nombre = 'MEDIA' or nombre = 'BAJA'");
            modelBuilder.Entity<Prioridad>().HasCheckConstraint("prioridad_estado_chk", "estado = 'DISPONIBLE' or estado = 'NO DISPONIBLE'");
            modelBuilder.Entity<Prioridad>().HasIndex(p => p.nombre).IsUnique();
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

        public DbContext DbContext => throw new System.NotImplementedException();
    }
}
