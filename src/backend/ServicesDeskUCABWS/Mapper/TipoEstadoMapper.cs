using AutoMapper;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO;

namespace ServicesDeskUCABWS.Mapper
{
    public class TipoEstadoMapper:Profile
    {
        public TipoEstadoMapper()
        {

            CreateMap<Tipo_Estado, TipoEstadoSearchDTO>();
            CreateMap<TipoEstadoSearchDTO, Tipo_Estado>();

        }
    }
}
