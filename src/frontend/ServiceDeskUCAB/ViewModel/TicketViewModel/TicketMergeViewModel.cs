using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel
{
	public class FamiliaMergeDTOViewModel
    {
		public TicketCompletoDTO ticket;

		public List<TicketBasicoDTO> tickets;

		public Familia_Ticket familiaTicket;
	}
}

