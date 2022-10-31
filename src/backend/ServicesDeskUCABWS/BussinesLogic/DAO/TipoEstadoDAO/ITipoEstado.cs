using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO
{
    public interface ITipoEstado
    {
        public List<TipoEstadoSearchDTO> ConsultaTipoEstados();
        public TipoEstadoSearchDTO ConsultarTipoEstadoGUID(Guid id);
        public List<TipoEstadoSearchDTO> ConsultarTipoEstadoTitulo(string titulo);
        public Boolean RegistroTipoEstado(Tipo_Estado tipoEstado);
        public Boolean EliminarTipoEstado(Guid id);
    }
}
