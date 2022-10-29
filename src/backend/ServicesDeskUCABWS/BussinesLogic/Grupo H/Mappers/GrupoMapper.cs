using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Models;
using AutoMapper;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers
{
	public class GrupoMapper:Profile
	{
		public GrupoMapper()
		{
			CreateMap<Grupo, GrupoDto>();
			CreateMap<GrupoDto, Grupo>();

		}
	}
}
