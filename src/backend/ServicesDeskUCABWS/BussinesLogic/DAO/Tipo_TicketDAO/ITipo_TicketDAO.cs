using System.Threading.Tasks;
using System;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO
{
    public interface ITipo_TicketDAO
    {
        public IEnumerable<Tipo_TicketDTOSearch> ConsultarTipoTicket();
        public ApplicationResponse<Tipo_Ticket> RegistroTipo_Ticket(Tipo_TicketDTOCreate Tipo_TicketDTO);
        public ApplicationResponse<Tipo_Ticket> ActualizarTipo_Ticket(Tipo_TicketDTOUpdate tipo_Ticket);

        public void ValidarDatosEntradaTipo_Ticket_Update(Tipo_TicketDTOUpdate tipo_TicketDTOUpdate);
        public void ValidarDatosEntradaTipo_Ticket(Tipo_TicketDTOCreate tipo_TicketDTOCreate);
        

        public Task<Tipo_TicketDTOSearch> ConsultarTipoTicketGUID(Guid id);

        public Task<Tipo_TicketDTOSearch> ConsultarTipoTicketNomb(string nombre);

        public Boolean EliminarTipoTicket(Guid id);
    }
}
