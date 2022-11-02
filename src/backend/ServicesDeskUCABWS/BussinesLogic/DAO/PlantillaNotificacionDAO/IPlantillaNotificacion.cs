using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;


namespace ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO
{
    public interface IPlantillaNotificacion
    {
        public List<PlantillaNotificacionDTO> ConsultaPlantillas();
        public PlantillaNotificacionDTO ConsultarPlantillaGUID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTitulo(string titulo);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoID(Guid id);
        public PlantillaNotificacionDTO ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado);
        public Boolean RegistroPlantilla(PlantillaNotificacionDTO plantilla);
        public Boolean ActualizarPlantilla(PlantillaNotificacionDTO plantilla, Guid id);
        public Boolean EliminarPlantilla(Guid id);
        //public Boolean ValidarRelacionPlantillaTipo(Guid tipoEstadoId);
    }
}
