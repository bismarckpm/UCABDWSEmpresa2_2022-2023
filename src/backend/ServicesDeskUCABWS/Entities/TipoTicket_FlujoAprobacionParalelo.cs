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

namespace ServicesDeskUCABWS.Entities
{
    public class TipoTicket_FlujoAprobacionParalelo : Tipo_Ticket
    {
        public override List<Empleado> FlujoAprobacion(IDataContext contexto, Ticket ticket)
        {
            try
            {
                //Calcular Cargos
                var ListaCargos = CargosAsociados(contexto, ticket);

                //Agregar Votos
                AgregarVotos(contexto, EmpleadosVotantes(contexto, ListaCargos), ticket);


                return EmpleadosVotantes(contexto, ListaCargos);
            }
            catch (ExceptionsControl ex)
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

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo)
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
            return "Modelo_Paralelo";
        }

        public override string VerificarVotacion(Guid idTicket, IDataContext contexto)
        {
            try
            {
                //Consultar Ticket
                var ticket = ConsultarDatosTicket(idTicket, contexto);
                    

                //Comparar Votos
                if (EstaAprobadoORechazado(ticket, contexto)!=null)
                {
                    //Cambiar Estado y mandar votos
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticket.CambiarEstado(ticket, EstaAprobadoORechazado(ticket, contexto), contexto);
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
            if (ContarVotosAFavor(ticket.Id, contexto) >= ticket.Tipo_Ticket.Minimo_Aprobado){
                return "Aprobado";
            }
            if (ContarVotosEnContra(ticket.Id, contexto) >= ticket.Tipo_Ticket.Maximo_Rechazado){
                return "Rechazado";
            }
            return null;
        }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo) : base(nombre, descripcion, tipo) { }

        public TipoTicket_FlujoAprobacionParalelo(string nombre, string descripcion, string tipo, int? MinimoAprobado = null, int? MaximoRechazado = null) : base(nombre, descripcion, tipo, MinimoAprobado, MaximoRechazado) { }

        public TipoTicket_FlujoAprobacionParalelo() { }
    }
}
