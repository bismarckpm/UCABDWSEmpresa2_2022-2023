
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Persistence.Entities
{
    public class Etiqueta
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; } = string.Empty;

        public HashSet<Tipo_Estado> ListaEstadosrelacionados { get; set; }

    }
}
