using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using System.Collections.Generic;
using System;

namespace ServicesDeskUCABWS.Controllers.Tipo_TicketCtr
{
   
        [Route("Departamento")]
        [ApiController]
        public class DepartamentoController : ControllerBase
        {
            private readonly IDepartamentoDAO _departamentoDAO;
            private readonly ILogger<DepartamentoController> _log;

            //Constructor
            public DepartamentoController(IDepartamentoDAO departamentoDAO, ILogger<DepartamentoController> log)
            {
                _departamentoDAO = departamentoDAO;
                _log = log;
            }

            [HttpGet]
            [Route("ConsultarDepartamento/")]
            public ActionResult<List<DepartamentoDTO>> ConsultarDepartamentos()
            {
                try
                {
                    return _departamentoDAO.ConsultarDepartamentos();
                }
                catch (Exception ex)
                {
                    throw ex.InnerException!;
                }
            }

        
    
}
}
