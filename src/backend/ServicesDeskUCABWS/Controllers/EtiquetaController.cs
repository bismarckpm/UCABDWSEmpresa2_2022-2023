using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.Models.DTO.EtiquetaDTO;
using ServicesDeskUCABWS.Responses;
using ServicesDeskUCABWS.Exceptions;
using ServicesDeskUCABWS.Models;
using System.Threading.Tasks;




namespace ServicesDeskUCABWS.Controllers
{
        [Route("Etiqueta")]
        [ApiController]
        public class EtiquetaController : ControllerBase
        {
            private readonly IEtiquetaDAO _etiqueta;
            private readonly IMapper _mapper;

            public EtiquetaController(IEtiquetaDAO etiqueta, IMapper mapper)
            {
                _etiqueta = etiqueta;
                _mapper = mapper;
            }

            //GET: Controlador para consultar todas las etiquetas
            [HttpGet]
            [Route("Consulta/")]
            public ApplicationResponse<List<EtiquetaDTO>> ConsultaEtiquetasCtrl()
            {
                var response = new ApplicationResponse<List<EtiquetaDTO>>();

                try
                {
                    response.Data = _etiqueta.ConsultaEtiquetas();
                }
                catch (ExceptionsControl ex)
                {
                    response.Success = false;
                    response.Message = ex.Mensaje;
                    response.Exception = ex.Excepcion.ToString();
                }
                return response;
            }

            //GET: Controlador para consultar una etiqueta en especifico
            [HttpGet]
            [Route("Consulta/{id}")]
            public ActionResult<ApplicationResponse<EtiquetaDTO>> GetEtiquetaByGuidCtrl(Guid id)
        {
                var response = new ApplicationResponse<EtiquetaDTO>();

                try
                {
                    response.Data = _etiqueta.ConsultarEtiquetaGUID(id);
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
