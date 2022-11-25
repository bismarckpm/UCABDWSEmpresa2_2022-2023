using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public class TicketDAO : ITicketDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;

        public TicketDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public ApplicationResponse<string> crearTicket(TicketNuevoDTO solicitudTicket)
        {
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            try
            {
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.nuevoTicketEsValido(solicitudTicket);
                TicketDTO nuevoTicket = crearNuevoTicket(solicitudTicket);
                respuesta.Data = "Ticket creado satisfactoriamente";
                respuesta.Message = "Ticket creado satisfactoriamente";
                respuesta.Success = true;
            } catch(TicketException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(TicketDescripcionException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(TicketEmisorException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(TicketPrioridadException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(TicketTipoException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(TicketDepartamentoException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch(Exception e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorId(Guid id)
        {
            ApplicationResponse<TicketInfoCompletaDTO> respuesta = new ApplicationResponse<TicketInfoCompletaDTO>();
            try
            {
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.validarTicket(id);
                respuesta.Data = rellenarTicketInfoCompletaHl(id);
                respuesta.Message = "Proceso de búsqueda exitoso";
                respuesta.Success = true;

            } catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch (Exception e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado)
        {
            ApplicationResponse<List<TicketInfoBasicaDTO>> respuesta = new ApplicationResponse<List<TicketInfoBasicaDTO>>();
            try
            {
                //estado {Abiertos, Cerrados, Todos}
                //Abiertos son los que la fecha de eliminación es null y estado padre es diferente de "Pendiente" y "Rechazado".
                //Cerrados son los que tienen fecha de eliminación y estado padre es diferente de "Pendiente" y "Rechazado".
                //Todos son los que estado padre es diferente de "Pendiente" y "Rechazado".

                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.validarDepartamento(idDepartamento);
                respuesta.Data = rellenarTicketInfoBasicaHl(idDepartamento, estado);
                respuesta.Message = "Proceso de búsqueda exitoso";
                respuesta.Success = true;
            } catch (TicketDepartamentoException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch (Exception e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<string> cambiarEstadoTicket(Guid ticketId, Guid estadoId)
        {
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            try
            {
                modificarEstadoTicket(ticketId, estadoId);
                respuesta.Data = "Estado del ticket modificado exitosamente";
                respuesta.Message = "Estado del ticket cambiado satisfactoriamente";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacoras(Guid ticketId)
        {
            ApplicationResponse<List<TicketBitacorasDTO>> respuesta = new ApplicationResponse<List<TicketBitacorasDTO>>();
            try
            {
                respuesta.Data = obtenerBitacorasHl(ticketId);
                respuesta.Message = "Búsqueda de bitácora exitosa";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<string> mergeTickets(Guid ticketId, List<Guid> ticketsSecundariosId)
        {
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            try
            {
                mergeTicketsHl(ticketId, ticketsSecundariosId);
                respuesta.Data = "Merge de tickets realizado satisfactoriamente";
                respuesta.Message = "Proceso de Merge exitoso";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerFamiliaTickets(Guid ticketId)
        {
            ApplicationResponse<List<TicketInfoBasicaDTO>> respuesta = new ApplicationResponse<List<TicketInfoBasicaDTO>>();
            try
            {
                respuesta.Data = obtenerFamiliaTicketsHl(ticketId);
                respuesta.Message = "Proceso de obtención de familia ticket exitoso";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<string> reenviarTicket(TicketReenviarDTO solicitudTicket)
        {
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            TicketNuevoDTO ticket = new TicketNuevoDTO();
            ticket.departamentoDestino_Id = solicitudTicket.departamentoDestino_Id;
            ticket.descripcion = solicitudTicket.descripcion;
            ticket.empleado_id = solicitudTicket.empleado_id;
            ticket.prioridad_id = solicitudTicket.prioridad_id;
            ticket.tipoTicket_id = solicitudTicket.tipoTicket_id;
            ticket.titulo = solicitudTicket.titulo;
            ticket.ticketPadre_Id = solicitudTicket.ticketPadre_Id;

            try
            {
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.nuevoTicketEsValido(ticket);
                TicketDTO nuevoTicket = crearNuevoTicket(ticket);

                respuesta.Data = "Ticket Reenviado satisfactoriamente";
                respuesta.Message = "Ticket Reenviado satisfactoriamente";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketDescripcionException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketEmisorException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketPrioridadException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketTipoException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketDepartamentoException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (TicketPadreException e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            catch (Exception e)
            {
                respuesta.Data = e.Message;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            }
            return respuesta;
        }

        public ApplicationResponse<List<TicketInfoCompletaDTO>> obtenerFamiliaTicket(Guid ticketPrincipalId)
        {
            ApplicationResponse<List<TicketInfoCompletaDTO>> respuesta = new ApplicationResponse<List<TicketInfoCompletaDTO>>();
            try
            {
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.validarTicket(ticketPrincipalId);
                List<TicketInfoCompletaDTO> lista = new List<TicketInfoCompletaDTO>();
                Ticket ticket = _dataContext.Tickets.Include(t => t.Familia_Ticket).Include(t => t.Familia_Ticket.Lista_Ticket).Where(t => t.Id == ticketPrincipalId).Single();
                if (ticket.Familia_Ticket == null)
                    throw new Exception("El ticket no tiene familia definida");
                ticket.Familia_Ticket.Lista_Ticket.ForEach(delegate (Ticket e)
                {
                    lista.Add(rellenarTicketInfoCompletaHl(e.Id));
                });
                if (lista.Count == 0)
                    throw new Exception("El ticket no tiene integrantes en su familia");
                respuesta.Data = lista;
                respuesta.Message = "Mano ahí tienes a tu familia de tickets criminal tu eres loco";
                respuesta.Success = true;
            }
            catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = true;
            }
            catch (Exception e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = true;
            }
            return respuesta;
        }

        public ApplicationResponse<string> mergeTicketsHl(Guid ticketPrincipalId, List<Guid> ticketsSecundariosId)
        {
            //CREAR LA FAMILIA TICKET, Y PONER FECHA FIN A LOS QUE ESTÁN EN LA LISTA!
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            try
            {
                Familia_Ticket nuevaFamilia = new Familia_Ticket
                {
                    Id = new Guid(),
                    Lista_Ticket = new List<Ticket>()
                };
                ticketsSecundariosId.ForEach(delegate (Guid e)
                {
                    anadirFamilia(e, nuevaFamilia, false);
                });
                anadirFamilia(ticketPrincipalId, nuevaFamilia, true);
                respuesta.Data = "Proceso de Merge realizado exitosamente";
                respuesta.Message = "Mano hicimos merge tu eres loco";
                respuesta.Success = true;
            }
            catch (Exception e)
            {
                respuesta.Data = "Proceso de Merge no se procesó exitosamente";
                respuesta.Message = e.Message;
                respuesta.Success = true;
            }
            return respuesta;
        }

        //HELPERS

        public TicketDTO crearNuevoTicket(TicketNuevoDTO solicitudTicket)
        {
            TicketDTO nuevoTicket = _mapper.Map<TicketDTO>(solicitudTicket);
            nuevoTicket.Id = new Guid();
            nuevoTicket.fecha_creacion = DateTime.UtcNow;
            nuevoTicket.fecha_eliminacion = DateTime.MinValue;
            nuevoTicket.Emisor = _dataContext.Empleados
                                                .Include(t => t.Cargo)
                                                .Where(empleado => empleado.Id == solicitudTicket.empleado_id).FirstOrDefault();
            Cargo cargo = _dataContext.Cargos
                                       .Include(t => t.Departamento)
                                       .Where(t => t.Id == nuevoTicket.Emisor.Cargo.Id).FirstOrDefault();
            Guid prueba = cargo.Departamento.Id;
            nuevoTicket.Departamento_Destino = _dataContext.Departamentos.Where(departamento => departamento.Id == solicitudTicket.departamentoDestino_Id).FirstOrDefault();
            Estado estado = _dataContext.Estados
                                                .Include(t => t.Estado_Padre)
                                                .Include(t => t.Departamento)
                                                .Where(x => x.Estado_Padre.nombre == "Pendiente" && x.Departamento.Id == cargo.Departamento.Id).FirstOrDefault();
            if (estado == null)
                throw new Exception("No se halló el estado para el ticket");
            else
                nuevoTicket.Estado = estado;

            nuevoTicket.Prioridad = _dataContext.Prioridades.Where(prioridad => prioridad.Id == solicitudTicket.prioridad_id).FirstOrDefault();
            nuevoTicket.Tipo_Ticket = _dataContext.Tipos_Tickets.Where(tipoTicket => tipoTicket.Id == solicitudTicket.tipoTicket_id).FirstOrDefault();

            if(solicitudTicket.ticketPadre_Id != Guid.Empty)
            {
                nuevoTicket.Ticket_Padre = _dataContext.Tickets.Where(padre => padre.Id == solicitudTicket.ticketPadre_Id).FirstOrDefault();
                Ticket ticketPadre = _dataContext.Tickets.Where(t => t.Id == solicitudTicket.ticketPadre_Id).FirstOrDefault();
                ticketPadre.fecha_eliminacion = DateTime.Now;
            }
            else
            {

                nuevoTicket.Ticket_Padre = null;
            }

            nuevoTicket.nro_cargo_actual = null;
            nuevoTicket.Votos_Ticket = null;
            try
            {
                nuevoTicket.Bitacora_Tickets = new HashSet<Bitacora_Ticket>
                {
                    crearNuevaBitacora(nuevoTicket)
                };
            } catch(Exception e)
            {
                throw new Exception("No se pudo crear la Bitacora para el ticket", e);
            }
            if (nuevoTicket.Bitacora_Tickets == null)
                throw new Exception("La Bitacora para el ticket no pudo ser creada");
            _dataContext.Tickets.Add(_mapper.Map<Ticket>(nuevoTicket));
            //_dataContext.Bitacora_Tickets.Add(nuevoTicket.Bitacora_Tickets.First());
            _dataContext.DbContext.SaveChanges();
            return nuevoTicket;
        }

        public Bitacora_Ticket crearNuevaBitacora(TicketDTO ticket)
        {
            Bitacora_Ticket nuevaBitacora = new Bitacora_Ticket()
            {
                Id = Guid.NewGuid(),
                Estado = ticket.Estado,
                Ticket = _mapper.Map<Ticket>(ticket),
                Fecha_Inicio = DateTime.Today,
                Fecha_Fin = DateTime.MinValue
            };
            return nuevaBitacora;
        }

        public void modificarEstadoTicket(Guid ticketId, Guid estadoId)
        {
            TicketValidaciones ticketValidaciones = new TicketValidaciones(_dataContext);
            ticketValidaciones.validarTicket(ticketId);
            TicketDTO ticket = _mapper.Map<TicketDTO>(_dataContext.Tickets.Where(tickets => tickets.Id == ticketId).Single());
            Estado nuevoEstado = _dataContext.Estados.AsNoTracking().Where(estados => estados.Id == estadoId).Single();
            ticket.Estado = nuevoEstado;
            List<TicketBitacorasDTO> listaBitacoras = obtenerBitacorasHl(ticketId);
            listaBitacoras.Last().Fecha_Fin = DateTime.UtcNow;
            //_dataContext.Bitacora_Tickets.Update(_mapper.Map<Bitacora_Ticket>(listaBitacoras.Last()));
            Bitacora_Ticket bitacoraTicket = _mapper.Map<Bitacora_Ticket>(listaBitacoras.Last());
            ticket.Bitacora_Tickets.Add(crearNuevaBitacora(ticket));
            //_dataContext.Bitacora_Tickets.Add(ticket.Bitacora_Tickets.Last());
            _dataContext.Tickets.Update(_mapper.Map<Ticket>(ticket));
            _dataContext.DbContext.SaveChanges();
        }

        public List<TicketBitacorasDTO> obtenerBitacorasHl(Guid ticketId)
        {
            TicketValidaciones ticketValidaciones = new TicketValidaciones(_dataContext);
            ticketValidaciones.validarTicket(ticketId);
            List<Bitacora_Ticket> listaBitacoras = _dataContext.Bitacora_Tickets
                                                                    .AsNoTracking()
                                                                    .Include(x => x.Ticket)
                                                                    .Include(x => x.Estado)
                                                                    .Where(x => x.Ticket.Id == ticketId)
                                                                    .ToList();
            if (listaBitacoras.Count == 0)
                throw new Exception("Lista de Bitacoras vacías");
            List<TicketBitacorasDTO> bitacoras = new List<TicketBitacorasDTO>();
            listaBitacoras.ForEach(delegate (Bitacora_Ticket bitacora)
            {
                bitacoras.Add(new TicketBitacorasDTO
                {
                    Id = bitacora.Id,
                    estado_nombre = bitacora.Estado.nombre,
                    Fecha_Inicio = bitacora.Fecha_Inicio,
                    Fecha_Fin = bitacora.Fecha_Fin
                });
            });
            return bitacoras;
        }

        public void inicializarFamiliaTicketHl(TicketDTO nuevoTicket)
        {   //PARA LOS TICKETS HERMANOS
            nuevoTicket.Familia_Ticket = new Familia_Ticket()
            {
                Id = Guid.NewGuid(),
                Lista_Ticket = new List<Ticket>()
            };
        }

        public TicketInfoCompletaDTO rellenarTicketInfoCompletaHl(Guid id)
        {
            Ticket ticket = _dataContext.Tickets
                                .Include(t => t.Estado)
                                .Include(t => t.Tipo_Ticket)
                                .Include(t => t.Departamento_Destino)
                                .Include(t => t.Prioridad)
                                .Include(t => t.Emisor)
                                .Where(ticket => ticket.Id == id).Single();
            Guid idPadre;
            if (ticket.Ticket_Padre == null || ticket.Ticket_Padre.Id.Equals(Guid.Empty))
                idPadre = Guid.Empty;
            else
                idPadre = ticket.Ticket_Padre.Id;
            Guid prueba = ticket.Estado.Id;
            return new TicketInfoCompletaDTO
            {
                ticket_id = id,
                ticketPadre_id = idPadre,
                fecha_creacion = ticket.fecha_creacion,
                fecha_eliminacion = ticket.fecha_eliminacion,
                titulo = ticket.titulo,
                descripcion = ticket.descripcion,
                estado_nombre = ticket.Estado.nombre,
                tipoTicket_nombre = ticket.Tipo_Ticket.nombre,
                departamentoDestino_nombre = ticket.Departamento_Destino.nombre,
                prioridad_nombre = ticket.Prioridad.nombre,
                empleado_correo = ticket.Emisor.correo,
            };
        }

        public List<TicketInfoBasicaDTO> rellenarTicketInfoBasicaHl(Guid idDepartamento, string opcion)
        {
            List<TicketDTO> tickets;
            if (opcion == "Todos")
                tickets = _mapper.Map<List<TicketDTO>>(_dataContext.Tickets
                                                                    .Include(t => t.Emisor)
                                                                    .Include(t => t.Prioridad)
                                                                    .Include(t => t.Tipo_Ticket)
                                                                    .Include(t => t.Estado)
                                                                    .Where(ticket => ticket.Departamento_Destino.Id == idDepartamento && ticket.Estado.Estado_Padre.nombre != "Pendiente" && ticket.Estado.Estado_Padre.nombre != "Rechazado").ToList());
            else if (opcion == "Abiertos")
                tickets = _mapper.Map<List<TicketDTO>>(_dataContext.Tickets
                                                                    .Include(t => t.Emisor)
                                                                    .Include(t => t.Prioridad)
                                                                    .Include(t => t.Tipo_Ticket)
                                                                    .Include(t => t.Estado)
                                                                    .Where(ticket => ticket.Departamento_Destino.Id == idDepartamento && ticket.fecha_eliminacion.Equals(DateTime.MinValue) && ticket.Estado.Estado_Padre.nombre != "Pendiente" && ticket.Estado.Estado_Padre.nombre != "Rechazado").ToList());
            else if (opcion == "Cerrados")
                tickets = _mapper.Map<List<TicketDTO>>(_dataContext.Tickets
                                                                    .Include(t => t.Emisor)
                                                                    .Include(t => t.Prioridad)
                                                                    .Include(t => t.Tipo_Ticket)
                                                                    .Include(t => t.Estado)
                                                                    .Where(ticket => ticket.Departamento_Destino.Id == idDepartamento && ticket.fecha_eliminacion != DateTime.MinValue && ticket.Estado.Estado_Padre.nombre != "Pendiente" && ticket.Estado.Estado_Padre.nombre != "Rechazado").ToList());
            else
                throw new TicketException("Lista de tickets no encontrada debido a que la opción de búsqueda no es válido");
            if (tickets.Count() == 0)
                throw new TicketException("No existen tickets que satisfagan el tipo de búsqueda");

            List<TicketInfoBasicaDTO> respuesta = new List<TicketInfoBasicaDTO>();
            tickets.ForEach(delegate (TicketDTO ticket)
            {
                respuesta.Add(new TicketInfoBasicaDTO
                {
                    Id = ticket.Id,
                    titulo = ticket.titulo,
                    empleado_correo = ticket.Emisor.correo,
                    prioridad_nombre = ticket.Prioridad.nombre,
                    fecha_creacion = ticket.fecha_creacion,
                    tipoTicket_nombre = ticket.Tipo_Ticket.nombre,
                    estado_nombre = ticket.Estado.nombre
                });
            });
            return respuesta;
        }

        public void anadirFamilia(Guid id, Familia_Ticket nuevaFamilia, bool ticketPrincipal)
        {
            Ticket ticket = _dataContext.Tickets.Where(t => t.Id == id).Single();
            nuevaFamilia.Lista_Ticket.Add(ticket);
            if (!ticketPrincipal)
                ticket.fecha_eliminacion = DateTime.UtcNow;
            else
                ticket.Familia_Ticket = nuevaFamilia;
            _dataContext.DbContext.Update(ticket);
            _dataContext.DbContext.SaveChanges();
        }

        public List<TicketInfoBasicaDTO> obtenerFamiliaTicketsHl(Guid id)
        {
            TicketValidaciones ticketValidaciones = new TicketValidaciones(_dataContext);
            ticketValidaciones.validarTicket(id);
            List<TicketInfoBasicaDTO> listaTickets = new List<TicketInfoBasicaDTO>();
            TicketDTO ticket = _mapper.Map<TicketDTO>(_dataContext.Tickets.Where(ticket => ticket.Id == id).Single());

            return listaTickets;
        }

        
    }
}
