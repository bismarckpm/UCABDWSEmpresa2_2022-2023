using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;

namespace ServicesDeskUCABWS.Entities
{
    
    public class TipoTicket_FlujoNoAprobacion : Tipo_Ticket
    {
        public TipoTicket_FlujoNoAprobacion(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo){ }
        public TipoTicket_FlujoNoAprobacion(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado){ }
        public TipoTicket_FlujoNoAprobacion() { }

        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                return contexto.Empleados
                    .Where(s => s.Cargo.Departamento.id == ticket.Departamento_Destino.id)
                    .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            return new List<Cargo>();
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket)
        {
            return new List<Empleado>();
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado(ticket, "Pendiente", _dataContext);

                ticket.CambiarEstado(ticket, "Aprobado", _dataContext);
                ticket.EnviarNotificacion(ticket, "Aprobado", ListaEmpleados, _dataContext, notificacion, plantilla);

                ticket.CambiarEstado(ticket, "Siendo Procesado", _dataContext);
                ticket.EnviarNotificacion(ticket, "Siendo Procesado", ListaEmpleados, _dataContext, notificacion, plantilla);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public override string ObtenerTipoAprobacion()
        {
            return "Modelo_No_Aprobacion";
        }

        public override string VerificarVotacion(Guid idTicket, IDataContext contexto)
        {
            return "Aprobado";
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            return "Aprobado";
        }

        public override int ContarVotosAFavor(Guid idTicket, IDataContext contexto)
        {
            return 0;
        }

        public override int ContarVotosEnContra(Guid idTicket, IDataContext contexto)
        {
            return 0;
        }
    }
    
}
