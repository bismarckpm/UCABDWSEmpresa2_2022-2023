using AutoMapper;
using Moq;

using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.Votos_TicketCtr;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TesVotosController
{
    [TestClass]
    public class TestVotosController
    {
        private readonly Votos_TicketController _controller;
        private readonly Mock<IVotos_TicketDAO> _serviceMock;
        private readonly Mock<DataContext> context;
        private IMapper mapper;
        public TestVotosController()
        {
            _serviceMock = new Mock<IVotos_TicketDAO>();
            _controller = new Votos_TicketController(_serviceMock.Object, context.Object, mapper);

            _serviceMock.Setup(x => x.ConsultaVotos(It.IsAny<Guid>())).Returns(new ApplicationResponse<List<Votos_Ticket>>()
            {
                Success = true,
            });
        }

        [TestMethod]
        public void TestDetailsVotosIsSucces()
        {
            var res = _controller.Details(new Guid());

            Assert.IsTrue(res.Success);
        }

        

    }

}