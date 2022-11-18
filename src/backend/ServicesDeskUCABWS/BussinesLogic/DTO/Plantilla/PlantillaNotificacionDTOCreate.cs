using System;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla

{
    public class PlantillaNotificacionDTOCreate
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
