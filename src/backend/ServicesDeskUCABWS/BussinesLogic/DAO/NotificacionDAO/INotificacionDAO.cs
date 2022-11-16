using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public interface INotificacionDAO
    {
        bool EnviarNotificacion(Empleado empleado, Estado estado);
        bool EnviarNotificacion(List<Empleado> empleados, Estado estado);
    }
}
