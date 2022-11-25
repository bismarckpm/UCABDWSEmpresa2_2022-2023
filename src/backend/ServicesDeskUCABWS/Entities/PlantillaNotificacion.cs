using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicesDeskUCABWS.Entities
{
    public class PlantillaNotificacion
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public Guid? TipoEstadoId { get; set; }

        
        public Tipo_Estado TipoEstado { get; set; }

    }

}
