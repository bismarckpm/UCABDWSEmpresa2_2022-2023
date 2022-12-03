using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using ServiceDeskUCAB.Models.TipoTicketsModels;

namespace ServiceDeskUCAB.Models.ModelsVotos
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public Estado Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public Tipo Tipo_Ticket { get; set; }
        public HashSet<Votos_Ticket> Votos_Ticket { get; set; }
        public Departament Departamento_Destino { get; set; }
        public Familia_Ticket Familia_Ticket { get; set; }
        public Ticket Ticket_Padre { get; set; }
        public Empleado Emisor { get; set; }
        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public int? nro_cargo_actual { get; set; }
    }
    public class NuevoTicket
    {
        public string titulo { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public string prioridad { get; set; }
        public string tipo_Ticket { get; set; }
        public string departamento_Destino { get; set; }
        public string emisor { get; set; }
    }

    public class VotarTicket
    {
        public string IdUsuario { get; set; }
        public string IdTicket { get; set; }
        public string voto { get; set; }
        public string comentario { get; set; }
    }
}