using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using ServicesDeskUCABWS.Controllers.Votos_TicketCtr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TesVotosController
{
    public class TestVotosController
    {
        private readonly Votos_TicketController _controller;
        private readonly Mock<IVotos_TicketDAO> _serviceMock;

        public TestVotosController()
        {
            _serviceMock = new Mock<IVotos_TicketDAO>();
            //_controller = new Votos_TicketController(_serviceMock.Object);
        }
    }
}
