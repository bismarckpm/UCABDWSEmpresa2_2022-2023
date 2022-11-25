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
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado);
        public ApplicationResponse<string> cambiarEstadoTicket(Guid ticketId, Guid estadoId);
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacoras(Guid ticketId);
        public ApplicationResponse<string> mergeTickets(Guid ticketPrincipalId, List<Guid> ticketsSecundariosId);
        public ApplicationResponse<string> reenviarTicket(TicketReenviarDTO solicitudTicket);
        //public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerFamiliaTickets(Guid ticketId);
/*<<<<<<< HEAD*/
        //public ApplicationResponse<string> reenviarTicket(Guid ticketId, TicketNuevoDTO solicitudTicket);
/*=======
>>>>>>> 4708f2b59cb329db5dee460f059ad5cf5d73d1cc*/
    }
}
