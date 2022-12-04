using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.DTO.DepartamentoDTO;
using ServiceDeskUCAB.Models.DTO.PrioridadDTO;
using ServiceDeskUCAB.Models.DTO.Tipo_TicketDTO;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.ViewModel
{
	public class TicketReenviarDTOViewModel
    {
		public TicketCompletoDTO ticketPadre;
		public TicketReenviarDTO ticket;
		public List<DepartamentoSearchDTO> departamentos;
		public List<PrioridadDTO> prioridades;
		public List<Tipo_TicketDTOSearch> tipo_tickets;
	}
}

