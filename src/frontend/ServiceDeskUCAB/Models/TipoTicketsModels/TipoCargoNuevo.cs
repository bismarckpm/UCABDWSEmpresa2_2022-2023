namespace ServiceDeskUCAB.Models.TipoTicketsModels
{
    public class TipoCargoNuevo
    {
        public string idTipoCargo { get; set; }
        public int? ordenAprobacion { get; set; }
        public int? minimo_aprobado_nivel { get; set; }
        public int? maximo_Rechazado_nivel { get; set; }



    }
}
