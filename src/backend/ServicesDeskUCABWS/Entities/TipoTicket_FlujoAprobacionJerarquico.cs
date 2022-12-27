using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;

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
                ticket.nro_cargo_actual = 1;


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
            var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).First();
            var ListaCargos = new List<Cargo>();
            ListaCargos.Add(Flujos.Cargo);
            return ListaCargos;
        }

        public override List<Empleado> EmpleadosVotantes(IDataContext contexto, List<Cargo> ListaCargo)
        {

            return contexto.Empleados.Where(x => x.Cargo.id == ListaCargo.First().id).ToList();
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
                var tipo_ticket = contexto.Tickets.Include(x => x.Tipo_Ticket)
                    .ThenInclude(x => x.Flujo_Aprobacion)
                    .Where(x => x.Id == idTicket).First();

                var ticket = contexto.Tickets
                    .Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                    .Include(x => x.Emisor).ThenInclude(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(x => x.Id == idTicket).First();



                var minimo_aprobado = tipo_ticket.Tipo_Ticket.Flujo_Aprobacion
                    .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .Select(x => x.Minimo_aprobado_nivel).First();

                var maximo_rechazado = tipo_ticket.Tipo_Ticket.Flujo_Aprobacion
                    .Where(x => x.OrdenAprobacion == ticket.nro_cargo_actual)
                    .Select(x => x.Maximo_Rechazado_nivel).First();



                //contar votos a favor
                var votosfavor = contexto.Votos_Tickets.Where(x => x.IdTicket == idTicket
                && x.voto == "Aprobado" && x.Turno == ticket.nro_cargo_actual).Count();

                //Buscar votos necesarios para aprobar
                if (votosfavor >= minimo_aprobado)
                {
                    //Cambiar Estado a los votos restantes
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    l.ForEach(x => x.voto = "Aprobado");

                    //Ingreso siguiente ronda de votos
                    ticket.nro_cargo_actual++;
                    var fin = VotosSiguienteRonda(ticket, tipo_ticket,contexto);
                    if (fin)
                    {
                        ticket.CambiarEstado(ticket, "Aprobado", contexto);
                        return "Aprobado";
                    }
                    return "Pendiente";
                }

                //contar votos en contra
                var votoscontra = contexto.Votos_Tickets.Where(x => x.IdTicket == idTicket
                && x.voto == "Rechazado" && x.Turno == ticket.nro_cargo_actual).Count();
                if (votoscontra >= maximo_rechazado)
                {
                    //Cambiar Estado a los votos restantes
                    var l = contexto.Votos_Tickets
                        .Where(x => x.IdTicket == ticket.Id && x.voto == "Pendiente")
                        .ToList();
                    l.ForEach(x => x.voto = "Rechazado");

                    //Ingreso siguiente ronda de votos
                    var empleados = contexto.Empleados.Where(x => x.Id == ticket.Departamento_Destino.id).ToList();
                    ticket.CambiarEstado(ticket, "Rechazado", contexto);
                    contexto.DbContext.SaveChanges();
                    //EnviarNotiicacion("Ticket Rechazado")
                    return "Rechazado";

                }

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en el calculo de los votos");
            }

            return "Pendiente";
        }

        private bool VotosSiguienteRonda(Ticket ticket, Ticket tipo_ticket, IDataContext contexto)
        {
            if (contexto.Flujos_Aprobaciones
                .Where(x => x.Tipo_Ticket.Id == tipo_ticket.Tipo_Ticket.Id &&
            x.OrdenAprobacion == ticket.nro_cargo_actual).Count() == 0)
            {
                return true;
            }

            var Flujos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Cargo)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket.ToString().ToUpper() == ticket.Tipo_Ticket.Id.ToString().ToUpper() &&
                        x.OrdenAprobacion == ticket.nro_cargo_actual).FirstOrDefault();


            var Cargos = Flujos.Cargo;


            var ListaEmpleado = contexto.Empleados.Where(x => x.Cargo.id == Cargos.id).ToList();


            var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
            {
                IdTicket = ticket.Id,
                Ticket = ticket,
                IdUsuario = x.Id,
                Empleado = x,
                voto = "Pendiente",
                Turno = ticket.nro_cargo_actual
            });

            contexto.Votos_Tickets.AddRange(ListaVotos);
            ticket.CambiarEstado(ticket, "Pendiente",contexto);
            return false;
        }

        public override string EstaAprobadoORechazado(Ticket ticket, IDataContext contexto)
        {
            throw new NotImplementedException();
        }
    }
}
