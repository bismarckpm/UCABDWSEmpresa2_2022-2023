using System;
using System.Collections.Generic;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.ViewModel
{
	public class TicketDetailsViewModel
	{
		public TicketInfoCompleta ticket;

		public List<TicketBitacora> bitacoraTicket;

		public List<Ticket> familiaTicket;

		public List<Estado> estados;

		public string message;
	}
}

