using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO
{
    public interface IUserLoginDAO
    {

        public UserLoginDto UserLogin(Usuario user);
    }
}
