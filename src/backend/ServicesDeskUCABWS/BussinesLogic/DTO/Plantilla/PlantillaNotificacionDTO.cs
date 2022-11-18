using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla
{
    public class PlantillaNotificacionDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public TipoEstadoDTO TipoEstado { get; set; }
    }
}
