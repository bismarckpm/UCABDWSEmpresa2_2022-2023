using System.ComponentModel.DataAnnotations;

namespace ServicesDeskUCABWS.BussinesLogic.DTO.Usuario
{
    public class UserRecoveryDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set;  }
    }
}
