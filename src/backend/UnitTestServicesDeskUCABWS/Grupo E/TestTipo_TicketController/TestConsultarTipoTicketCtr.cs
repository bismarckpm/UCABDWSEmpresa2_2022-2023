using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_TicketController
{

    [TestClass]
    public class TestConsultarTipoTicketCtr
    {

        private readonly Tipo_TicketController _controller;
        private readonly Mock<ITipo_TicketDAO> _serviceMock;

        public TestConsultarTipoTicketCtr()
        {
            _serviceMock = new Mock<ITipo_TicketDAO>();
            _controller = new Tipo_TicketController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para consultar todos los tipos tickets

        [TestMethod]
        public void ConsultarTipoTicketCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoTicket()).Returns(new List<Tipo_TicketDTOSearch>());
            var application = new ApplicationResponse<IEnumerable<Tipo_TicketDTOSearch>>();

            //act
            var result = _controller.ConsultarTipoTicketCtrl();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para consultar todos los tipos tickets 

        [TestMethod]
        public void ConsultarTipoTicketCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoTicket()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarTipoTicketCtrl();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
        
        //Prueba Unitaria del controlador para consultar por Id 

        [TestMethod]
        public void ConsultarIdTipoTicketCtrlTest()
        {
            _serviceMock.Setup(p => p.ConsultarTipoTicketGUID(It.IsAny<Guid>())).Returns(new Tipo_TicketDTOSearch());
            var application = new ApplicationResponse<Tipo_TicketDTOSearch>();

            //act
            var result = _controller.ConsultarIdTipoTicket(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        
        }

        //Prueba Unitaria de la excepcion en el controlador para consultar por Id 

        [TestMethod]
        public void ConsultarIdTipoTicketCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoTicketGUID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarIdTipoTicket(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        //Prueba Unitaria del controlador para consultar por nombre 

        [TestMethod]
        public void ConsultarNombreTipoTicketCtrlTest()
        {
            _serviceMock.Setup(p => p.ConsultarNombreTipoTicket(It.IsAny<String>())).Returns(new Tipo_TicketDTOSearch());
            var application = new ApplicationResponse<Tipo_TicketDTOSearch>();

            //act
            var result = _controller.ConsultarNombreTipoTicket(It.IsAny<String>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());

        }

        //Prueba Unitaria de la excepcion en el controlador para consultar por nombre

        [TestMethod]
        public void ConsultarNombreTipoTicketCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarNombreTipoTicket(It.IsAny<String>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarNombreTipoTicket(It.IsAny<String>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


    }
}
