using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System.Linq;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO
{
    public class UserLoginDAO : IUserLoginDAO
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
      

        public UserLoginDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public UserLoginDto UserLogin(Usuario user)
        {
            try
            {
               var usuario  =  _dataContext.Usuarios.Where(u => u.correo == user.correo && u.password == user.password).FirstOrDefault();
                return UserMapper.MapperUserLogin(usuario);
            }
            catch (System.Exception)
            {

                throw;
            }
           

        }
    }
}
