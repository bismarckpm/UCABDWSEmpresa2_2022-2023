using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using System.Net.Sockets;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using ServicesDeskUCABWS.BussinesLogic.Recursos;

namespace ServicesDeskUCABWS.Entities
{
    public class TipoTicket_FlujoAprobacionParalelo : Tipo_Ticket
    {
        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo) { }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado) { }

        public TipoTicket_FlujoAprobacionParalelo() { }

        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                var ListaCargos = CargosAsociados(contexto, ticket);
                AgregarVotos(contexto, EmpleadosVotantes(contexto, ListaCargos, ticket), ticket);
                return EmpleadosVotantes(contexto, ListaCargos,ticket);
            }
            catch (ExceptionsControl)
            {
                return null;
            }
        }

        public override List<Cargo> CargosAsociados(IDataContext contexto, Ticket ticket)
        {
            var Flujos = contexto.Flujos_Aprobaciones.Include(s => s.Cargo)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id).ToList();

            var Cargos = new List<Cargo>();
            foreach (var f in Flujos)
            {
                Cargos.Add(f.Cargo);
            }
            return Cargos;
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo, Ticket ticket)
        {
            var ListaEmpleado = new List<Empleado>();
            foreach (var c in ListaCargo)
            {
                ListaEmpleado.AddRange(contexto.Empleados.Where(x => x.Cargo.id == c.id));
            }
            return ListaEmpleado;
        }

        public override bool CambiarEstadoCreacionTicket(Ticket ticket, List<Empleado> ListaEmpleados, IDataContext _dataContext, INotificacion notificacion, IPlantillaNotificacion plantilla)
        {
            try
            {
                ticket.CambiarEstado( "Pendiente", _dataContext);
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
            return "Modelo_Paralelo";
        }

        public override string VerificarVotacion(Ticket ticket, IDataContext contexto)
        {
            try
            {
                if (EstaAprobadoORechazado(ticket, contexto)!=null)
                {
                    //Cambiar Estado y mandar votos
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticket.CambiarEstado(EstaAprobadoORechazado(ticket, contexto), contexto);
                    //ticket.EnviarNotificacion(ticket, "Aprobado", contexto); //Cuando refactorizen el codigo de Estadp se podra descomentar

                    CambiarEstadoVotosPendiente(ticket, contexto);
                    return EstaAprobadoORechazado(ticket, contexto);
                }

                return "Pendiente";
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en el calculo de los votos");
            }

            
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            if (ContarVotosAFavor(ticket, contexto) >= ticket.Tipo_Ticket.Minimo_Aprobado){
                return "Aprobado";
            }
            if (ContarVotosEnContra(ticket, contexto) >= ticket.Tipo_Ticket.Maximo_Rechazado){
                return "Rechazado";
            }
            return null;
        }

        public override int ContarVotosAFavor(Ticket ticket, IDataContext contexto)
        {
            return ticket.Votos_Ticket.Where(x=>x.voto == "Aprobado").Count();
        }

        public override int ContarVotosEnContra(Ticket ticket, IDataContext contexto)
        {
            return ticket.Votos_Ticket.Where(x => x.voto == "Rechazado").Count();
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
        }


        //Validaciones
        public override void VerificarFlujos()
        {
            foreach (var cargo in ObtenerCargos())
            {
                if (HayMinimo_Aprobado_nivel(cargo) || HayMaximo_Aprobado_nivel(cargo) || HayOrdenAprobacion(cargo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
                }
            }
        }

        public override void VerificarMinimoMaximoAprobado()
        {
            if (!HayMinimoAprobado() || !HayMaximo_Rechazado())
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
            }
        }
    }
}
