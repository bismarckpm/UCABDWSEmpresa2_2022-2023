using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Entities;
using System.Diagnostics.Contracts;


namespace ServicesDeskUCABWS.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

       

        //Creacion de los DbSeT

        public DbSet<Tipo_Cargo> Tipos_Cargos { get; set; }
       
        public DbSet<Cargo> Cargos { get; set; }
       
        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
    }
}
