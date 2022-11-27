using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using NuGet.Protocol;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public class TicketDAO : ITicketDAO
    {
        private readonly IDataContext contexto;
        private List<Ticket> listaTickets;
        private readonly INotificacion notificacion;
        private readonly IPlantillaNotificacion plantilla;

        public TicketDAO(IDataContext context, IPlantillaNotificacion plantilla, INotificacion notificacion)
        {
            contexto = context;
            this.notificacion = notificacion;
            this.plantilla = plantilla;
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
                ticket.Emisor = contexto.Empleados.Include(x => x.Cargo).ThenInclude(x => x.Departamento)
                    .Where(s => s.Id == Guid.Parse(ticketDTO.Emisor.ToLower())).FirstOrDefault();
                ticket.Departamento_Destino = contexto.Departamentos.Find(Guid.Parse(ticketDTO.Departamento_Destino));
                ticket.Tipo_Ticket = contexto.Tipos_Tickets.Find(Guid.Parse(ticketDTO.Tipo_Ticket));
                ticket.Estado = contexto.Estados.Where(x => x.Estado_Padre.nombre == "Pendiente" &&
                x.Departamento.id == ticket.Emisor.Cargo.Departamento.id).FirstOrDefault();
                contexto.Tickets.Add(ticket);

                contexto.DbContext.SaveChanges();
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
                //EnviarNotificacion(ticket.Emisor, ticket.Estado);
                List<Empleado> ListaEmpleado = contexto.Empleados.
                    Where(s => s.Cargo.Departamento.id == ticket.Departamento_Destino.id)
                    .ToList();

                //Cambiar estado Ticket
                CambiarEstado(ticket, "Aprobado", null);
                contexto.DbContext.SaveChanges();
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
                        .Where(x => x.Departamento.id == ticket.Emisor.Cargo.Departamento.id).First());
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

                CambiarEstado(ticket,"Pendiente", ListaEmpleado);

                contexto.DbContext.SaveChanges();

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
                    .Where(x => x.Departamento.id == ticket.Emisor.Cargo.Departamento.id).First();


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

                CambiarEstado(ticket, "Pendiente", ListaEmpleado);

                contexto.DbContext.SaveChanges();

                return result;
            }
            catch (ExceptionsControl ex)
            {
                result = ex.Message;
                return result;
            }
        }

        public bool CambiarEstado(Ticket ticketLlegada, string Estado, List<Empleado> ListaEmpleados)
        {
            try
            {
                var ticket = contexto.Tickets.Include(x=>x.Departamento_Destino).ThenInclude(x=>x.grupo).Include(x=>x.Prioridad)
                    .Include(x => x.Emisor).ThenInclude(x=>x.Cargo).ThenInclude(x=>x.Departamento)
                    .Include(x=>x.Tipo_Ticket).Include(x=>x.Votos_Ticket)
                    .Where(x=>x.Id == ticketLlegada.Id).FirstOrDefault();

                ticket.Estado = contexto.Estados
                    .Include(x => x.Estado_Padre)
                    .Include(x => x.Departamento).
                    Where(s => s.Estado_Padre.nombre == Estado &&
                    s.Departamento.id == ticket.Emisor.Cargo.Departamento.id)
                    .FirstOrDefault();


                //contexto.DbContext.Entry(ticket).State = EntityState.Modified;
                contexto.Tickets.Update(ticket);
                contexto.DbContext.SaveChanges();
                //vticket.State = EntityState.Modified;

                if (Estado == "Aprobado")
                {
                    try
                    {
                        var plant =plantilla.ConsultarPlantillaTipoEstadoID(ticket.Estado.Estado_Padre.Id);
                        var descripcionPlantilla =notificacion.ReemplazoEtiqueta(ticket, plant);
                        notificacion.EnviarCorreo(plant.Titulo,descripcionPlantilla,ticket.Emisor.correo);

                    }
                    catch (ExceptionsControl) { }
                    CambiarEstado(ticket, "Siendo Procesado", null);
                    return true;
                }

                if(Estado == "Siendo Procesado")
                {
                    var empleados = contexto.Empleados.Include(x => x.Cargo).ThenInclude(x => x.Departamento).Where(x => x.Cargo.Departamento.id == ticket.Departamento_Destino.id).ToList();
                    var plant2 = plantilla.ConsultarPlantillaTipoEstadoID(ticket.Estado.Estado_Padre.Id);
                    var descripcionPlantilla2 = notificacion.ReemplazoEtiqueta(ticket, plant2);
                    foreach (var emp in empleados)
                    {
                        try
                        {
                            notificacion.EnviarCorreo(plant2.Titulo, descripcionPlantilla2, emp.correo);
                        }
                        catch (ExceptionsControl) { }
                    }
                    return true;
                }

                if (Estado == "Pendiente")
                {
                    var plant2 = plantilla.ConsultarPlantillaTipoEstadoID(ticket.Estado.Estado_Padre.Id);
                    var descripcionPlantilla2 = notificacion.ReemplazoEtiqueta(ticket, plant2);
                    foreach (var emp in ListaEmpleados)
                    {
                        try
                        {
                            notificacion.EnviarCorreo(plant2.Titulo, descripcionPlantilla2, emp.correo);
                        }
                        catch (ExceptionsControl) { }
                    }
                    return true;
                }

                try
                {
                    var plant = plantilla.ConsultarPlantillaTipoEstadoID(ticket.Estado.Estado_Padre.Id);
                    var descripcionPlantilla = notificacion.ReemplazoEtiqueta(ticket, plant);
                    notificacion.EnviarCorreo(plant.Titulo, descripcionPlantilla, ticket.Emisor.correo);
                }
                catch (ExceptionsControl) { }



            }
            catch (ExceptionsControl ex)
            {
                return false;
            }
            return true;
        }
    }
}
