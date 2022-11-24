using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
	public class FamiliaMergeDTO
	{
		public string ticketPadre_Id { get; set; }
		public List<string> tickets { get; set; }
	}
}

