using AutoMapper;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinessLogic.Mapper
{
    public class EtiquetaMapper:Profile
    {
        public EtiquetaMapper()
        {

            CreateMap<Etiqueta, EtiquetaDTO>();
            CreateMap<EtiquetaDTO, Etiqueta>();

        }
    }
}
