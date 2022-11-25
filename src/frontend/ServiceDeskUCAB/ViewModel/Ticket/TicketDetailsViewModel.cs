using System;
using System.Collections.Generic;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.ViewModel
{
	public class TicketDetailsViewModel
	{
		public TicketCompletoDTO ticket;

		public List<BitacoraDTO> bitacoraTicket;

		public List<Ticket> familiaTicket;

		public List<Estado> estados;

		public string message;
	}
}

