using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public interface INotificacion
    {
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla);
        public Task EnviarCorreo(PlantillaNotificacionDTO plantilla, string correoDestino);
    }
}
