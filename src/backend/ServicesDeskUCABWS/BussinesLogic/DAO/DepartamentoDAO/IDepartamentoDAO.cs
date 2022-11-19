using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public interface IDepartamentoDAO
    {
        public List<DepartamentoDTO> ConsultarDepartamentos();
    }
}
