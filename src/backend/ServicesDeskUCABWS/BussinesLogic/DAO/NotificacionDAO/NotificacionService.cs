using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO
{
    public class NotificacionService : INotificacionDAO
    {
        public bool EnviarNotificacion(Empleado empleado, Estado estado)
        {
            throw new System.NotImplementedException();
        }

        public bool EnviarNotificacion(List<Empleado> empleados, Estado estado)
        {
            throw new System.NotImplementedException();
        }
    }
}
