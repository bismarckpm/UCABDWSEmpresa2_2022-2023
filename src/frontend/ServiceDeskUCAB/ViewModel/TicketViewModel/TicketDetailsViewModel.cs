using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.TicketDTO;
using ServicesDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel
{
	public class TicketDetailsViewModel
	{
		public TicketCompletoDTO ticket;

		public List<BitacoraDTO> bitacoraTicket;

		public List<Ticket> familiaTicket;

		public List<Estado> estados;

		public ActualizarDTO actualizarDTO;
	}
}

