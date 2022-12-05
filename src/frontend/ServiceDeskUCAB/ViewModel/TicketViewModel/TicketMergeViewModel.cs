using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServicesDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel
{
    public class FamiliaMergeDTOViewModel
    {
        public TicketCompletoDTO ticket;

        public List<TicketBasicoDTO> tickets;

		public List<Guid> familia;
	}
}

