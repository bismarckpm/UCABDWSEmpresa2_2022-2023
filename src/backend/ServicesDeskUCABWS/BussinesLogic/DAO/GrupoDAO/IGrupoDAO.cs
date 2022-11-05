using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO
{
    public interface IGrupoDAO
    {
        public Task<Grupo> Create(GrupoDto grupoDto);
        public Task<IEnumerable<Grupo>> GetAll();
        public Task<Grupo> GetById(Guid idGrupo);
        public Task Delete(Guid idGrupo);
        public Task Update(GrupoDto grupDto);
    }
}
