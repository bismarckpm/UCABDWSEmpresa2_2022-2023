using AutoMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.Helpers;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public class TicketDAO : ITicketDAO
    {
        private readonly IDataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly TicketHelpers _helper;

        public TicketDAO(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _helper = new TicketHelpers(dataContext, mapper);
        }

        public ApplicationResponse<string> crearTicket(TicketNuevoDTO solicitudTicket)
        {
            ApplicationResponse<string> respuesta = new ApplicationResponse<string>();
            try
            {
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.nuevoTicketEsValido(solicitudTicket);
                TicketDTO nuevoTicket = _helper.crearNuevoTicket(solicitudTicket);
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
                respuesta.Data = "Error 404";
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
                respuesta.Data = _helper.rellenarTicketInfoCompleta(id);
                respuesta.Message = "Ticket creado satisfactoriamente";
                respuesta.Success = true;

            } catch (TicketException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch (Exception e)
            {
                respuesta.Data = null;
                respuesta.Message = "Error 404";
                respuesta.Success = false;
            }
            return respuesta;
        }
        /*public List<Ticket> obtenerTickets(Guid departamento, string opcion)
        {
            try
            {
                return _dataContext.Tickets.Where(d => d.Departamento_Destino.Id == departamento).ToList();
            }
            catch (Exception exception)
            {
                throw new Exception("No se pudo obtener la lista de tickets");
                //return exception.Message;
            }
        }*/
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado)
        {
            ApplicationResponse<List<TicketInfoBasicaDTO>> respuesta = new ApplicationResponse<List<TicketInfoBasicaDTO>>();
            try
            {
                //estado {Abiertos, Cerrados, Todos}
                //Abiertos son los que la fecha de eliminación es null
                //Cerrados son los que tienen fecha de eliminación.
                //Todos son todos puej
                //return "Ticket creado satisfactoriamente";
                TicketValidaciones validaciones = new TicketValidaciones(_dataContext);
                validaciones.validarDepartamento(idDepartamento);
                //respuesta.Data = _helper.rellenarTicketInfoCompleta(id);
                respuesta.Message = "Ticket creado satisfactoriamente";
                respuesta.Success = true;
            } catch (TicketDepartamentoException e)
            {
                respuesta.Data = null;
                respuesta.Message = e.Message;
                respuesta.Success = false;
            } catch (Exception e)
            {
                respuesta.Data = null;
                respuesta.Message = "Error 404";
                respuesta.Success = false;
            }
            return respuesta;
        }
        /*public string anadirALaBitacora(TicketDTO ticketDTO)
        {
            try
            {
                ticketDTO.Bitacora_Tickets.Add(_helper.crearNuevaBitacora(ticketDTO));//CORRECTO
                _dataContext.DbContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketDTO)));
                _dataContext.DbContext.SaveChangesAsync();
                return "Bitacora añadida satisfactoriamente";
            }
            catch (Exception exception)
            {
                throw new Exception("No se puede añadir a la bitacora");
            }
        }
        public string crearFamiliaTickets(TicketDTO ticketA, TicketDTO ticketB)
        {
            try
            {
                ticketA.Familia_Ticket.Lista_Ticket.Add(_mapper.Map<Ticket>(ticketB));
                _dataContext.DbContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketA)));
                ticketB.Familia_Ticket.Lista_Ticket.Add(_mapper.Map<Ticket>(ticketA));
                _dataContext.DbContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketB)));
                _dataContext.DbContext.SaveChangesAsync();
                return "Proceso realizado exitosamente";
            }
            catch (Exception exception)
            {
                throw new Exception("No se pudo crear la familia de tickets"); ;
            }
        }
        public List<TicketInfoCompletaDTO> obtenerFamiliaTickets(Guid ticketId)
        {
            try
            {
                List<Ticket> listaTicket = new List<Ticket>();
                Ticket ticket = _dataContext.Tickets.Where(p=>p.Id == ticketId).Single();
                ticket.Familia_Ticket.Lista_Ticket.ForEach(delegate (Ticket t)
                {
                    listaTicket.Add(_mapper.Map<Ticket>(t));
                });
                return listaTicket;
            }
            catch (Exception e)
            {
                throw new Exception("No se pudo obtener la familia de tickets");
            }
        }
        public string mergeTickets(TicketDTO ticketPrincipal, List<TicketDTO> tickets)
        {
            try
            {
                //(EL MERGE ES CON LOS TICKETS HERMANOS, NO CON LOS TICKETS HIJOS)
                //EL CLIENTE ENVÍA EL TICKET PRINCIPAL Y LA LISTA DE TICKETS HERMANOS (O DE TODOS LOS TICKETS)
                //SE CAMBIA LA FECHA DE ELIMINACIÓN A ACTUAL
                //CAMBIAR EL ESTADO DE LOS HERMANOS A ELIMINADO O COMPLETADO
                //NO SE BORRAN
                //ACTUALIZAR LA BITACORA DE LOS TICKETS PORQUE SE CAMBIÓ EL ESTADO
                tickets.ForEach(delegate (TicketDTO ticket)
                {
                    //CREAR LA FAMILIA TICKET
                    ticket.fecha_eliminacion = new DateTime();
                    ticket.Estado.nombre = "Eliminado"; //->VERIFICAR
                    ticket.Bitacora_Tickets.Add(_helper.crearNuevaBitacora(ticket));
                });
                _dataContext.DbContext.SaveChangesAsync();
                return "PROCESO DE MERGE REALIZADO CORRECTAMENTE!";
            }
            catch (Exception exception)
            {
                throw new Exception("No se pudo hacer Merge de los tickets");
            }
        }
        public string crearTicketHijo(TicketDTO ticketPadre, TicketDTO ticketHijo)
        {
            try
            {
                //AL TICKET PADRE SE LE CAMBIA EL ESTADO A TICKET ELIMINADO
                ticketHijo.Ticket_Padre = _mapper.Map<Ticket>(ticketPadre);
                ticketPadre.fecha_eliminacion = new DateTime();
                ticketPadre.Estado.nombre = "CANCELADO"; //->VALIDAR
                anadirALaBitacora(ticketPadre);
                _dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketPadre));
                _dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketHijo));
                _dataContext.DbContext.SaveChangesAsync();
                return "Ticket hijo creado satisfactoriamente";
            }
            catch (Exception exception)
            {
                throw new Exception("No se pudo crear ticket hijo correctamente");
            }
            //POR DESARROLLAR
        }*/
    }
}
