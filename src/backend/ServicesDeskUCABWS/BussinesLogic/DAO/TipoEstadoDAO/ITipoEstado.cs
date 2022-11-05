using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO
{
    public interface ITipoEstado
    {
        public Task<List<TipoEstadoDTO>> ConsultaTipoEstados();
        public Task<TipoEstadoDTO> ConsultarTipoEstadoGUID(Guid id);
        public Task<TipoEstadoDTO> ConsultarTipoEstadoTitulo(string titulo);
        public Task<Boolean> RegistroTipoEstado(TipoEstadoCreateDTO tipoEstado);
        public Task<Boolean> ActualizarTipoEstado(TipoEstadoUpdateDTO tipoEstadoAct, Guid id);
        public Task<Boolean> EliminarTipoEstado(Guid id);
    }
}
