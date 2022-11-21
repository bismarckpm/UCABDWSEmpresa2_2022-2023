using System;
using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.Entities
{
    public class Prioridad
    {
        /*private string v1;
        private string v2;

        public Prioridad(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }*/

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(10), MinLength(3)]
        public string nombre { get; set; } = string.Empty;
        [Required, MaxLength(100), MinLength(4)]
        public string descripcion { get; set; } = string.Empty;
        [Required]
        public string estado { get; set; }
        [Required]
        public DateTime fecha_descripcion { get; set; }
        [Required]
        public DateTime fecha_ultima_edic { get; set; }
        
    }
}
