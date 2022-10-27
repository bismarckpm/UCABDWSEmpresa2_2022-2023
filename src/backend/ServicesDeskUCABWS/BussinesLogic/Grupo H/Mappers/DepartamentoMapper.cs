using AutoMapper;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;

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
