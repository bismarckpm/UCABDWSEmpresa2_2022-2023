using AutoMapper;
using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Persistence.DAO.Interface;
using ServicesDeskUCABWS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ServicesDeskUCABWS.Persistence.DAO.Implementation
{
    public class GrupoDAO : IGrupoDAO
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public GrupoDAO(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        //Registar un grupo
        public async Task<Grupo> Create(GrupoDto grupoDto)
        {

            var nuevoGrupo = new Grupo()
            {
                Id = grupoDto.Id,
                nombre = grupoDto.nombre,
                descripcion = grupoDto.descripcion,
                fecha_creacion = grupoDto.fecha_creacion
            };

            _dataContext.Grupos.Add(nuevoGrupo);
            await _dataContext.SaveChangesAsync();

            return nuevoGrupo;
        }

        //Listar Grupos
        public async Task<IEnumerable<Grupo>> GetAll()
        {

            return await _dataContext.Grupos.ToListAsync();
        }

        //Buscar un Grupo
        public async Task<Grupo> GetById(Guid idGrupo)
        {
            return await _dataContext.Grupos.FindAsync(idGrupo);
        }

        //Eliminar un Grupo
        public async Task Delete(Guid idGrupo)
        {

            var existeGrup = await GetById(idGrupo);

            if (existeGrup is not null)
            {
                _dataContext.Grupos.Remove(existeGrup);
                await _dataContext.SaveChangesAsync();
            }
        }

        //Modificar un Grupo
        public async Task Update(GrupoDto grupDto)
        {

            var existeGrup = await _dataContext.Grupos.FindAsync(grupDto.Id);

            if (existeGrup is not null)
            {
                existeGrup.descripcion = grupDto.descripcion;
                existeGrup.nombre = grupDto.nombre;

                await _dataContext.SaveChangesAsync();
            }

        }
    }
}

