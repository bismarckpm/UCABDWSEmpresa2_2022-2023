using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models
{
    public class DepartamentoModel
    {
        [Required(ErrorMessage = "Introduzca el nombre del departamento")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "El nombre debe de tener entre 5 a 10 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Introduzca contraseña")]
        public string descripcion { get; set; }
    }
}
