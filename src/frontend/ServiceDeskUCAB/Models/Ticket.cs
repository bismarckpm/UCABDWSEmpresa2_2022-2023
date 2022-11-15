using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ServiceDeskUCAB.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string Prioridad { get; set; }
        public string Tipo_Ticket { get; set; }
        public string Departamento_Destino { get; set; }
        public string Emisor { get; set; }
    }

    public class VotarTicket
    {
        public string IdUsuario { get; set; }
        public string IdTicket { get; set; }
        public string voto { get; set; }
        public string comentario { get; set; }
    }
}