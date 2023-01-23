using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Votos_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.TicketsCtr;
using ServicesDeskUCABWS.Controllers.Votos_TicketCtr;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{
    [TestClass]
    public class TestVotosController
    {
        private readonly TicketsController _controller;
        private readonly Mock<IVotos_TicketDAO> _serviceMock;

        public TestVotosController()
        {
            _serviceMock = new Mock<IVotos_TicketDAO>();
            _controller = new TicketsController(_serviceMock.Object);

            _serviceMock.Setup(x => x.ConsultaVotos(It.IsAny<Guid>())).Returns(new ApplicationResponse<List<Votos_Ticket>>()
            {
                Success = true,
            });
        }

        [TestMethod]
        public void TestVotosCTR()
        {
            var voto = new Votos_TicketDTOCreate();

            _serviceMock.Setup(x => x.Votar(It.IsAny<Votos_TicketDTOCreate>())).Returns(new ApplicationResponse<Votos_Ticket>());

            var result = _controller.Registro_Voto(voto);

            Assert.IsTrue(result.Success);
        }
    }
}
