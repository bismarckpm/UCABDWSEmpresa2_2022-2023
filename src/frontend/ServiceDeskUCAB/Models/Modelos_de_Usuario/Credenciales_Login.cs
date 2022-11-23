using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models.Modelos_de_Usuario
{
    public class Credenciales_Login
    {
        [Required(ErrorMessage = "Introduzca su usuario")]
        public string correo { get; set; }

        [Required(ErrorMessage = "Introduzca su contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
