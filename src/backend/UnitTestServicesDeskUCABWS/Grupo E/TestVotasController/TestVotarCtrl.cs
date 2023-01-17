﻿using AutoMapper;
using Moq;

using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
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
        private readonly Mock<IDataContext> context;
        
        private IMapper mapper;
        public TestVotosController()
        {
            _serviceMock = new Mock<IVotos_TicketDAO>();
            context = new Mock<IDataContext>();
            _controller = new Votos_TicketController(_serviceMock.Object, mapper);

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

        //Prueba Unitaria del controlador para consultar votos no pendientes por IdUsuario 

        [TestMethod]
        public void ConsultarVotosNoPendientesCtrlTest()
        {
            //Arrange
            _serviceMock.Setup(p => p.ConsultaVotosNoPendientes(It.IsAny<Guid>())).Returns(new ApplicationResponse<List<Votos_Ticket>>());
            var application = new ApplicationResponse<List<Votos_Ticket>>();

            //act
            var result = _controller.DetailsPen(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());

        }
    }

}