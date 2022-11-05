using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO
{
    public interface IPlantillaNotificacion
    {
        public Task<List<PlantillaNotificacionDTO>> ConsultaPlantillas();
        public Task<PlantillaNotificacionDTO> ConsultarPlantillaGUID(Guid id);
        public Task<PlantillaNotificacionDTO> ConsultarPlantillaTitulo(string titulo);
        public Task<PlantillaNotificacionDTO> ConsultarPlantillaTipoEstadoID(Guid id);
        public Task<PlantillaNotificacionDTO> ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado);
        public Task<Boolean> RegistroPlantilla(PlantillaNotificacionDTOCreate plantilla);
        public Task<Boolean> ActualizarPlantilla(PlantillaNotificacionDTOCreate plantilla, Guid id);
        public Task<Boolean> EliminarPlantilla(Guid id);
        //public Boolean ValidarRelacionPlantillaTipo(Guid tipoEstadoId);
    }
}
