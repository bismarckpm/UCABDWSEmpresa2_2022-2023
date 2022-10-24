using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Services
{
	public class DepartamentoServices
	{
		private readonly DataContext _dataContext;
		private readonly IMapper _mapper;

		//Constructor
		public DepartamentoServices(DataContext dataContext, IMapper mapeador)
		{
			_dataContext = dataContext;
			_mapper = mapeador;
		}

		//Registrar un Departamento
		public async Task<Departamento> Create(DepartamentoDto depDto)
		{
			var nuevoDepartamento = _mapper.Map<Departamento>(depDto);
			_dataContext.Departamentos.Add(nuevoDepartamento);
			await _dataContext.SaveChangesAsync();

			return nuevoDepartamento;
		}

		//Lista de Departamentos
		public async Task<IEnumerable<Departamento>> GetAll()
		{
			return await _dataContext.Departamentos.ToListAsync();
		}

		//Buscar un Departamento
		public async Task<Departamento> GetById(Guid id)
		{

			return await _dataContext.Departamentos.FindAsync(id);
		}

		//Eliminar un Departamento
		public async Task Delete(Guid id)
		{

			var existeDep = await GetById(id);

			if (existeDep is not null)
			{
				_dataContext.Departamentos.Remove(existeDep);
				await _dataContext.SaveChangesAsync();
			}
		}

		//Modificacíon de un Departamento
		public async Task Update(DepartamentoDto depDto)
		{

			var existeDep = await _dataContext.Departamentos.FindAsync(depDto.Id);

			if (existeDep is not null)
			{
				existeDep.descripcion = depDto.descripcion;
				existeDep.nombre = depDto.nombre;
				await _dataContext.SaveChangesAsync();
			}
		}


	}
}
