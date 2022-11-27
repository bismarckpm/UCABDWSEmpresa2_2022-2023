using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models
{
    public class GrupoModel
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "Introduzca el nombre del departamento")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe de tener entre 5 a 30 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Introduzca una descripcion")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Debe incluir una descripcion entre 5 a 100 caracteres")]
        public string descripcion { get; set; }
    }
}