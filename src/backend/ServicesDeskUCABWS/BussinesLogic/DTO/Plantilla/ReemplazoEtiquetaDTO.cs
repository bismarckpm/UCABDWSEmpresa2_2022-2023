using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla
{
    public class ReemplazoEtiquetaDTO
    {
        public Ticket ticket { get; set; }

        public PlantillaNotificacionDTO plantilla { get; set; }

        public ReemplazoEtiquetaDTO() { }

    }
}
