using System.ComponentModel.DataAnnotations;

namespace ServiceDeskUCAB.Models.Modelos_de_Usuario
{
    public class RecuperarPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;    
    }   
}
