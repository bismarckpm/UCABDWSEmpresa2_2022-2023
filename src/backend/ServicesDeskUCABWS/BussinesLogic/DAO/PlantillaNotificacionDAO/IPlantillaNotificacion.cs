using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;


namespace ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO
{
    public interface IPlantillaNotificacion
    {
        public List<PlantillaNotificacionSearchDTO> ConsultaPlantillas();
        public PlantillaNotificacionSearchDTO ConsultarPlantillaGUID(Guid id);
        public List<PlantillaNotificacionSearchDTO> ConsultarPlantillaTitulo(string titulo);
        public PlantillaNotificacionSearchDTO ConsultarPlantillaTipoEstadoID(Guid id);
        public List<PlantillaNotificacionSearchDTO> ConsultarPlantillaTipoEstadoTitulo(string tituloTipoEstado);
        public Boolean RegistroPlantilla(PlantillaNotificacion plantilla);
        public Boolean ActualizarPlantilla(PlantillaNotificacionUpdateDTO plantilla);
        public Boolean EliminarPlantilla(Guid id);
    }
}
