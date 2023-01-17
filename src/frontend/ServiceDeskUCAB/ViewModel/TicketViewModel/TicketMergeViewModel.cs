using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceDeskUCAB.Models;
using ServiceDeskUCAB.Models.ModelsVotos;
using ServicesDeskUCAB.Models;

namespace ServiceDeskUCAB.ViewModel
{
    public class FamiliaMergeDTOViewModel
    {
        public TicketCompletoDTO ticket;

        public List<TicketBasicoDTO> tickets;

		public IList<SelectListItem> familia;
	}
}

