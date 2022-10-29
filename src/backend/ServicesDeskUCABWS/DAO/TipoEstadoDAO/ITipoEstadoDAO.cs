using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Models.DTO.TipoEstadoDTO;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.DAO.TipoEstadoDAO
{
    public interface ITipoEstadoDAO
    {
        public List<TipoEstadoSearchDTO> ConsultaTipoEstados();
        public TipoEstadoSearchDTO ConsultarTipoEstadoGUID(Guid id);
        public List<TipoEstadoSearchDTO> ConsultarTipoEstadoTitulo(string titulo);
        public Boolean RegistroTipoEstado(Tipo_Estado tipoEstado);
        public Boolean EliminarTipoEstado(Guid id);
    }
}
