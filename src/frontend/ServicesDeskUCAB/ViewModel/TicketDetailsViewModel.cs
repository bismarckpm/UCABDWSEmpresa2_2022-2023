using System;
using System.Collections.Generic;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.ViewModel
{
	public class TicketDetailsViewModel
	{
		public Ticket ticket;

		public List<Bitacora_Ticket> bitacoraTicket;

		public Familia_Ticket familiaTicket;

		public List<Estado> estados;

		public string message;
	}
}

