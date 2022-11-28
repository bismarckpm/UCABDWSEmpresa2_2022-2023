using System;
using System.Collections.Generic;
using ServiceDeskUCAB.Models;


namespace ServiceDeskUCAB.ViewModel
{
	public class TicketNuevoViewModel
	{
		public TicketDTO ticket;
		public List<Departamento> departamentos;
		public List<Prioridad> prioridades;
		public List<Tipo_Ticket> tipo_tickets;
	}
}

