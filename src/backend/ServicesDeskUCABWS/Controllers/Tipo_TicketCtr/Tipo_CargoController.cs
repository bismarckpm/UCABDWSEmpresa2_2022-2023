using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_CargoDTO;
using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.Controllers.Tipo_TicketCtr
{
        [Route("Cargo")]
        [ApiController]
        public class Tipo_CargoController : ControllerBase
        {
            private readonly ITipo_CargoDAO _tipocargpDAO;
            private readonly ILogger<Tipo_CargoController> _log;

            //Constructor
            public Tipo_CargoController(ITipo_CargoDAO tipo_cargoDAO, ILogger<Tipo_CargoController> log)
            {
                _tipocargpDAO = tipo_cargoDAO;
                _log = log;
            }

            [HttpGet]
            [Route("ConsultarCargos/")]
            public ActionResult<List<Tipo_CargoDTOSearch>> ConsultarCargo()
            {
                try
                {
                    return _tipocargpDAO.ConsultarCargos();
                }
                catch (Exception ex)
                {
                    throw ex.InnerException!;
                }
            }
        }
    
}
