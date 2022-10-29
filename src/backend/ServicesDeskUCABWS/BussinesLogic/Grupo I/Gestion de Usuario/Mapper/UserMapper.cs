using AutoMapper;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_I.Gestion_de_Usuario.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
