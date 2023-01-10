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
                .Include(dep => dep.Departamentos).ThenInclude(dep=>dep.departamento)
                .Include(fa => fa.Flujo_Aprobacion)
                .ThenInclude(fb => fb.Cargo)
                .Where(fa => fa.fecha_elim == null)
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
                        }) ;    
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
                var tipo_ticket= TipoTicketMapper.MapperTipoTicketDTOUpdatetoTipoTicket(tipo_TicketDTO);
                ValidarDatosEntradaTipo_Ticket_Update(tipo_ticket);

                //Actualizando Datos 
                //var tipo_ticket = LlenarTipoTicket(tipo_TicketDTO);

                //Eliminando referencia en el tipo Ticket
                EliminarReferenciaTipoTicket(tipo_TicketDTO, tipo_ticket);

                //Agregando las nuevas relaciones
                AgregarFlujosAprobacion(tipo_TicketDTO, tipo_ticket);
                AgregarDepartamentos(tipo_TicketDTO, tipo_ticket);

                //Actualizacion de la BD
                Update(tipo_TicketDTO, tipo_ticket);

                //Paso a AR
                response.Data = TipoTicketMapper.MapperTipoTicketToTipoTicketDTOUpdate(tipo_ticket);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
            }

            return response;
        }

        private void Update(Tipo_TicketDTOUpdate tipo_TicketDTO, Tipo_Ticket tipo_ticket)
        {
            var tipo_actual = tipo_ticket.ObtenerTipoAprobacion();
            if (tipo_TicketDTO.tipo != tipo_actual)
            {
                context.Tipos_Tickets.Remove(context.Tipos_Tickets.Find(tipo_ticket.Id));
                context.Tipos_Tickets.Add(tipo_ticket);
            }
            else
            {
                context.Tipos_Tickets.Update(tipo_ticket);
            }

            context.DbContext.SaveChanges();
        }

        private void AgregarDepartamentos(Tipo_TicketDTOUpdate tipo_TicketDTO, Tipo_Ticket tipo_ticket)
        {
            try
            {
                tipo_ticket.Departamentos =
                    context.Departamentos
                   .Where(x => tipo_TicketDTO.Departamento.Select(y => y.ToString().ToUpper()).Contains(x.id.ToString().ToUpper()))
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

        private void AgregarFlujosAprobacion(Tipo_TicketDTOUpdate tipo_TicketDTO, Tipo_Ticket tipo_ticket)
        {
            try
            {
                var Cargos = context.Cargos.Where(x => tipo_TicketDTO.Flujo_Aprobacion
                    .Select(x => x.IdCargo.ToUpper()).ToList().Contains(x.id.ToString().ToUpper()));
                tipo_ticket.Flujo_Aprobacion = new List<Flujo_Aprobacion>();
                foreach (var c in Cargos)
                {
                    tipo_ticket.Flujo_Aprobacion.Add(new Flujo_Aprobacion()
                    {
                        IdTicket = tipo_ticket.Id,
                        Tipo_Ticket = tipo_ticket,
                        IdCargo = c.id,
                        Cargo = c
                    });
                }

                foreach (var fa in tipo_ticket.Flujo_Aprobacion)
                {
                    var t = tipo_TicketDTO.Flujo_Aprobacion.Where(x => x.IdCargo.ToUpper() == fa.IdCargo.ToString().ToUpper()).FirstOrDefault();

                    fa.OrdenAprobacion = t.OrdenAprobacion;
                    fa.Minimo_aprobado_nivel = t.Minimo_aprobado_nivel;
                    fa.Maximo_Rechazado_nivel = t.Maximo_Rechazado_nivel;
                }
            }
            catch (Exception) { }
        }

        private void EliminarReferenciaTipoTicket(Tipo_TicketDTOUpdate tipo_TicketDTO, Tipo_Ticket tipo_ticket)
        {
            if (tipo_ticket.Departamentos != null) tipo_ticket.Departamentos.Clear();
            if (tipo_ticket.Flujo_Aprobacion != null) tipo_ticket.Flujo_Aprobacion.Clear();

            //Eliminando Entidades intermedias de flujo de aprobacion
            context.Flujos_Aprobaciones.RemoveRange(context.Flujos_Aprobaciones
                .Where(x => x.IdTicket.ToString().ToUpper() == tipo_TicketDTO.Id.ToUpper()).ToList());

            context.DepartamentoTipo_Ticket.RemoveRange(context.DepartamentoTipo_Ticket
                .Where(x => x.Tipo_Ticekt_Id.ToString().ToUpper() == tipo_TicketDTO.Id.ToUpper()).ToList());
        }

        private Tipo_Ticket LlenarTipoTicket(Tipo_TicketDTOUpdate tipo_TicketDTO)
        {
            var tipo_ticket = context.Tipos_Tickets.Find(Guid.Parse(tipo_TicketDTO.Id));
            tipo_ticket = TipoTicketFactory.CambiarFlujoTipoTicket(tipo_ticket, tipo_TicketDTO.tipo, _mapper);
            tipo_ticket.nombre = tipo_TicketDTO.nombre;
            tipo_ticket.descripcion = tipo_TicketDTO.descripcion;
            tipo_ticket.fecha_ult_edic = DateTime.UtcNow;
            tipo_ticket.Minimo_Aprobado = tipo_TicketDTO.Minimo_Aprobado;
            tipo_ticket.Maximo_Rechazado = tipo_TicketDTO.Maximo_Rechazado;
            return tipo_ticket;
        }

        public ApplicationResponse<Tipo_TicketDTOCreate> RegistroTipo_Ticket(Tipo_TicketDTOCreate Tipo_TicketDTO)
        {
            var response = new ApplicationResponse<Tipo_TicketDTOCreate>();
            try
            {
                //ValidarDatos
                ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTO);

                var tipo_ticket = TipoTicketFactory.ObtenerInstancia(Tipo_TicketDTO.tipo);
                tipo_ticket.LlenarDatos(Tipo_TicketDTO.nombre, Tipo_TicketDTO.descripcion, Tipo_TicketDTO.tipo, Tipo_TicketDTO.Minimo_Aprobado, Tipo_TicketDTO.Maximo_Rechazado);
                
                try
                {
                    tipo_ticket.Departamentos =
                    context.Departamentos
                    .Where(x => Tipo_TicketDTO.Departamento.Select(y => y).Contains(x.id.ToString().ToUpper()))
                    .Select(s => new DepartamentoTipo_Ticket()
                    {
                        departamento = s,
                        DepartamentoId = s.id,
                        tipo_Ticket = tipo_ticket,
                        Tipo_Ticekt_Id = tipo_ticket.Id
                    }).ToList();
                    /*tipo_ticket.Departamentos =
                    context.DepartamentoTipo_Ticket.Where(x => Tipo_TicketDTO.Departamento.Contains(x.id.ToString())).ToList();*/
                }
                catch (Exception) { }
                try
                {
                    var Cargos = context.Cargos.Where(x => Tipo_TicketDTO.Flujo_Aprobacion
                        .Select(x => x.IdCargo.ToUpper()).ToList().Contains(x.id.ToString().ToUpper()));
                    tipo_ticket.Flujo_Aprobacion = new List<Flujo_Aprobacion>();
                    foreach (var c in Cargos)
                    {
                        tipo_ticket.Flujo_Aprobacion.Add(new Flujo_Aprobacion()
                        {
                            IdTicket = tipo_ticket.Id,
                            Tipo_Ticket = tipo_ticket,
                            IdCargo = c.id,
                            Cargo = c
                        });
                    }
                    /*
                    tipo_ticket.Flujo_Aprobacion =
                    context.Tipos_Cargos
                    .Where(x => Tipo_TicketDTO.Flujo_Aprobacion.Select(y => y.IdTipoCargo).Contains(x.id.ToString().ToUpper()))
                    .Select(s => new Flujo_Aprobacion()
                    {
                        Tipo_Cargo = s,
                        IdTipo_cargo = s.id,
                        Tipo_Ticket = tipo_ticket,
                        IdTicket = tipo_ticket.Id
                    }).ToList();*/
                    foreach (Flujo_Aprobacion fa in tipo_ticket.Flujo_Aprobacion)
                    {
                        var t = Tipo_TicketDTO.Flujo_Aprobacion.Where(x => x.IdCargo.ToUpper() == fa.IdCargo.ToString().ToUpper()).FirstOrDefault();

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

                response.Data = TipoTicketMapper.MapperTipoTicketToTipoTicketDTOCreate(tipo_ticket);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Exception = ex.Mensaje;
            }

            return response;
        }


        public void ValidarDatosEntradaTipo_Ticket_Update(Tipo_Ticket tipo_ticket)
        {
            try
            {
                //Verificar si el tipo ticket existe
                var tipo_actual_actual = context.Tipos_Tickets.Find(tipo_ticket.Id);
                if (tipo_actual_actual == null)
                {
                    throw new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
                }


                //Verificar si el tipo de aprobacion es igual
                if (tipo_actual_actual.ObtenerTipoAprobacion() != tipo_ticket.ObtenerTipoAprobacion())
                {
                    //Validar si no existe Ticket Activo
                    var ticketsPendientes = context.Tickets.Include(x => x.Tipo_Ticket).Include(x => x.Estado).ThenInclude(x => x.Estado_Padre)
                        .Where(x => x.Tipo_Ticket.Id == tipo_actual_actual.Id &&
                        x.Estado.Estado_Padre.nombre == "Pendiente").Count();
                    if (ticketsPendientes > 0)
                    {
                        throw new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
                    }
                }


                var tipo_TicketDTOCreate = _mapper.Map<Tipo_TicketDTOCreate>(tipo_ticket);
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
                    Flujo_Aprobacion = _mapper.Map<List<Flujo_AprobacionDTOSearch>>(data.Flujo_Aprobacion),
                    Departamento = listaDept
                };

                return tipo_ticketsDTO;
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
                    Flujo_Aprobacion = _mapper.Map<List<Flujo_AprobacionDTOSearch>>(data.Flujo_Aprobacion),
                    Departamento = listaDept
                };

                return tipo_ticketsDTO;
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

        public List<Tipo_TicketDTOSearch> ConsultaTipoTicketAgregarTicket(Guid Id)
        {
            var ListaTipoTicket = context.Tipos_Tickets.Include(x => x.Departamentos).ThenInclude(x=>x.departamento).Where(x => x.Departamentos.Select(x => x.departamento.id).Contains(Id)).ToList();
            ListaTipoTicket.AddRange(context.Tipos_Tickets.Include(x => x.Departamentos).Where(x => x.Departamentos.Count==0).ToList());
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
