using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
	public class FamiliaMergeDTO
	{
		public Guid ticketPadre_Id { get; set; }
		public List<Guid>? tickets { get; set; }
	}
}

