namespace ServiceDeskUCAB.Models
{
    public class TipoFlujo
    {
        public string IdCargo { get; set; }
        public int? OrdenAprobacion { get; set; }

        public int? minimo_aprobado_nivel { get; set; }

        public int? maximo_rechazado_nivel { get; set; }

        public TipoCargo? Tipo_Cargo { get; set; }
    }
}
