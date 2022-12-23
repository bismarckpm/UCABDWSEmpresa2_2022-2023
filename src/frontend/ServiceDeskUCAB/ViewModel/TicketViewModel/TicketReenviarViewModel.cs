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
		public TicketCompletoDTO ticketPadre { get; set; }
        public TicketReenviarDTO ticket { get; set; }
		public List<DepartamentoSearchDTO> departamentos { get; set; }
		public List<PrioridadDTO> prioridades { get; set; }
		public List<Tipo_TicketDTOSearch> tipo_tickets { get; set; }
	}
}

