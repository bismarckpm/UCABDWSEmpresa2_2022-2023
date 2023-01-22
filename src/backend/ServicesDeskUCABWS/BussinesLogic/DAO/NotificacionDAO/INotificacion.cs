using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public interface INotificacion
    {
        public String ReemplazoEtiqueta(Ticket ticket, PlantillaNotificacionDTO Plantilla);
        public Task EnviarCorreo(PlantillaNotificacionDTO plantilla, string correoDestino);

        public Task<bool> EnviarNotificacion(Ticket ticket, TipoNotificacion Estado, List<Empleado> ListaEmpleados, IDataContext contexto);
    }
}
