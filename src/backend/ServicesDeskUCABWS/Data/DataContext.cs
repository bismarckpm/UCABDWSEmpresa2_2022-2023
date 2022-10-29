using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Persistence.Entities;

namespace ServicesDeskUCABWS.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Creacion de los DbSeT
        public DbSet<Departamento> Departamentos { get; set; }
     
        public DbSet<Grupo> Grupos { get; set; }
     

        
    }
}
