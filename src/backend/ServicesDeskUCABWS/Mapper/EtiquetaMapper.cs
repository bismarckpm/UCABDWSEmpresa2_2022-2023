using AutoMapper;
using ServicesDeskUCABWS.Models.DTO.EtiquetaDTO;
using ServicesDeskUCABWS.Models;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Mapper
{
    public class EtiquetaMapper:Profile
    {
        public EtiquetaMapper()
        {

            CreateMap<Etiqueta, EtiquetaDTO>();

        }
    }
}
