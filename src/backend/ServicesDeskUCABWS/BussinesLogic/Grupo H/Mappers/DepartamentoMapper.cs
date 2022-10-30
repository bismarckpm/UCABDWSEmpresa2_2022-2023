using AutoMapper;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Entities;

namespace ServicesDeskUCABWS.BussinesLogic.Grupo_H.Mappers
{
	public class DepartamentoMapper:Profile
	{

		public DepartamentoMapper()
		{
			CreateMap<Departamento, DepartamentoDto>();
			CreateMap<DepartamentoDto, Departamento>();

		}
	}
}
