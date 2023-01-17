using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
	public class FamiliaMergeDTO
	{
        public Guid ticketPrincipalId { get; set; }
        public List<Guid> ticketsSecundariosId { get; set; }
    }
}

