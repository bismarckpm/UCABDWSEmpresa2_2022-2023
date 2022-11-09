using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CTicketDAO
{
    public class TicketService : ITicketDAO
    {
        private readonly IDataContext contexto;
        private List<Ticket> listaTickets;

        public TicketService(IDataContext context)
        {
            contexto = context;
        }



        public Task<bool> ActualizarTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> ConsultaListaTickets()
        {
            listaTickets = contexto.Tickets.ToList();
            return listaTickets;
        }

        public Ticket ConsultaTicket(Guid id)
        {
            var Ticket = (Ticket)contexto.Tickets.Where(s => s.Id == id);
            return Ticket;
        }

        public Task<bool> EliminarTicket(Guid Id)
        {
            throw new NotImplementedException();
        }

        public ApplicationResponse<TicketCreateDTO> RegistroTicket(TicketCreateDTO ticketDTO)
        {

            var response = new ApplicationResponse<TicketCreateDTO>();
            try
            {

                var ticket = new Ticket(ticketDTO.titulo, ticketDTO.descripcion);
                ticket.Prioridad = contexto.Prioridades.Find(Guid.Parse(ticketDTO.Prioridad));
                //List<Empleado> v =(List<Empleado>) contexto.Usuarios.ToList();
                //Prioridad t = contexto.Prioridades.Find();//Include(x => x.Cargo).ThenInclude(x => x.Departamento).ToList();
                //.Where(s => s.Id == Guid.Parse(ticketDTO.Emisor)).FirstOrDefault();
                ticket.Emisor = contexto.Empleados.Include(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(s => s.Id == Guid.Parse(ticketDTO.Emisor)).FirstOrDefault();
                ticket.Departamento_Destino = contexto.Departamentos.Find(Guid.Parse(ticketDTO.Departamento_Destino));
                ticket.Tipo_Ticket = contexto.Tipos_Tickets.Find(Guid.Parse(ticketDTO.Tipo_Ticket));
                ticket.Estado = contexto.Estados.Where(x => x.Estado_Padre.nombre == "Pendiente" &&
                x.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id).FirstOrDefault();
                contexto.Tickets.Add(ticket);

                contexto.SaveChanges();
                response.Data = ticketDTO;
                response.Exception = FlujoAprobacion(ticket);

            }
            catch (ExceptionsControl ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            catch (SqlException ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.ToString();
            }
            return response;

        }

        public string FlujoAprobacion(Ticket ticket)
        {
            string result = null;
            switch (ticket.Tipo_Ticket.tipo)
            {
                case "Modelo_No_Aprobacion":
                    result = FlujoNoAprobacion(ticket);
                    break;
                case "Modelo_Paralelo":
                    result = FlujoParalelo(ticket);
                    break;
                case "Modelo_Jerarquico":
                    result = FlujoJerarquico(ticket);
                    break;

            }
            return result;
        }

        public string FlujoNoAprobacion(Ticket ticket)
        {
            string result = null;
            try
            {
                //Cambiar estado Ticket
                CambiarEstado(ticket, "Aprobado");

                //EnviarNotificacion(ticket.Emisor, ticket.Estado);
                List<Empleado> ListaEmpleado = contexto.Empleados.
                    Where(s => s.Cargo.Departamento.Id == ticket.Departamento_Destino.Id)
                    .ToList();
                //EnviarNotificacion(ListaEmpleado, ticket.Estado);


                contexto.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }


        public string FlujoParalelo(Ticket ticket)
        {
            string result = null;
            try
            {

                var tipoCargos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Tipo_Cargo)
                    .ThenInclude(x => x.Cargos_Asociados)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id);

                var Cargos = new List<Cargo>();
                foreach (var tc in tipoCargos)
                {
                    Cargos.Add(tc.Tipo_Cargo.Cargos_Asociados.ToList()
                        .Where(x => x.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id).First());
                }

                var ListaEmpleado = new List<Empleado>();
                foreach (var c in Cargos)
                {
                    ListaEmpleado.AddRange(contexto.Empleados.Where(x => x.Cargo.Id == c.Id));
                }

                var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
                {
                    IdTicket = ticket.Id,
                    Ticket = ticket,
                    IdUsuario = x.Id,
                    Empleado = x,
                    voto = "Pendiente"
                });

                contexto.Votos_Tickets.AddRange(ListaVotos);

                //EnviarNotificacion(ListaEmpleado, ticket.Estado);

                contexto.SaveChanges();

                return result;
            }
            catch (ExceptionsControl ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public string FlujoJerarquico(Ticket ticket)
        {
            string result = null;
            try
            {
                ticket.nro_cargo_actual = 1;

                var tipoCargos = contexto.Flujos_Aprobaciones
                    .Include(x => x.Tipo_Cargo)
                    .ThenInclude(x => x.Cargos_Asociados)
                    .ThenInclude(x => x.Departamento)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id)
                    .OrderBy(x => x.OrdenAprobacion).First();


                var Cargos = tipoCargos.Tipo_Cargo.Cargos_Asociados.ToList()
                    .Where(x => x.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id).First();


                var ListaEmpleado = contexto.Empleados.Where(x => x.Cargo.Id == Cargos.Id).ToList();


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

                //EnviarNotificacion(ListaEmpleado, ticket.Estado);

                //contexto.SaveChanges();

                return result;
            }
            catch (ExceptionsControl ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public bool CambiarEstado(Ticket ticket, string Estado)
        {
            try
            {
                ticket.Estado = contexto.Estados.Include(x => x.Estado_Padre).Include(x => x.Departamento).
                    Where(s => s.Estado_Padre.nombre == Estado &&
                    s.Departamento.Id == ticket.Emisor.Cargo.Departamento.Id)
                    .FirstOrDefault();
                var vticket = contexto.Tickets.Update(ticket);
                vticket.State = EntityState.Modified;

            }
            catch (ExceptionsControl ex)
            {
                return false;
            }
            return true;
        }
    }
}
