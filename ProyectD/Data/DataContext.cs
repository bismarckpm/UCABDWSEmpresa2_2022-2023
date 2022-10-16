using Microsoft.EntityFrameworkCore;
using ProyectD.Models;

namespace ProyectD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Creacion de los DbSeT
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tipo_Ticket> Tipos_Tickets { get; set; }
        public DbSet<Tipo_Cargo> Tipos_Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Flujo_Aprobacion> Flujos_Aprobaciones { get; set; }
    
    }
}
