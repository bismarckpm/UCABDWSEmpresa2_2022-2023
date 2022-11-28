using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;

namespace ServiceDeskUCAB.ViewModel
{
    public class FamiliaMergeDTOViewModel
    {
        public TicketCompletoDTO ticket;

        public List<TicketBasicoDTO> tickets;

        public FamiliaMergeDTO familiaTicket;
    }
}