using System;
using System.Collections.Generic;

namespace ServicesDeskUCAB.Models
{
    public class Departamento
    {
        public Guid DepartamentoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int GrupoID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaEdic { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public ICollection<Tipo_Ticket> TipoTicket { get; set; }
        public ICollection<Cargo> Cargo { get; set; }
        public ICollection<Estado> Estado { get; set; }
        public ICollection<Ticket> ListaTickets { get; set; }

        public Grupo Grupo { get; set; }
    }
}

