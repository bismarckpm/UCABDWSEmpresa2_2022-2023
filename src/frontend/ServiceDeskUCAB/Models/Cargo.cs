
namespace ServiceDeskUCAB.Models
{
    public class Cargo
    {
        public Guid Id { get; set; }

        public string nombre_departamental { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public Cargo(string nombre_departamenta, string descripcion)
        {
            Id = Guid.NewGuid();
            nombre_departamental = nombre_departamenta;
            this.descripcion = descripcion;
        }

        public Cargo()
        {

        }
    }
}
