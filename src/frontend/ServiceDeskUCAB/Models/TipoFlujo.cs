namespace ServiceDeskUCAB.Models
{
    public class TipoFlujo
    {
        public Guid IdCargo { get; set; }
        public int? OrdenAprobacion { get; set; }

        public int? Minimo_Aprobado { get; set; }

        public int? Maximo_Rechazado { get; set; }

        public TipoCargo? Tipo_Cargo { get; set; }
    }
}
