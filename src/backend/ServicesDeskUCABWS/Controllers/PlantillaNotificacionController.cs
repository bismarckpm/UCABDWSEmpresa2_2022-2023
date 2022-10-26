using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.Models.DTO.PlantillaDTO;
using ServicesDeskUCABWS.Responses;
using ServicesDeskUCABWS.Exceptions;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("PlantillaNotificacion")]
    [ApiController]
    public class PlantillaNotificacionController:ControllerBase
    {
        private readonly IPlantillaNotificacionDAO _plantilla;
        private readonly IMapper _mapper;

        public PlantillaNotificacionController(IPlantillaNotificacionDAO plantilla, IMapper mapper)
        {
            _plantilla = plantilla;
            _mapper = mapper;   
        }

        //GET: Controlador para consultar todas las plantillas
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<PlantillaNotificacionSearchDTO>> ConsultaPlantillasCtrl()
        {
            var response = new ApplicationResponse<List<PlantillaNotificacionSearchDTO>>();

            try
            {
                response.Data = _plantilla.ConsultaPlantillas();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

    }
}
