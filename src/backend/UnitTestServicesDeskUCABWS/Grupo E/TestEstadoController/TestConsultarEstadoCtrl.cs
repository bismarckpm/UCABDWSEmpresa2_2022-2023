using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers.EstadosController;
using ServicesDeskUCABWS.Controllers.Tipo_TicketCtr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEstadoController
{


    [TestClass]
    public class TestConsultarEstadoCtrl
    {

        private readonly EstadoController _controller;
        private readonly Mock<IEstadoDAO> _serviceMock;

        public TestConsultarEstadoCtrl()
        {
            _serviceMock = new Mock<IEstadoDAO>();
            _controller = new EstadoController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para consultar todos los estado por departamento

        [TestMethod]
        public void ConsultarEstadoDepartamentoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEstadosDepartamento((It.IsAny<Guid>()))).Returns(new List<EstadoDTOUpdate>());
            var application = new ApplicationResponse<IEnumerable<EstadoDTOUpdate>>();

            //act
            var result = _controller.ConsultarEstadoCtrl((It.IsAny<Guid>()));

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para consultar todos los estado

        [TestMethod]
        public void ConsultarEstadoDepartamentoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEstadosDepartamento((It.IsAny<Guid>()))).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarEstadoCtrl((It.IsAny<Guid>()));

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

    }

}


