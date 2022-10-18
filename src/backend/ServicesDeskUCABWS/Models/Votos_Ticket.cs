using System;

namespace ProyectD.Models
{
    public class Votos_Ticket
    {
        public Guid Id { get; set; }
        public bool aprobado { get; set; }
        public string comentario { get; set; }
        public DateTime fecha { get; set; }
        public Usuario Usuario { get; set; }
        public Ticket Ticket { get; set; }
    }
}
