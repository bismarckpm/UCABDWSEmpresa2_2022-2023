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

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO
{
    public class Tipo_TicketService : ITipo_TicketDAO
    {
        // Inyeccion de dependencias DBcontext
        private IDataContext context;
       private readonly IMapper _mapper;


        Mapper mapper = new Mapper(new MapperConfiguration(c => c.CreateMap<Tipo_TicketDTOUpdate, Tipo_TicketDTOCreate>()));
        // Mapper mappers = new Mapper(new MapperConfiguration(d => d.CreateMap<Tipo_Ticket, Tipo_TicketDTOSearch>()));

        //

        public Tipo_TicketService(IDataContext Context)
        {
            context = Context;
        
        }
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
                .Include(dep => dep.Departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Tipo_Cargo)
                .Where(fa => fa.fecha_elim == null)
                .ToList();
                var tipo_tickets = _mapper.Map<List<Tipo_TicketDTOSearch>>(tipo);
                return (IEnumerable<Tipo_TicketDTOSearch>)tipo_tickets;
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
                ValidarDatosEntradaTipo_Ticket_Update(tipo_TicketDTO);
                
                //Actualizando Datos 
                var tipo_ticket = context.Tipos_Tickets.Find(Guid.Parse(tipo_TicketDTO.Id));
                tipo_ticket.nombre = tipo_TicketDTO.nombre;
                tipo_ticket.descripcion = tipo_TicketDTO.descripcion;
                tipo_ticket.tipo = tipo_TicketDTO.tipo;
                tipo_ticket.fecha_ult_edic = DateTime.UtcNow;
                tipo_ticket.Minimo_Aprobado = tipo_TicketDTO.Minimo_Aprobado;
                tipo_ticket.Maximo_Rechazado = tipo_TicketDTO.Maximo_Rechazado;

                //Eliminando referencia en el tipo Ticket
                if (tipo_ticket.Departamento!=null) tipo_ticket.Departamento.Clear();
                if (tipo_ticket.Departamento != null) tipo_ticket.Flujo_Aprobacion.Clear();

                //Eliminando Entidades intermedias de flujo de aprobacion
                context.Flujos_Aprobaciones.RemoveRange(context.Flujos_Aprobaciones
                    .Where(x => x.IdTicket.ToString().ToUpper() == tipo_TicketDTO.Id.ToUpper()).ToList());

                //Agregando las nuevas relaciones
                try 
                {
                    tipo_ticket.Flujo_Aprobacion =
                   context.Tipos_Cargos
                   .Where(x => tipo_TicketDTO.Flujo_Aprobacion.Select(y => y.IdTipoCargo.ToString().ToUpper()).Contains(x.Id.ToString().ToUpper()))
                   .Select(s => new Flujo_Aprobacion()
                   {
                       Tipo_Cargo = s,
                       IdTipo_cargo = s.Id,
                       Tipo_Ticket = tipo_ticket,
                       IdTicket = tipo_ticket.Id

                   }).ToList();
                    foreach (Flujo_Aprobacion fa in tipo_ticket.Flujo_Aprobacion)
                    {
                        var t = tipo_TicketDTO.Flujo_Aprobacion.Where(x => x.IdTipoCargo.ToUpper() == fa.IdTipo_cargo.ToString().ToUpper()).FirstOrDefault();
                        
                        fa.OrdenAprobacion = t.OrdenAprobacion;
                        fa.Minimo_aprobado_nivel = t.Minimo_aprobado_nivel;
                        fa.Maximo_Rechazado_nivel = t.Maximo_Rechazado_nivel;
                    }
                }
                catch (Exception) { }
                try 
                {
                    tipo_ticket.Departamento = context.Departamentos
                    .Where(x => tipo_TicketDTO.Departamento.Contains(x.Id.ToString().ToUpper()))
                    .ToList();
                } catch(Exception) { }

                //Actualizacion de la BD
                context.Tipos_Tickets.Update(tipo_ticket);
                context.DbContext.SaveChanges();

                //Paso a AR
                response.Data = tipo_TicketDTO;
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }

            return response;
        }



        public ApplicationResponse<Tipo_TicketDTOCreate> RegistroTipo_Ticket(Tipo_TicketDTOCreate Tipo_TicketDTO)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOCreate>();
            try
            {
                //ValidarDatos
                ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTO);

                //Construccion del Tipo Ticket
                Tipo_Ticket tipo_ticket;
                tipo_ticket = new Tipo_Ticket(Tipo_TicketDTO.nombre, Tipo_TicketDTO.descripcion, Tipo_TicketDTO.tipo, Tipo_TicketDTO.Minimo_Aprobado, Tipo_TicketDTO.Maximo_Rechazado);

                try
                {
                    tipo_ticket.Departamento =
                    context.Departamentos.Where(x => Tipo_TicketDTO.Departamento.Contains(x.Id.ToString())).ToList();
                }
                catch (Exception) { }
                try
                {
                    tipo_ticket.Flujo_Aprobacion =
                    context.Tipos_Cargos
                    .Where(x => Tipo_TicketDTO.Flujo_Aprobacion.Select(y => y.IdTipoCargo).Contains(x.Id.ToString().ToUpper()))
                    .Select(s => new Flujo_Aprobacion()
                    {
                        Tipo_Cargo = s,
                        IdTipo_cargo = s.Id,
                        Tipo_Ticket = tipo_ticket,
                        IdTicket = tipo_ticket.Id
                    }).ToList();
                    foreach (Flujo_Aprobacion fa in tipo_ticket.Flujo_Aprobacion)
                    {
                        var t = Tipo_TicketDTO.Flujo_Aprobacion.Where(x => x.IdTipoCargo == fa.IdTipo_cargo.ToString().ToUpper()).First();
                        fa.OrdenAprobacion = t.OrdenAprobacion;
                        fa.Minimo_aprobado_nivel = t.Minimo_aprobado_nivel;
                        fa.Maximo_Rechazado_nivel = t.Maximo_Rechazado_nivel;
                    }
                }
                catch (Exception EX) { }
                //Actualizaciion de la BD
                context.Tipos_Tickets.Add(tipo_ticket);
                context.DbContext.SaveChanges();

                //Paso a AR
                response.Data = Tipo_TicketDTO;
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Exception = ex.Mensaje;
            }

            return response;
        }


        public void ValidarDatosEntradaTipo_Ticket_Update(Tipo_TicketDTOUpdate tipo_TicketDTOUpdate)
        {
            try
            {
                var tipo_Ticket = context.Tipos_Tickets.Find(Guid.Parse(tipo_TicketDTOUpdate.Id));
                if (tipo_Ticket == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
                }



                if (tipo_Ticket.tipo != tipo_TicketDTOUpdate.tipo)
                {
                    var ticketsPendientes = context.Tickets.Include(x => x.Tipo_Ticket).Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                        .Where(x => x.Tipo_Ticket.Id == tipo_Ticket.Id &&
                        x.Estado.Estado_Padre.nombre == "Pendiente").Count();
                    if (ticketsPendientes > 0)
                    {
                        throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
                    }
                }


                var tipo_TicketDTOCreate = mapper.Map<Tipo_TicketDTOCreate>(tipo_TicketDTOUpdate);
                if (tipo_TicketDTOCreate.Flujo_Aprobacion.Count() == 0)
                {
                    tipo_TicketDTOCreate.Flujo_Aprobacion = null;
                }
                ValidarDatosEntradaTipo_Ticket(tipo_TicketDTOCreate);
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

                if (tipo_TicketDTOCreate.nombre.Length < 4 || tipo_TicketDTOCreate.nombre.Length > 150)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.NOMBRE_FUERA_DE_RANGO);
                }
                if (tipo_TicketDTOCreate.descripcion.Length < 4 || tipo_TicketDTOCreate.descripcion.Length > 250)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.DESCRIPCION_FUERA_DE_RANGO);
                }

                var Lista = new string[] { "Modelo_Jerarquico", "Modelo_Paralelo", "Modelo_No_Aprobacion", };
                if (!Lista.Contains(tipo_TicketDTOCreate.tipo))
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_NO_VALIDO);
                }

                var cargos = tipo_TicketDTOCreate.Flujo_Aprobacion;

                var departamentos = tipo_TicketDTOCreate.Departamento;

                if (departamentos != null)
                {
                    foreach (var d in departamentos.ToList())
                    {
                        if (context.Departamentos.Find(Guid.Parse(d)) == null)
                        {
                            throw new ExceptionsControl(ErroresTipo_Tickets.DEPARTAMENTO_NO_VALIDO);
                        }
                    }
                }

                if (tipo_TicketDTOCreate.tipo != "Modelo_No_Aprobacion")
                {
                    if (cargos == null)
                    {
                        throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_VACIO);
                    }
                    foreach (var c in cargos)
                    {
                        if (context.Tipos_Cargos.Find(Guid.Parse(c.IdTipoCargo)) == null)
                        {
                            throw new ExceptionsControl(ErroresTipo_Tickets.CARGO_NO_VALIDO);
                        }
                    }

                    if (tipo_TicketDTOCreate.tipo == "Modelo_Paralelo")
                    {

                        if (tipo_TicketDTOCreate.Minimo_Aprobado == null || tipo_TicketDTOCreate.Maximo_Rechazado == null)
                        {
                            throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
                        }

                        foreach (var c in cargos)
                        {
                            if (c.Minimo_aprobado_nivel != null || c.Maximo_Rechazado_nivel != null || c.OrdenAprobacion != null)
                            {
                                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
                            }
                        }
                    }

                    if (tipo_TicketDTOCreate.tipo == "Modelo_Jerarquico")
                    {
                        if (tipo_TicketDTOCreate.Minimo_Aprobado != null || tipo_TicketDTOCreate.Maximo_Rechazado != null)
                        {
                            throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NO_VALIDO);
                        }

                        List<int> orden = new List<int>();
                        int i = 1;
                        var cargosOrd = cargos.OrderBy(x => x.OrdenAprobacion);
                        foreach (var c in cargosOrd)
                        {

                            if (c.Minimo_aprobado_nivel == null || c.Maximo_Rechazado_nivel == null || c.OrdenAprobacion == null)
                            {
                                throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
                            }


                            if (i != c.OrdenAprobacion)
                            {
                                throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
                            }
                            i++;
                        }

                    }
                }
                if (tipo_TicketDTOCreate.tipo == "Modelo_No_Aprobacion")
                {
                    if (tipo_TicketDTOCreate.Minimo_Aprobado != null || tipo_TicketDTOCreate.Maximo_Rechazado != null)
                    {
                        throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_NO_VALIDO);
                    }
                    if (tipo_TicketDTOCreate.Flujo_Aprobacion != null)
                    {
                        throw new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_CARGO);
                    }
                }

            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.FORMATO_NO_VALIDO, ex);
            }


        }
        //GET: Servicio para consultar un tipo de ticket por un ID en específico

        public Tipo_TicketDTOSearch ConsultarTipoTicketGUID(Guid id)
        {
            try
            {
                var data = context.Tipos_Tickets
                   .Include(p => p.Departamento)
                   .Include(fa => fa.Flujo_Aprobacion)
                   .ThenInclude(_fa => _fa.Tipo_Cargo)
                   .Where(p => p.Id == id).Single();
                var tipoticketSearchDTO = _mapper.Map<Tipo_TicketDTOSearch>(data);
                return tipoticketSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo de ticket con ese ID", ex);
            }

        }

        //GET: Servicio para consultar un tipo de ticket por un nombre en específico
        public Tipo_TicketDTOSearch ConsultarTipoTicketNomb(string nombre)
        {
            try
            {
                var data = context.Tipos_Tickets.AsNoTracking()
                   .Include(p => p.Departamento)
                   .Include(fa => fa.Flujo_Aprobacion)
                   .ThenInclude(_fa => _fa.Tipo_Cargo).Where(t => t.nombre == nombre).SingleAsync();
                var tipoticketSearchDTO = _mapper.Map<Tipo_TicketDTOSearch>(data);
                return tipoticketSearchDTO;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No existe el tipo de ticket con ese nombre", ex);
            }
        }
        //DELETE: Servicio para eliminar un tipo de ticket por un id en especifico
        public Boolean EliminarTipoTicket(Guid id)
        {

            try
            {
                ValidarDatosEntradaTipo_Ticket_Delete(id);
                var tipo_ticket = context.Tipos_Tickets.Find(id);

                tipo_ticket.fecha_elim = DateTime.UtcNow;
                context.DbContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("No se pudo eliminar el tipo de ticket", ex);
            }

        }

        public void ValidarDatosEntradaTipo_Ticket_Delete(Guid Id)
        {
            try
            {
                
                var tipo_Ticket = context.Tipos_Tickets.Find(Id);
                if (tipo_Ticket == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
                }
                var ticketsPendientes = context.Tickets.Include(x => x.Tipo_Ticket).Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                        .Where(x => x.Tipo_Ticket.Id == tipo_Ticket.Id &&
                        x.Estado.Estado_Padre.nombre == "Pendiente").Count();

                if (ticketsPendientes > 0)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
                }

            }
            catch (FormatException ex)
            {
                throw new ExceptionsControl(ErroresTipo_Tickets.FORMATO_ID_TICKET, ex);
            }
           
        }
    }
}
