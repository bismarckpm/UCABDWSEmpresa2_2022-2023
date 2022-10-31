using System;

namespace ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla
{
    public class PlantillaNotificacionUpdateDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Guid? TipoEstadoId { get; set; }
    }
}
