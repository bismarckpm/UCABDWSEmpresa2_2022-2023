using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class Estado
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(3)]
        public string nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [MinLength(3)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public DateTime fecha_creacion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }

        [Required]
        public Tipo_Estado Estado_Padre { get; set; }
        public List<Bitacora_Ticket> Bitacora_Tickets { get; set; }
        public List<Ticket> ListaTickets { get; set; }
        public Departamento Departamento { get; set; }

        public Estado(string nombre, string descripcion)
        {
            Id = Guid.NewGuid();
            this.nombre = nombre;
            this.descripcion = descripcion;
            fecha_creacion = DateTime.UtcNow;
            fecha_ultima_edic = DateTime.UtcNow;
            //this.Estado_Padre = estado_Padre;
        }
    }
}
