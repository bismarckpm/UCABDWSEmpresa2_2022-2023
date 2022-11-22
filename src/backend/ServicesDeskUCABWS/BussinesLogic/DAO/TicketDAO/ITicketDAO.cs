using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public interface ITicketDAO
    {
        public ApplicationResponse<string> crearTicket(TicketNuevoDTO nuevoTicket);
        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorId(Guid id);
        //public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTickets(Guid departamento, string opcion);
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado);
        /*public string anadirALaBitacora(TicketDTO ticketDTO);
        public string crearFamiliaTickets(TicketDTO ticketA, TicketDTO ticketB);
        public List<TicketInfoCompletaDTO> obtenerFamiliaTickets(Guid ticketId);
        public string mergeTickets(TicketDTO ticketPrincipal, List<TicketDTO> tickets);
        public string crearTicketHijo(TicketDTO ticketPadre, TicketDTO ticketHjo);*/
    }
}
