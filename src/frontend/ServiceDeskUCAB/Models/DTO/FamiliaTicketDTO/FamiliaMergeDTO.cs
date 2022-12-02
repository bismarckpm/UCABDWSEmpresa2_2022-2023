using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
	public class FamiliaMergeDTO
	{
		public Guid ticketPadre_Id { get; set; }
		public List<Guid>? tickets { get; set; }
	}
}

