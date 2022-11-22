namespace ServiceDeskUCAB.Models.TipoTicketsModels
{
    public class FlujoAprobacion
    {
        public string IdTipoCargo { get; set; }
        public int? OrdenAprobacion { get; set; }
        public int? Minimo_aprobado_nivel { get; set; }
        public int? Maximo_Rechazado_nivel { get; set; }
    }
}
