using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public interface ITicketDAO
    {
        public string crearTicket(TicketNuevoDTO nuevoTicket);
        public Ticket obtenerTicketPorId(Guid id);
        public List<Ticket> obtenerTickets(Guid departamento, string opcion);
        public List<Ticket> obtenerTicketPorEstadoYDepartamento(Guid idDepartamento, string estado);
        public string anadirALaBitacora(TicketDTO ticketDTO);
        public string crearFamiliaTickets(TicketDTO ticketA, TicketDTO ticketB);
        public List<Ticket> obtenerFamiliaTickets(Guid ticketId);
        public string mergeTickets(TicketDTO ticketPrincipal, List<TicketDTO> tickets);
        public string crearTicketHijo(TicketDTO ticketPadre, TicketDTO ticketHjo);
        public string votarTicket(TicketDTO ticket, VotoTicketDTO voto_descripcion);
    }
}
