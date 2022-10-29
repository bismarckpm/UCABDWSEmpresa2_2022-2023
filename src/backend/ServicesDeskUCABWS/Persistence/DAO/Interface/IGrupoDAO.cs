using ServicesDeskUCABWS.BussinesLogic.Grupo_H.DTO;
using ServicesDeskUCABWS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Persistence.DAO.Interface
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
