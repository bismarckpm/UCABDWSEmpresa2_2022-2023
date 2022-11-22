using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.TestTipo_TicketController
{
    [TestClass]
    public class TestEliminarTipo_TicketCtrl
    {

        private readonly Tipo_TicketController _controller;
        private readonly Mock<ITipo_TicketDAO> _serviceMock;

        public TestEliminarTipo_TicketCtrl()
        {
            _serviceMock = new Mock<ITipo_TicketDAO>();
            _controller = new Tipo_TicketController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para eliminar un tipo ticket

        [TestMethod]
        public void EliminarTipoTicketCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarTipoTicket((It.IsAny<Guid>()))).Returns(true);
            var application = new ApplicationResponse<String>();

            //act
            var result = _controller.EliminarTipoTicketCtrl(It.IsAny<Guid>()); ;

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para eliminar un tipo ticket

        [TestMethod]
        public void EliminarTipoTicketCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarTipoTicket(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarTipoTicketCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}
