﻿using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public interface IDepartamentoDAO
    {
        public DepartamentoDto AgregarDepartamentoDAO(Departamento departamento);
        public List<DepartamentoDto> ConsultarDepartamentos();
        public DepartamentoDto ConsultarPorID(Guid id);
        public DepartamentoDto eliminarDepartamento(Guid id);
        public DepartamentoDto_Update ActualizarDepartamento(Departamento departamento);
        public List<DepartamentoDto> GetByIdDepartamento(Guid idGrupo);
        public Departamento AsignarGrupoToDepartamento(Guid idGrupo, Guid idDept);
        public List<DepartamentoDto> DeletedDepartamento();
    }
}
