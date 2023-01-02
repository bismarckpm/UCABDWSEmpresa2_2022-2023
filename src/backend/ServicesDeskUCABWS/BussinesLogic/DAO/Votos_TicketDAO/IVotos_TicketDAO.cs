using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO
{
    public interface IVotos_TicketDAO
    {
        public ApplicationResponse<Votos_Ticket> Votar(Votos_TicketDTOCreate votoDTO);
        bool AgregarVoto(List<Votos_Ticket> ListaVotos);
        ApplicationResponse<List<Votos_Ticket>> ConsultaVotos(Guid id);

        ApplicationResponse<List<Votos_Ticket>> ConsultaVotosNoPendientes(Guid id);
    }
}
