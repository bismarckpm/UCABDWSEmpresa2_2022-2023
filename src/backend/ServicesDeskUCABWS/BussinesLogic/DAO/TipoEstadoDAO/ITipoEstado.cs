using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO
{
    public interface ITipoEstado
    {
        public List<TipoEstadoDTO> ConsultaTipoEstados();
        public TipoEstadoDTO ConsultarTipoEstadoGUID(Guid id);
        public TipoEstadoDTO ConsultarTipoEstadoTitulo(string titulo);
        public Boolean RegistroTipoEstado(TipoEstadoCreateDTO tipoEstado);
        public Boolean ActualizarTipoEstado(TipoEstadoCreateDTO tipoEstadoAct, Guid id);
        public Boolean EliminarTipoEstado(Guid id);
    }
}
