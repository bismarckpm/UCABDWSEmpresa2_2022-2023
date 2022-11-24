using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO
{
    public class Votos_TicketDTOCreate
    {
        public string IdUsuario { get; set; }
        public string IdTicket { get; set; }
        public string voto { get; set; }

        public string comentario { get; set; }
    }
}
