using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServicesDeskUCABWS.BussinesLogic.DTO.Usuario;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper.UserMapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.Tools;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace ServicesDeskUCABWS.BussinesLogic.DAO.LoginDAO
{
    public class UserLoginDAO : IUserLoginDAO
    {
        private readonly IDataContext _dataContext;
        private readonly AppSettings _appSettings;
      

        public UserLoginDAO(IDataContext dataContext, IOptions<AppSettings> appSettings) 
        {
            _dataContext = dataContext;
            _appSettings = appSettings.Value; 
        }

        public UserResponseLoginDTO UserLogin(UserLoginDto user)
        {
            try
            {
               //var passwordEncrypt = Encrypt.GetSHA256(user.password);
               //&& u.fecha_eliminacion == default(DateTime)
               var usuario  =  _dataContext.Usuarios.Where(u => u.correo == user.correo && u.password == user.password ).FirstOrDefault();
               var userResponse = UserMapper.MapperDtoToEntityUserLogin(usuario, GetToken(usuario));
               return userResponse;
            }
            catch (Exception ex)
            {
                throw new ExceptionsControl("El usuario o contraseña es invalida", ex);
            }
           

        }

        private string GetToken (Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var rol = _dataContext.RolUsuarios.Where(u=> u.UserId  == usuario.Id).FirstOrDefault();
            var nombreRol = _dataContext.Roles.Where(r => r.Id == rol.RolId).FirstOrDefault();


            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Email, usuario.correo),
                        new Claim("Rol", nombreRol.Name)
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme
                    ),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials ( new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
