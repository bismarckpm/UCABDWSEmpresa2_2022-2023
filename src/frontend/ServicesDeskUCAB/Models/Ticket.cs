using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int UsuarioID { get; set; }
        public int DepartamentoID { get; set; }
        public int PrioridadID { get; set; }
        public int TipoTicketID { get; set; }
        public int? EstadoID { get; set; }
        public int? TicketPadreID { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public ICollection<VotosTicket> VotosTicket { get; set; }
        public FamiliaTicket FamiliaTickets { get; set; }
        public ICollection<BitacoraTicket> BitacoraTickets { get; set; }

        public Usuario Usuario { get; set; }
        public Departamento Departamento { get; set; }
        public Prioridad Prioridad { get; set; }
        public TipoTicket TipoTicket { get; set; }
        public Estado Estado { get; set; }
        public Ticket TicketPadre { get; set; }
    }
}

