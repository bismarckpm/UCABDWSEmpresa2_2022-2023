using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic.DTO.EtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinessLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.BussinessLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinessLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinessLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinessLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.Response;
using System;
using System.Collections.Generic;


namespace ServicesDeskUCABWS.Controllers
{
    [Route("TipoEstado")]
    [ApiController]
    public class TipoEstadoController:ControllerBase
    {
        private readonly ITipoEstado _tipoEstado;
        private readonly IPlantillaNotificacion _plantilla;
        private readonly IMapper _mapper;

        public TipoEstadoController(ITipoEstado tipoEstadoContext, IPlantillaNotificacion plantilla, IMapper mapper)
        {
            _tipoEstado = tipoEstadoContext;
            _plantilla = plantilla;
            _mapper = mapper;
        }

        //GET: Controlador para consultar todas los tipos estados
        [HttpGet]
        [Route("Consulta/")]
        public ApplicationResponse<List<TipoEstadoSearchDTO>> ConsultaTipoEstadosCtrl()
        {
            var response = new ApplicationResponse<List<TipoEstadoSearchDTO>>();

            try
            {
                response.Data = _tipoEstado.ConsultaTipoEstados();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //GET: Controlador para consultar un tipo estado en especifico
        [HttpGet]
        [Route("Consulta/{id}")]
        public ActionResult<ApplicationResponse<TipoEstadoSearchDTO>> GetByGuidCtrl(Guid id)
        {
            var response = new ApplicationResponse<TipoEstadoSearchDTO>();

            try
            {
                response.Data = _tipoEstado.ConsultarTipoEstadoGUID(id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }

        //GET: Controlador para consultar una tipo estado por un título específico
        [HttpGet]
        [Route("Consulta/Titulo/{titulo}")]
        public ApplicationResponse<List<TipoEstadoSearchDTO>> GetByTituloCtrl(string titulo)
        {
            var response = new ApplicationResponse<List<TipoEstadoSearchDTO>>();
            try
            {
                response.Data = _tipoEstado.ConsultarTipoEstadoTitulo(titulo);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //POST: Controlador para crear tipo estado **
        [HttpPost]
        [Route("Registro/")]
        public ApplicationResponse<String> CrearTipoEstadoCtrl( TipoEstadoCreateDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                

                var tipoEstadoCreate = new Tipo_Estado
                {
                    Id = Guid.NewGuid(),
                    nombre = tipoEstadoDTO.nombre,
                    descripcion = tipoEstadoDTO.descripcion,
                    
                };

                var lista = new HashSet<EtiquetaTipoEstado>();
                foreach(EtiquetaTipoEstadoDTO i in tipoEstadoDTO.etiquetaTipoEstado)
                {
                    var item = new EtiquetaTipoEstado();
                    item.tipoEstadoID = tipoEstadoCreate.Id;
                    item.etiquetaID = i.etiquetaID;
                    lista.Add(item);
                    
                    
                }
                tipoEstadoCreate.etiquetaTipoEstado = lista;

                response.Data = _tipoEstado.RegistroTipoEstado(tipoEstadoCreate).ToString();

                
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //PUT: Controlador para modificar tipo estado
        [HttpPut]
        [Route("Actualizar/{id}")]
        public ApplicationResponse<String> ActualizarTipoEstadoCtrl(TipoEstadoSearchDTO tipoEstadoDTO)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                response.Data = _tipoEstado.ActualizarTipoEstado(tipoEstadoDTO).ToString();
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        //DELETE: Controlador para eliminar tipo estado
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public ApplicationResponse<String> EliminarTipoEstadoCtrl(Guid id)
        {
            var response = new ApplicationResponse<String>();
            try
            {
                try
                {

                    var plantillaTipoTicket = _plantilla.ConsultarPlantillaTipoEstadoID(id);
                    var plantillaUpdate = _mapper.Map<PlantillaNotificacionUpdateDTO>(plantillaTipoTicket);
                    plantillaUpdate.TipoEstadoId = null;
                    _plantilla.ActualizarPlantilla(plantillaUpdate);
                }
                catch (InvalidOperationException)
                {
                    response.Message = "No hay plantilla asociada a este tipo de estado";
                }
                finally
                {
                    response.Data = _tipoEstado.EliminarTipoEstado(id).ToString();
                 
                }   

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
