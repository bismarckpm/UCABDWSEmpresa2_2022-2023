using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public interface INotificacion
    {
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla);
        public Boolean EnviarCorreo(PlantillaNotificacionDTO plantilla, string correoDestino);
    }
}
