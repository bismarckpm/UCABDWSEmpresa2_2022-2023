using Microsoft.AspNetCore.Mvc;
using ServicesDeskUCABWS.BussinesLogic;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;

namespace ServicesDeskUCABWS.Controllers
{
    [Route("Notificacion")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private readonly INotificacion _notificacion;
        private readonly ITicketDAO _ticketDAO;

        public NotificacionController(INotificacion notificacion, ITicketDAO ticketDAO)
        {
            _notificacion = notificacion;
            _ticketDAO = ticketDAO;
        }

        [HttpPost]
        [Route("EnviarCorreo/{correo}")]
        public ApplicationResponse<string> EnviarCorreoCtr(PlantillaNotificacionDTO plantillaNotificacionDTO, [FromRoute] string correo)
        {
            var response = new ApplicationResponse<string>();
            try
            {
                _notificacion.EnviarCorreo(plantillaNotificacionDTO, correo);
                response.Data = "Correo enviado exitosamente";
            }
            catch (ExceptionsControl ex)
            {
                response.Data = "Error en el envio de correo";
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();


            }
            return response;
        }

        [HttpPost]
        [Route("ReemplazarEtiqueta/{idTicket}")]
        public ApplicationResponse<string> ReemplazoEtiqueta([FromBody] PlantillaNotificacionDTO plantilla, [FromRoute]Guid idTicket)
        {
            var response = new ApplicationResponse<string>();
            try
            { 
                response.Data = _notificacion.ReemplazoEtiqueta(_ticketDAO.GetTicket(idTicket).Data, plantilla); 
            }
            catch (ExceptionsControl ex)
            {
                response.Data = "Error en reemplazo del correo";
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();


            }
            return response;
        }
    }
}
