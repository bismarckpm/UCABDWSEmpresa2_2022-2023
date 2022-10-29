using ServicesDeskUCABWS.Models;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO
{
    public interface IPlantillaNotificacionDAO
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
