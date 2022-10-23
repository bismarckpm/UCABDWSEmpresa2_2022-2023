using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using ServicesDeskUCABWS.Persistence.Database;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Services
{
	public class DepartamentoServices
	{
		private readonly DataContext _dataContext;
		private readonly IMapper _mapeador;

		public DepartamentoServices(DataContext dataContext, IMapper mapeador)
		{
			_dataContext = dataContext;
			_mapeador = mapeador;
		}

		public async Task<Departamento> Create(DepartamentoDto departamentoDto) {
			var nuevoDep = _mapeador.Map<Departamento>(departamentoDto);
			_dataContext.Departamentos.Add(nuevoDep);
			await _dataContext.SaveChangesAsync();

			return nuevoDep;
		}
	}
}
