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
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic;

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
                AgregarVotos(contexto, EmpleadosVotantes(contexto, CargosAsociados(contexto, ticket), ticket), ticket);
                return EmpleadosVotantes(contexto, CargosAsociados(contexto, ticket), ticket);
            }
            catch (ExceptionsControl)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            var listacargos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).Select(x => x.Cargo).ToList();
            
            return listacargos;
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket)
        {
            return contexto.Empleados.Where(x => x.Cargo.id == ListaCargo[ticket.nro_cargo_actual.GetValueOrDefault() - 1].id).ToList();
        }

        public async override Task<bool> CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion)
        {
            try
            {
                ticket.CambiarEstado( "Pendiente", _dataContext);
                //notificacion.EnviarNotificacion(ticket, TipoNotificacion.Pendiente, ListaEmpleados);

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

        public override string VerificarVotacion(Ticket ticket, IDataContext contexto, INotificacion notificacion)
        {
            try
            {
                if (EstaAprobadoORechazado(ticket,contexto)!=null)
                {
                    CambiarEstadoVotosPendiente(ticket, EstaAprobadoORechazado(ticket, contexto), contexto);
                    if (EstaAprobadoORechazado(ticket, contexto) != "Aprobado")
                    {
                        return EstaAprobadoORechazado(ticket, contexto);
                    }
                    else
                    {
                        if (VotosSiguienteRonda(ticket, contexto))
                        {
                            ticket.CambiarEstado( "Aprobado", contexto);
                            return EstaAprobadoORechazado(ticket, contexto);
                        }
                        return "Pendiente";
                    }
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
            if (!EsUltimaRonda(ticket,contexto))
            {
                FlujoAprobacion(contexto, ticket);
                return false;
            }
            return true;
        }

        private bool EsUltimaRonda(Ticket ticket, IDataContext contexto)
        {
            return ticket.Tipo_Ticket.Flujo_Aprobacion.Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual).Count() == 0;
        }

        public void CambiarEstadoVotosPendiente(Ticket ticket,string Estado, IDataContext contexto)
        {
            ticket.Votos_Ticket.Where(x=>x.voto == "Pendiente").ToList().ForEach(x => x.voto = Estado);
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            if (ContarVotosAFavor(ticket, contexto) >= ObtenerMinimoAprobado(ticket, contexto))
            {
                return "Aprobado";
            }
            if (ContarVotosEnContra(ticket, contexto) >= ObtenerMaximoRechazado(ticket, contexto))
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


        public override int ContarVotosAFavor(Ticket ticket, IDataContext contexto)
        {
            return ticket.Votos_Ticket.Where(x => x.voto == "Aprobado" && x.Turno == x.Ticket.nro_cargo_actual).Count();
        }


        public override int ContarVotosEnContra(Ticket ticket, IDataContext contexto)
        {
            return ticket.Votos_Ticket.Where(x => x.voto == "Rechazado" && x.Turno == x.Ticket.nro_cargo_actual).Count();
        }

        public override void ValidarTipoticketAgregar(IDataContext contexto)
        {
            LongitudNombre();
            LongitudDescripcion();
            VerificarDepartamento(contexto);
            HayCargos();
            VerificarCargos(contexto);
            VerificarMinimoMaximoAprobado();
            VerificarFlujos();
            VerificarSecuenciaOrdenAprobacion();
        }

        //Validaciones
        public override void VerificarFlujos()
        {
            foreach (var cargo in ObtenerCargos())
            {
                if (!HayMinimo_Aprobado_nivel(cargo) || !HayMaximo_Aprobado_nivel(cargo) || !HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
                }
                if (cargo.Minimo_aprobado_nivel <= 0 || cargo.Maximo_Rechazado_nivel <= 0)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MENOR_A_0_MAN_MRN_OS);
                }
            }
        }

        public override void VerificarMinimoMaximoAprobado()
        {
            if (HayMinimoAprobado() || HayMaximo_Rechazado())
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NO_VALIDO);
            }
        }

        public void VerificarSecuenciaOrdenAprobacion()
        {
            int i = 1;
            foreach (var c in ObtenerCargosOrdenados())
            {
                if (i != c.OrdenAprobacion)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
                }
                i++;
            }
        }

    }
}
