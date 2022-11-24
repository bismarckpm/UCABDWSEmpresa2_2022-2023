using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO
{
    public interface ITipo_CargoDAO
    {
        public List<Tipo_CargoDTOSearch> ConsultarCargos();
    
    }   
}
