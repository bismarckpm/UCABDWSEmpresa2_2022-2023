using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using NuGet.Packaging;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using Microsoft.Data.SqlClient;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using System.Runtime.CompilerServices;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using ServicesDeskUCABWS.BussinesLogic.Factory;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoTicket;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using Newtonsoft.Json;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using System.Net.Http;
using System.Text;
using System.Security.Cryptography.Xml;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperFlujoAprobacion;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO
{
    public class Tipo_TicketService : ITipo_TicketDAO
    {
        // Inyeccion de dependencias DBcontext
        private IDataContext context;
        private readonly IMapper _mapper;

        // Constructor para el servicio de Tipo Ticket
        public Tipo_TicketService(IDataContext Context, IMapper mapper)
        {
            context = Context;
            _mapper = mapper;
        }
        //GET: Servicio para consultar la lista de tipo ticket
        public IEnumerable<Tipo_TicketDTOSearch> ConsultarTipoTicket()
        {
            try
            {
                var tipo = context.Tipos_Tickets
                .Include(dep => dep.Departamentos).ThenInclude(dep => dep.departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Cargo)
                .Where(fa => fa.fecha_elim == null)
                .ToList();

                return BuscaDepartamentosAsociadosATipoTickets(tipo);
            }

            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No existen Tipos de tickets registrados", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema al consultar la lista de Tipos de Tickets", ex);
            }
        }
        public List<Tipo_TicketDTOSearch> BuscaDepartamentosAsociadosATipoTickets(List<Tipo_Ticket> data)
        {
            var tipo_ticketsDTO = new List<Tipo_TicketDTOSearch>();
            foreach (var r in data)
            {
                var listaDept = new List<DepartamentoSearchDTO>();
                foreach (var t in r.Departamentos)
                {
                    listaDept.Add(new DepartamentoSearchDTO()
                    {
                        Id = t.DepartamentoId.ToString(),
                        nombre = t.departamento.nombre
                    });
                }
                tipo_ticketsDTO.Add(new Tipo_TicketDTOSearch
                {
                    Id = r.Id,
                    nombre = r.nombre,
                    descripcion = r.descripcion,
                    Minimo_Aprobado = r.Minimo_Aprobado,
                    Maximo_Rechazado = r.Maximo_Rechazado,
                    tipo = r.ObtenerTipoAprobacion(),
                    Flujo_Aprobacion = FlujoAprobacionMapper.MapperListaFlujoEntityToFlujoDTO(r.Flujo_Aprobacion),
                    //_mapper.Map<List<Flujo_AprobacionDTOSearch>>(r.Flujo_Aprobacion),
                    Departamento = listaDept
                });
            }
            return tipo_ticketsDTO;
        }
        public IEnumerable<Tipo_TicketDTOSearch> ConsultarTipoTicketxDepartamento(Guid Id)
        {
            try
            {
                var tipo = context.Tipos_Tickets
                .Include(dep => dep.Departamentos).ThenInclude(dep => dep.departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Cargo)
                .Where(fa => fa.fecha_elim == null && fa.Departamentos.Select(x=>x.DepartamentoId).Contains(Id))
                .ToList();
                var tipo_ticketsDTO = new List<Tipo_TicketDTOSearch>();

                foreach (var r in tipo)
                {
                    var listaDept = new List<DepartamentoSearchDTO>();
                    foreach (var t in r.Departamentos)
                    {
                        listaDept.Add(new DepartamentoSearchDTO()
                        {
                            Id = t.DepartamentoId.ToString(),
                            nombre = t.departamento.nombre
                        });
                    }

                    tipo_ticketsDTO.Add(new Tipo_TicketDTOSearch
                    {
                        Id = r.Id,
                        nombre = r.nombre,
                        descripcion = r.descripcion,
                        Minimo_Aprobado = r.Minimo_Aprobado,
                        Maximo_Rechazado = r.Maximo_Rechazado,
                        tipo = r.ObtenerTipoAprobacion(),
                        Flujo_Aprobacion = _mapper.Map<List<Flujo_AprobacionDTOSearch>>(r.Flujo_Aprobacion),
                        Departamento = listaDept
                    });
                }
                return tipo_ticketsDTO;
            }

            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl("No existen Tipos de tickets registrados", ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Hubo un problema al consultar la lista de Tipos de Tickets", ex);
            }
        }

        

        public ApplicationResponse<Tipo_TicketDTOUpdate> ActualizarTipo_Ticket(Tipo_TicketDTOUpdate tipo_TicketDTO)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOUpdate>();
            try
            {
                //Validaciones
                ValidarDatosEntradaTipo_Ticket_Update(tipo_TicketDTO);

                var tipo_ticket = TipoTicketMapper.MapperTipoTicketDTOUpdatetoTipoTicket(tipo_TicketDTO);

                //Eliminando referencia en el tipo Ticket
                EliminarReferenciaTipoTicket(tipo_TicketDTO, tipo_ticket);

                //Agregando las nuevas relaciones
                AgregarFlujosAprobacion(tipo_ticket);
                AgregarDepartamentos(tipo_ticket);

                //Actualizacion de la BD
                context.Tipos_Tickets.Remove(context.Tipos_Tickets.Find(tipo_ticket.Id));
                context.Tipos_Tickets.Add(tipo_ticket);
                context.DbContext.SaveChanges();

                //Paso a AR
                response.Data = TipoTicketMapper.MapperTipoTicketToTipoTicketDTOUpdate(tipo_ticket);
            }
            catch (FormatException ex)
            {
                response.Success = false;
                response.Message = ErroresTipo_Tickets.FORMATO_ID_TICKET;
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
            }

            return response;
        }

        private void AgregarDepartamentos(Tipo_Ticket tipo_ticket)
        {
            try
            {
                tipo_ticket.Departamentos =
                    context.Departamentos
                   .Where(x => tipo_ticket.Departamentos.Select(y => y.DepartamentoId).Contains(x.id))
                   .Select(s => new DepartamentoTipo_Ticket()
                   {
                       departamento = s,
                       DepartamentoId = s.id,
                       tipo_Ticket = tipo_ticket,
                       Tipo_Ticekt_Id = tipo_ticket.Id

                   }).ToList();
            }
            catch (Exception) { }
        }

        private void AgregarFlujosAprobacion(Tipo_Ticket tipo_ticket)
        {
            try
            {
                tipo_ticket.Flujo_Aprobacion = 
                    tipo_ticket.Flujo_Aprobacion.Select(x => new Flujo_Aprobacion()
                    {
                        Tipo_Ticket = tipo_ticket,
                        IdTicket= tipo_ticket.Id,
                        IdCargo = x.IdCargo,
                        Cargo = context.Cargos.Find(x.IdCargo),
                        OrdenAprobacion = x.OrdenAprobacion,
                        Minimo_aprobado_nivel = x.Minimo_aprobado_nivel,
                        Maximo_Rechazado_nivel = x.Maximo_Rechazado_nivel
                    }).ToList();
            }
            catch (Exception) { }
        }

        private void EliminarReferenciaTipoTicket(Tipo_TicketDTOUpdate tipo_TicketDTO, Tipo_Ticket tipo_ticket)
        {
            //Eliminando Entidades intermedias de flujo de aprobacion
            context.Flujos_Aprobaciones.RemoveRange(context.Flujos_Aprobaciones
                .Where(x => x.IdTicket.ToString().ToUpper() == tipo_TicketDTO.Id.ToUpper()).ToList());

            context.DepartamentoTipo_Ticket.RemoveRange(context.DepartamentoTipo_Ticket
                .Where(x => x.Tipo_Ticekt_Id.ToString().ToUpper() == tipo_TicketDTO.Id.ToUpper()).ToList());
        }

        public ApplicationResponse<Tipo_TicketDTOCreate> RegistroTipo_Ticket(Tipo_TicketDTOCreate Tipo_TicketDTO)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOCreate>();
            try
            {
                //Validar Datos
                ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTO);

                //Obtener instancia, cambiar por un mapper
                var tipo_ticket = TipoTicketMapper.MapperTipoTicketDTOCreatetoTipoTicket(Tipo_TicketDTO);

                //Agregar Departamentos
                AgregarDepartamentos(tipo_ticket);
                //Agregar Flujos de Aprobacion
                AgregarFlujosAprobacion(tipo_ticket);
                //Actualizaciion de la BD
                context.Tipos_Tickets.Add(tipo_ticket);
                context.DbContext.SaveChanges();

                //Paso a AR

                response.Data = TipoTicketMapper.MapperTipoTicketToTipoTicketDTOCreate(tipo_ticket);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Exception = ex.Mensaje;
            }

            return response;
        }

        public void ValidarDatosEntradaTipo_Ticket_Update(Tipo_TicketDTOUpdate tipo_ticketDTO)
        {
            try
            {
                var tipoticket = TipoTicketMapper.MapperTipoTicketDTOUpdatetoTipoTicket(tipo_ticketDTO);
                tipoticket.ValidarTipoticketUpdate(context);
                /*var val = new TipoTicketValidaciones(context);

                //Verificar si el tipo ticket existe
                val.VerificarTipoTicketExiste(tipoticket.Id);

                //Validar si no existe Ticket Activo
                val.VerificarTicketsPendientes(tipoticket.Id);
                tipoticket.ValidarTipoticketAgregar(context);*/
            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.FORMATO_ID_TICKET, ex);
            }
            catch (ExceptionsControl ex)
            {
                throw new ExceptionsControl(ex.Mensaje);
            }
        }

        public void ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            try
            {
                var tipoticket = TipoTicketMapper.MapperTipoTicketDTOCreatetoTipoTicket(tipo_TicketDTOCreate);
                tipoticket.ValidarTipoticketAgregar(context);
            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.FORMATO_NO_VALIDO, ex);
            }


        }

        private static List<FlujoAprobacionDTOCreate> ObtenerCargos(Tipo_TicketDTOCreate tipo_TicketDTOCreate)
        {
            return tipo_TicketDTOCreate.Flujo_Aprobacion;
        }

        //GET: Servicio para consultar un tipo de ticket por un ID en específico
        public Tipo_TicketDTOSearch ConsultarTipoTicketGUID(Guid id)
        {
            try
            {
                var data = context.Tipos_Tickets
                   .AsNoTracking()
                   .Include(p => p.Departamentos)
                   .ThenInclude(dep => dep.departamento)
                   .Include(fa => fa.Flujo_Aprobacion)
                   .ThenInclude(_fa => _fa.Cargo)
                   .Where(p => p.Id == id)
                   .Single();

                var dep = BuscaDepartamentosAsociados(data);
                return dep;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo de ticket con ese ID", ex);
            }
        }
        //GET: Servicio para Consultar un tipo de ticket por un nombre en específico
        public Tipo_TicketDTOSearch ConsultarNombreTipoTicket(string nombre)
        {
            try
            {
                var data = context.Tipos_Tickets.AsNoTracking()
                   .Include(p => p.Departamentos)
                   .ThenInclude(dep => dep.departamento)
                   .Include(fa => fa.Flujo_Aprobacion)
                   .ThenInclude(_fa => _fa.Cargo)
                   .Where(t => t.nombre == nombre)
                   .Single();

                var dep = BuscaDepartamentosAsociados(data);
                return dep;

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo de ticket con ese nombre", ex);
            }
        }
        public Tipo_TicketDTOSearch BuscaDepartamentosAsociados(Tipo_Ticket data)
        {
            var tipo_ticketsDTO = new Tipo_TicketDTOSearch();
            var listaDept = new List<DepartamentoSearchDTO>();
            foreach (var t in data.Departamentos)
            {
                listaDept.Add(new DepartamentoSearchDTO()
                {
                    Id = t.DepartamentoId.ToString(),
                    nombre = t.departamento.nombre
                });
            }
            tipo_ticketsDTO = new Tipo_TicketDTOSearch()
            {
                Id = data.Id,
                nombre = data.nombre,
                descripcion = data.descripcion,
                Minimo_Aprobado = data.Minimo_Aprobado,
                Maximo_Rechazado = data.Maximo_Rechazado,
                tipo = data.ObtenerTipoAprobacion(),
                Flujo_Aprobacion = FlujoAprobacionMapper.MapperListaFlujoEntityToFlujoDTO(data.Flujo_Aprobacion),
                //_mapper.Map<List<Flujo_AprobacionDTOSearch>>(data.Flujo_Aprobacion),
                Departamento = listaDept
            };

            return tipo_ticketsDTO;

        }

        //DELETE: Servicio para Desactivar un tipo de ticket por un id en especifico
        public Boolean EliminarTipoTicket(Guid id)
        {
            try
            {
                //Validar el id de entrada

                ValidarDatosEntradaTipo_Ticket_Delete(id);

                var tipo_ticket = context.Tipos_Tickets.Find(id);

                //Cambia la fecha de eliminacion por la fecha actual 
                tipo_ticket.fecha_elim = DateTime.UtcNow;

                //Guardar cambios
                context.DbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo desactivar el tipo de ticket", ex);
            }
        }

        

        public void ValidarDatosEntradaTipo_Ticket_Delete(Guid Id)
        {

            var tipo_Ticket = context.Tipos_Tickets.Find(Id);

            if (tipo_Ticket == null)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
            }

            ConsultarTicketPendientes(tipo_Ticket);

        }
        public void ConsultarTicketPendientes(Tipo_Ticket data)
        {
            var ticketsPendientes = context.Tickets
                    .Include(x => x.Tipo_Ticket)
                    .Include(x => x.Estado)
                    .ThenInclude(x => x.Estado_Padre)
                    .Where(x => x.Tipo_Ticket.Id == data.Id &&
                    x.Estado.Estado_Padre.nombre == "Pendiente").Count();

            if (ticketsPendientes > 0)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
            }
        }

        public List<Tipo_TicketDTOSearch> ConsultaTipoTicketAgregarTicket(Guid Id)
        {
            var ListaTipoTicket = context.Tipos_Tickets.Include(x => x.Departamentos).ThenInclude(x=>x.departamento).Where(x => x.Departamentos.Select(x => x.departamento.id).Contains(Id) && x.fecha_elim==null).ToList();
            ListaTipoTicket.AddRange(context.Tipos_Tickets.Include(x => x.Departamentos).Where(x => x.Departamentos.Count==0 && x.fecha_elim ==null).ToList());
            var ListaTipoTicketDTO = _mapper.Map<List<Tipo_TicketDTOSearch>>(ListaTipoTicket);
            return ListaTipoTicketDTO;
        }

        public List<Modelo_Aprobacion> ConsultarTipoFlujos()
        {
            try
            {
                return context.Modelos_Aprobacion.ToList();
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("Error en la conexion con la base de datos", ex);
            }
        }
    }
}
