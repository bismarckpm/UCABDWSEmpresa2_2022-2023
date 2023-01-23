using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System.Linq;

namespace ServicesDeskUCABWS.Entities
{
    public enum TipoNotificacion
    {
        Aprobado,
        SiendoProcesado,
        Pendiente,
        Normal
    }

    public abstract class Notificacion
    {
        public abstract List<Empleado> ObtenerUsuariosAEnviarCorreo(Ticket ticket, List<Empleado> EmpleadosVotantes, IDataContext contexto);

        public static Notificacion GetInstance(TipoNotificacion tipoNotificacion)
        {
            if(tipoNotificacion == TipoNotificacion.Pendiente){
                return new NotificacionPendiente();
            } else if (tipoNotificacion == TipoNotificacion.Aprobado){
                return new NotificacionAprobado();
            } else if (tipoNotificacion == TipoNotificacion.SiendoProcesado){
                return new NotificacionSiendoProcesado();
            } else if (tipoNotificacion == TipoNotificacion.Normal){
                return new NotificacionNormal();
            }
            return null;
        }
    }

    public class NotificacionAprobado: Notificacion 
    {
        public override List<Empleado> ObtenerUsuariosAEnviarCorreo(Ticket ticket, List<Empleado> EmpleadosVotantes, IDataContext contexto)
        {
            return new List<Empleado>() { ticket.Emisor};
        }
    }

    public class NotificacionPendiente : Notificacion
    {
        public override List<Empleado> ObtenerUsuariosAEnviarCorreo(Ticket ticket, List<Empleado> EmpleadosVotantes, IDataContext contexto)
        {
            return EmpleadosVotantes;
        }
    }

    public class NotificacionSiendoProcesado : Notificacion
    {
        public override List<Empleado> ObtenerUsuariosAEnviarCorreo(Ticket ticket, List<Empleado> EmpleadosVotantes, IDataContext contexto)
        {
            return contexto.Empleados.Include(x => x.Cargo).ThenInclude(x => x.Departamento).Where(x => x.Cargo.Departamento.id == ticket.Departamento_Destino.id).ToList(); 
        }
    }

    public class NotificacionNormal : Notificacion
    {
        public override List<Empleado> ObtenerUsuariosAEnviarCorreo(Ticket ticket, List<Empleado> EmpleadosVotantes, IDataContext contexto)
        {
            return new List<Empleado>() { ticket.Emisor };
        }
    }

}
