using System.Threading.Tasks;
using System;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.CTipo_TicketDAO
{
    public interface ITipo_TicketDAO
    {
        public ApplicationResponse<Tipo_Ticket> RegistroTipo_Ticket(Tipo_TicketDTOCreate Tipo_TicketDTO);
        public ApplicationResponse<Tipo_TicketDTOUpdate> ActualizarTipo_Ticket(Tipo_TicketDTOUpdate tipo_Ticket);

        public void ValidarDatosEntradaTipo_Ticket_Update(Tipo_TicketDTOUpdate tipo_TicketDTOUpdate);
        public void ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTOCreate);
        public Task<bool> EliminarTipo_Ticket(Guid Id);
    }
}
