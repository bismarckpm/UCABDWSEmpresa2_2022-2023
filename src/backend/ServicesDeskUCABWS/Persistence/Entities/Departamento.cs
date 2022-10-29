using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Departamento
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string descripcion { get; set; } = string.Empty;

        [Required]
        public DateTime fecha_creacion { get; set; }

        [JsonIgnore]
        public DateTime? fecha_ultima_edicion { get; set; }
        public DateTime? fecha_eliminacion { get; set; }

        
        //public Grupo Grupo { get; set; }
        
    }
}
