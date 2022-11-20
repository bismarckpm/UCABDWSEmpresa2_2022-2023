using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using ServicesDeskUCABWS.BussinesLogic.Helpers;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public class TicketDAO : ITicketDAO
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly TicketHelpers _helper;

        public TicketDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _helper = new TicketHelpers(dataContext, mapper);
        }

        public string crearTicket(TicketNuevoDTO solicitudTicket)
        {
            try
            {
                TicketExceptions.getInstance().nuevoTicketEsValido(solicitudTicket);
                Departamento departamentoSalida = _dataContext.Departamentos.Where(x => x.nombre == solicitudTicket.departamentoSalida_nombre).Single();
                Usuario usuario = _dataContext.Usuarios.Where(x => x.Id == solicitudTicket.usuario_id).Single();
                Departamento departamentoDestino = _dataContext.Departamentos.Where(x => x.nombre == solicitudTicket.departamentoDestino_nombre).FirstOrDefault();
                Estado estado = _dataContext.Estados.Where(x => x.nombre == solicitudTicket.estado_nombre).FirstOrDefault();
                Prioridad prioridad = _dataContext.Prioridades.Where(x => x.nombre == solicitudTicket.prioridad_nombre).FirstOrDefault();
                Tipo_Ticket tipoTicket = _dataContext.Tipos_Tickets.Where(x => x.nombre == solicitudTicket.tipoTicket_nombre).FirstOrDefault();
                TicketDTO nuevoTicketDTO = _mapper.Map<TicketDTO>(solicitudTicket);
                nuevoTicketDTO.Departamento_Destino = departamentoDestino;
                nuevoTicketDTO.Estado = estado;
                nuevoTicketDTO.Prioridad = prioridad;
                nuevoTicketDTO.Tipo_Ticket = tipoTicket;
                nuevoTicketDTO.usuario = usuario;
                nuevoTicketDTO.departamento_usuario = departamentoSalida;
                _helper.inicializarBitacora(nuevoTicketDTO);
                _dataContext.Tickets.Add(_mapper.Map<Ticket>(nuevoTicketDTO));
                departamentoSalida.ListaTickets.Add(_mapper.Map<Ticket>(nuevoTicketDTO));
                departamentoDestino.ListaTickets.Add(_mapper.Map<Ticket>(nuevoTicketDTO));
                _dataContext.SaveChangesAsync();
                return "Ticket creado satisfactoriamente";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public Ticket obtenerTicketPorId(Guid id)
        {
            try
            {
                return _dataContext.Tickets.Where(d => d.Id == id).Single();
                //return "Ticket creado satisfactoriamente";
            }
            catch (Exception exception)
            {
                return null;
                //return exception.Message;
            }
        }
        public List<Ticket> obtenerTickets(Guid departamento, string opcion)
        {
            try
            {
                return _dataContext.Tickets.Where(d => d.Departamento_Destino.Id == departamento).ToList();
            }
            catch (Exception exception)
            {
                return null; //POR DESARROLLAR
                //return exception.Message;
            }
        }
        public List<Ticket> obtenerTicketPorEstadoYDepartamento(Guid idDepartamento, string estado)
        {
            try
            {
                return _dataContext.Tickets.Where(d => d.Departamento_Destino.Id == idDepartamento && d.Estado.nombre == estado).ToList();
                //return "Ticket creado satisfactoriamente";
            }
            catch (Exception exception)
            {
                return null;
                //return exception.Message;
            }
        }
        public string anadirALaBitacora(TicketDTO ticketDTO)
        {
            try
            {
                ticketDTO.Bitacora_Tickets.Add(_helper.crearNuevaBitacora(ticketDTO));
                _dataContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketDTO)));
                _dataContext.SaveChangesAsync();
                return "Bitacora añadida satisfactoriamente";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public string crearFamiliaTickets(TicketDTO ticketA, TicketDTO ticketB)
        {
            try
            {
                ticketA.Familia_Ticket.Lista_Ticket.Add(_mapper.Map<Ticket>(ticketB));
                _dataContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketA)));
                ticketB.Familia_Ticket.Lista_Ticket.Add(_mapper.Map<Ticket>(ticketA));
                _dataContext.Update(_dataContext.Tickets.Update(_mapper.Map<Ticket>(ticketB)));
                _dataContext.SaveChangesAsync();
                return "Proceso realizado exitosamente";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
        public List<Ticket> obtenerFamiliaTickets(Guid ticketId)
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
                return null;
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
                    ticket.fecha_eliminacion = new DateTime();
                    ticket.Estado.nombre = "Eliminado"; //->VERIFICAR
                    ticket.Bitacora_Tickets.Add(_helper.crearNuevaBitacora(ticket));
                });
                _dataContext.SaveChangesAsync();
                return "PROCESO DE MERGE REALIZADO CORRECTAMENTE!";
            }
            catch (Exception exception)
            {
                return "EL MERGE NO SE PUDO LOGRAR SATISFACTORIAMENTE";
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
                _dataContext.SaveChangesAsync();
                return "Ticket hijo creado satisfactoriamente";
            }
            catch (Exception exception)
            {
                return "Ticket hijo no fue creado exitosamente";
            }
            //POR DESARROLLAR
        }
        
    }
}
