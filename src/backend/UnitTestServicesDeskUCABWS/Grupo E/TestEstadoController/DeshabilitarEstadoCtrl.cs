using Microsoft.AspNetCore.Mvc;
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

    public class DeshabilitarEstadoCtrl
    {

        private readonly EstadoController _controller;
        private readonly Mock<IEstadoDAO> _serviceMock;

        public DeshabilitarEstadoCtrl()
        {
            _serviceMock = new Mock<IEstadoDAO>();
            _controller = new EstadoController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para deshabilitar un Estado

        [TestMethod]
        public void DeshabilitarEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.DeshabilitarEstado((It.IsAny<Guid>()))).Returns(new EstadoDTOUpdate());
            var application = new ApplicationResponse<EstadoDTOUpdate>();

            //act
            var result = _controller.DeshabilitarEstado(It.IsAny<Guid>()); ;

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para deshabilitar un Estado

        [TestMethod]
        public void DeshabilitarEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.DeshabilitarEstado(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.DeshabilitarEstado(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

    }

}