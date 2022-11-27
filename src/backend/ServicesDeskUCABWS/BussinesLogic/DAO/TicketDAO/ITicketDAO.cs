using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO
{
    public interface ITicketDAO
    {
        public ApplicationResponse<TicketCreateDTO> RegistroTicket(TicketCreateDTO ticketDTO);
        public Task<bool> ActualizarTicket(Ticket ticket);
        public Task<bool> EliminarTicket(Guid Id);

        public string FlujoAprobacion(Ticket ticket);
        public string FlujoParalelo(Ticket ticket);
        public string FlujoNoAprobacion(Ticket ticket);
        public List<Ticket> ConsultaListaTickets();
        public Ticket ConsultaTicket(Guid id);

        public bool CambiarEstado(Ticket ticket, string Estado);
        //public ApplicationResponse<Votos_TicketDTOCreate> RegistroVotos(Votos_TicketDTOCreate votos_TicketDTO);
        public ApplicationResponse<string> crearTicket(TicketNuevoDTO nuevoTicket);
        public ApplicationResponse<TicketInfoCompletaDTO> obtenerTicketPorId(Guid id);
        public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerTicketsPorEstadoYDepartamento(Guid idDepartamento, string estado);
        public ApplicationResponse<string> cambiarEstadoTicket(Guid ticketId, Guid estadoId);
        public ApplicationResponse<List<TicketBitacorasDTO>> obtenerBitacoras(Guid ticketId);
        public ApplicationResponse<string> mergeTickets(Guid ticketPrincipalId, List<Guid> ticketsSecundariosId);
        public ApplicationResponse<string> reenviarTicket(TicketReenviarDTO solicitudTicket);
        //public ApplicationResponse<List<TicketInfoBasicaDTO>> obtenerFamiliaTickets(Guid ticketId);
        //public ApplicationResponse<string> reenviarTicket(Guid ticketId, TicketNuevoDTO solicitudTicket);
        public ApplicationResponse<List<TicketInfoCompletaDTO>> obtenerFamiliaTicket(Guid ticketPrincipalId);
        public ApplicationResponse<string> eliminarTicket(Guid id);
    }
}
