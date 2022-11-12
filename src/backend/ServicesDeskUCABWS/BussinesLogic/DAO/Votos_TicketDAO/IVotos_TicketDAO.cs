using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO
{
    public interface IVotos_TicketDAO
    {
        public ApplicationResponse<Votos_TicketDTOCreate> Votar(Votos_TicketDTOCreate votoDTO);
        bool AgregarVoto(List<Votos_Ticket> ListaVotos);
    }
}
