using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.Data
{
    public interface IDataContext
    {
        DbContext DbContext { get; }

        public DbSet<Tipo_Cargo> Tipos_Cargos { get; set; }

        public DbSet<Cargo> Cargos { get; set; }
    }
}
