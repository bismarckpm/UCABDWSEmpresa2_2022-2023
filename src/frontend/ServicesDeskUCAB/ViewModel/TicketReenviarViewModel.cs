using System;
using System.Collections.Generic;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.ViewModel
{
	public class TicketReenviarViewModel
    {
		public Ticket ticketPadre;
		public Ticket ticketHijo;
		public List<Departamento> departamentos;
		public List<Prioridad> prioridades;
		public List<Tipo_Ticket> tipo_tickets;
	}
}

