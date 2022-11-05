using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using ServicesDeskUCABWS.BussinessLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.Response;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
        [Route("Etiqueta")]
        [ApiController]
        public class EtiquetaController : ControllerBase
        {
            private readonly IEtiqueta _etiqueta;
            private readonly IMapper _mapper;

            public EtiquetaController(IEtiqueta etiqueta, IMapper mapper)
            {
                _etiqueta = etiqueta;
                _mapper = mapper;
            }

            //GET: Controlador para consultar todas las etiquetas
            [HttpGet]
            [Route("Consulta/")]
            public async Task<ApplicationResponse<List<EtiquetaDTO>>> ConsultaEtiquetasCtrl()
            {
                var response = new ApplicationResponse<List<EtiquetaDTO>>();

                try
                {
                    response.Data = await _etiqueta.ConsultaEtiquetas();
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
            public async Task<ActionResult<ApplicationResponse<EtiquetaDTO>>> GetEtiquetaByGuidCtrl(Guid id)
        {
                var response = new ApplicationResponse<EtiquetaDTO>();

                try
                {
                    response.Data = await _etiqueta.ConsultarEtiquetaGUID(id);
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
