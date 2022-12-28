using ServicesDeskUCABWS.BussinesLogic.DTO.GrupoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO
{
    public interface IGrupoDAO
    {
        public GrupoDto AgregarGrupoDao(Grupo grupo);
        public List<GrupoDto> ConsultarGruposDao();
        public GrupoDto ConsultarPorIdDao(Guid idGrupo);
        public GrupoDto EliminarGrupoDao(Guid idGrupo);
        public GrupoDto_Update ModificarGrupoDao(Grupo grupo);
        public bool QuitarAsociacion(Guid grupoId);
        public List<GrupoDto> ConsultarGrupoNoEliminado();
        public List<string> AsignarGrupoToDepartamento(Guid id, string idDept);
        public List<string> EditarRelacion(Guid id, string idDepartamentos);
        public List<DepartamentoDto> GetByIdDepartamento(Guid idGrupo);
    }
}