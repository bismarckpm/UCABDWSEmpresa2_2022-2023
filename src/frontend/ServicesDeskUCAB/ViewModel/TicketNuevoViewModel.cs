using System;
using System.Collections.Generic;
using ServicesDeskUCAB.Models;

namespace ServicesDeskUCAB.ViewModel
{
	public class TicketNuevoViewModel
	{
		public CrearTicket ticket;
		public TicketInfoCompleta ticketPadre;
		public List<Departamento> departamentos;
		public List<Prioridad> prioridades;
		public List<Tipo_Ticket> tipo_tickets;
	}
}

