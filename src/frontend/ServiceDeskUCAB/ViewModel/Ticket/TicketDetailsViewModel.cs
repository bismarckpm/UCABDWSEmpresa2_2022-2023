using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel
{
    public class TicketDetailsViewModel
    {
        public TicketCompletoDTO ticket;

        public List<BitacoraDTO> bitacoraTicket;

        public List<Ticket> familiaTicket;

        public List<Estado> estados;

        public int estadoId;
    }
}