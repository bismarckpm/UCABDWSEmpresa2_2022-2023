using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Estado
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(70)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }

        [Required]
        public Tipo_Estado Estado_Padre { get; set; }
        public HashSet<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public HashSet<Ticket> ListaTickets { get; set; }

    }
}
