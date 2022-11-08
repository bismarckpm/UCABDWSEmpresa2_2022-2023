using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;
using ServicesDeskUCABWS.Entities;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO
{
    public interface ITipo_CargoDAO
    {
        public Tipo_CargoDto AgregarTipo_CargoDAO(Tipo_Cargo tipo);
        public List<Tipo_CargoDto> ConsultarTipo_Cargos();
        public Tipo_CargoDto ConsultarPorID(Guid id);
        public Tipo_CargoDto eliminarTipo_Cargo(Guid id);

        public Tipo_CargoDto_Update actualizarTipo_Cargo(Tipo_Cargo tipo);
        
    }
}
