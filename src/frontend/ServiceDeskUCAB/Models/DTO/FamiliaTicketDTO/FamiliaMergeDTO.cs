using System;
using System.Collections.Generic;

namespace ServiceDeskUCAB.Models
{
	public class FamiliaMergeDTO
	{
		public string ticketPadre_Id { get; set; }
		public List<string> tickets { get; set; }
	}
}

