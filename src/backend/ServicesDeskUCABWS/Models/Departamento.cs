using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.Models
{
    public class Departamento
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        [Required]
		[JsonIgnore]
		public DateTime fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }
        public HashSet<Tipo_Ticket> Tipo_Ticket { get; set; }
        public HashSet<Cargo> Cargo { get; set; }

		public Grupo Grupo { get; set; }
        public HashSet<Estado> Estado { get; set; }
        public HashSet<Ticket> ListaTickets { get; set; }
    }
}
