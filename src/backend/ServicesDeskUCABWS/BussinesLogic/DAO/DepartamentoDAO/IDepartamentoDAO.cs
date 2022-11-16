using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO
{
    public interface IDepartamentoDAO
    {
        public List<DepartamentoDTO> ConsultarDepartamentos();
    }
}
