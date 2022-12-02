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

    public class ConsultarEstadoDepartamentoCtrl
    {

        private readonly EstadoController _controller;
        private readonly Mock<IEstadoDAO> _serviceMock;

        public ConsultarEstadoDepartamentoCtrl()
        {
            _serviceMock = new Mock<IEstadoDAO>();
            _controller = new EstadoController(_serviceMock.Object);
        }

        //Prueba Unitaria del controlador para Consultar Estado Departmento

        [TestMethod]
        public void ConsultarEstadoDepartamentoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEstadosDepartamentoTicket((It.IsAny<Guid>()))).Returns(new List<EstadoDTOUpdate>());
            var application = new ApplicationResponse<List<EstadoDTOUpdate>>();

            //act
            var result = _controller.ConsultarEstadoDepartamento(It.IsAny<Guid>()); ;

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        //Prueba Unitaria de la excepcion en el controlador para consultar Estado Departamento

        [TestMethod]
        public void DeshabilitarEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarEstadosDepartamentoTicket(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultarEstadoDepartamento(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

    }
}






/*
 public ApplicationResponse<List<EstadoDTOUpdate>> ConsultarEstadoDepartamento(Guid Id)
        {
            var response = new ApplicationResponse<List<EstadoDTOUpdate>>();

            try
            {
                response.Data = _estadoDAO.ConsultarEstadosDepartamentoTicket(Id);
            }
            catch (ExceptionsControl ex)
            {
                response.Success = false;
                response.Message = ex.Mensaje;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;

        }
*/
