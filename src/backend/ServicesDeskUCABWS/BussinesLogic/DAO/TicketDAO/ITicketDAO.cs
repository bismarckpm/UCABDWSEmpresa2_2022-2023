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
    }
}
