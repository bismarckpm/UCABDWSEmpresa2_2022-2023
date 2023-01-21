using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic;
using ServicesDeskUCABWS.BussinesLogic.Validaciones.ValidacionesTipoTicket;

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

        public async override Task<bool> CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion)
        {
            try
            {
                ticket.CambiarEstado( "Pendiente", _dataContext);

                ticket.CambiarEstado( "Aprobado", _dataContext);
                //await notificacion.EnviarNotificacion(ticket, TipoNotificacion.Aprobado, ListaEmpleados,_dataContext);

                ticket.CambiarEstado( "Siendo Procesado", _dataContext);
                //await notificacion.EnviarNotificacion(ticket, TipoNotificacion.Aprobado, ListaEmpleados,_dataContext);

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

        public override string VerificarVotacion(Ticket ticekt, IDataContext contexto, INotificacion notificacion)
        {
            return "Aprobado";
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            return "Aprobado";
        }

        public override int ContarVotosAFavor(Ticket ticket, IDataContext contexto)
        {
            return 0;
        }

        public override int ContarVotosEnContra(Ticket ticket, IDataContext contexto)
        {
            return 0;
        }

        public override void ValidarTipoticketAgregar(IDataContext contexto)
        {
            var validaciones = new ValidacionesFlujoNoAprobacion(contexto,this);
            validaciones.LongitudNombre();
            validaciones.LongitudDescripcion();
            validaciones.VerificarDepartamento();
            validaciones.VerificarMinimoMaximoAprobado();
            validaciones.VerificarCargos();
        }
    }
    
}
