using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Mapper
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
