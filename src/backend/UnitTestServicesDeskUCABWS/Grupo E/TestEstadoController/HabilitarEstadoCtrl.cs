using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.EstadosController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEstadoController
{
    [TestClass]

    public class HabilitarEstadoCtrl
    {

        private readonly EstadoController _controller;
        private readonly Mock<IEstadoDAO> _serviceMock;

        public HabilitarEstadoCtrl()
        {
            _serviceMock = new Mock<IEstadoDAO>();
            _controller = new EstadoController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para habilitar un Estado

        [TestMethod]
        public void HabilitarEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.HabilitarEstado((It.IsAny<Guid>()))).Returns(new EstadoDTOUpdate());
            var application = new ApplicationResponse<EstadoDTOUpdate>();

            //act
            var result = _controller.HabilitarEstado(It.IsAny<Guid>()); ;

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para habilitar un Estado

        [TestMethod]
        public void HabilitarEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.HabilitarEstado(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.HabilitarEstado(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

    }
}
