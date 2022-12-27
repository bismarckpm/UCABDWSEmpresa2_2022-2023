using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using System.Net.Sockets;

namespace ServicesDeskUCABWS.Entities
{
    public class TipoTicket_FlujoAprobacionJerarquico : Tipo_Ticket
    {
        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo) { }

        public TipoTicket_FlujoAprobacionJerarquico(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado) { }

        public TipoTicket_FlujoAprobacionJerarquico() { }

        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                //Calcular Cargos
                var ListaCargos = CargosAsociados(contexto, ticket);

                //Agregar Votos
                AgregarVotos(contexto, EmpleadosVotantes(contexto, ListaCargos, ticket), ticket);


                return EmpleadosVotantes(contexto, ListaCargos,ticket);
            }
            catch (ExceptionsControl ex)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).ToList();
            return Flujos.Select(x => x.Cargo).ToList();
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket)
        {
            return contexto.Empleados.Where(x => x.Cargo.id == ListaCargo[ticket.nro_cargo_actual.GetValueOrDefault() - 1].id).ToList();
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado(ticket, "Pendiente", _dataContext);
                ticket.EnviarNotificacion(ticket, "Pendiente", ListaEmpleados, _dataContext, notificacion, plantilla);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ObtenerTipoAprobacion()
        {
            return "Modelo_Jerarquico";
        }

        public override string VerificarVotacion(Guid idTicket, IDataContext contexto)
        {
            try
            {
                var ticket = ConsultarDatosTicket(idTicket, contexto);
                if (EstaAprobadoORechazado(ticket,contexto)!=null)
                {
                    CambiarEstadoVotosPendiente(ticket, EstaAprobadoORechazado(ticket, contexto), contexto);
                    if (EstaAprobadoORechazado(ticket, contexto) == "Aprobado")
                    {
                        if (VotosSiguienteRonda(ticket, contexto))
                        {
                            ticket.CambiarEstado(ticket, "Aprobado", contexto);
                            return EstaAprobadoORechazado(ticket, contexto);
                        }
                        return "Pendiente";
                    }
                    return EstaAprobadoORechazado(ticket, contexto);
                }
                return "Pendiente";

            }
            catch (Exception)
            {
                throw new ExceptionsControl("Error en el calculo de los votos");
            }

            
        }

        private bool VotosSiguienteRonda(Ticket ticket, IDataContext contexto)
        {
            ticket.nro_cargo_actual++;
            if (EsUltimaRonda(ticket,contexto))
            {
                return true;
            }
            var ListaEmpleados = FlujoAprobacion(contexto, ticket);
            return false;
        }

        private bool EsUltimaRonda(Ticket ticket, IDataContext contexto)
        {
            return contexto.Flujos_Aprobaciones
                .Where(x => x.Tipo_Ticket.Id == ticket.Tipo_Ticket.Id && x.OrdenAprobacion == ticket.nro_cargo_actual).Count() == 0;
        }

        public void CambiarEstadoVotosPendiente(Ticket ticket,string Estado, IDataContext contexto)
        {
            contexto.Votos_Tickets
                .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                .ToList().ForEach(x => x.voto = Estado);
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            if (ContarVotosAFavor(ticket.Id, contexto) >= ObtenerMinimoAprobado(ticket, contexto))
            {
                return "Aprobado";
            }
            if (ContarVotosEnContra(ticket.Id, contexto) >= ObtenerMaximoRechazado(ticket, contexto))
            {
                return "Rechazado";
            }
            return null;
        }

        private int? ObtenerMinimoAprobado(Ticket ticket, IDataContext contexto)
        {
            return ticket.Tipo_Ticket.Flujo_Aprobacion
                    .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .Select(x => x.Minimo_aprobado_nivel).FirstOrDefault();
        }

        private int? ObtenerMaximoRechazado(Ticket ticket, IDataContext contexto)
        {
            return ticket.Tipo_Ticket.Flujo_Aprobacion
                .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                .Select(x => x.Maximo_Rechazado_nivel).FirstOrDefault();
        }

        public override int ContarVotosAFavor(Guid idTicket, IDataContext contexto)
        {
            return contexto.Votos_Tickets.Include(x => x.Ticket).Where(x => x.IdTicket == idTicket
                && x.voto == "Aprobado" && x.Turno == x.Ticket.nro_cargo_actual).Count();
        }

        public override int ContarVotosEnContra(Guid idTicket, IDataContext contexto)
        {
            return contexto.Votos_Tickets.Include(x=>x.Ticket).Where(x => x.IdTicket == idTicket
                && x.voto == "Rechazado" && x.Turno == x.Ticket.nro_cargo_actual).Count();
        }
    }
}
