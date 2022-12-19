using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO
{
    public class PrioridadSolicitudDTO
    {
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string estado { get; set; }
    }
}
