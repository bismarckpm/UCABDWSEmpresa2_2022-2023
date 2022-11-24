using Moq;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.BussinesLogic.Response;


namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestTipoEstado
{
    [TestClass]
    public class TipoEstadoControllerTest
    {

        private readonly TipoEstadoController _controller;
        private readonly Mock<ITipoEstado> _serviceMock;

        public TipoEstadoControllerTest()
        {
            _serviceMock = new Mock<ITipoEstado>();
            _controller = new TipoEstadoController(_serviceMock.Object);
        }


//*
//PRUEBAS UNITARIAS para consultar todas los tipos estados (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas los tipos estados exitoso")]
        public void ConsultaTipoEstadosCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaTipoEstados()).Returns(new List<TipoEstadoDTO>());
            var application = new ApplicationResponse<List<TipoEstadoDTO>>();

            //act
            var result = _controller.ConsultaTipoEstadosCtrl();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas los tipos estados excepcion")]
        public void ConsultaTipoEstadosCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaTipoEstados()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultaTipoEstadosCtrl();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar todas los tipos estados (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar un tipo estado en especifico exitoso")]
        public void GetByGuidCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoEstadoGUID(It.IsAny<Guid>())).Returns(new TipoEstadoDTO());
            var application = new ApplicationResponse<TipoEstadoDTO>();

            //act
            var result = _controller.GetByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria para consultar un tipo estado en especifico excepcion")]
        public void GetByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoEstadoGUID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar todas los tipos estados (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar una tipo estado por un título específico exitoso")]
        public void GetByTituloCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoEstadoTitulo(It.IsAny<String>())).Returns(new TipoEstadoDTO());
            var application = new ApplicationResponse<TipoEstadoDTO>();

            //act
            var result = _controller.GetByTituloCtrl(It.IsAny<String>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria para consultar una tipo estado por un título específico excepcion")]
        public void GetByTituloCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarTipoEstadoTitulo(It.IsAny<String>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTituloCtrl(It.IsAny<String>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para crear tipo estado (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para crear tipo estado exitoso")]
        public void CrearTipoEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.RegistroTipoEstado(It.IsAny<TipoEstadoCreateDTO>()));//.Returns(true);
            var application = new ApplicationResponse<TipoEstadoCreateDTO>();

            //act
            var result = _controller.CrearTipoEstadoCtrl(It.IsAny<TipoEstadoCreateDTO>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para crear tipo estado excepcion")]
        public void CrearTipoEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.RegistroTipoEstado(It.IsAny<TipoEstadoCreateDTO>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearTipoEstadoCtrl(It.IsAny<TipoEstadoCreateDTO>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para modificar tipo estado (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para modificar tipo estado exitoso")]
        public void ActualizarTipoEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ActualizarTipoEstado(It.IsAny<TipoEstadoUpdateDTO>(), It.IsAny<Guid>()));//.Returns(true);
            var application = new ApplicationResponse<TipoEstadoDTO>();

            //act
            var result = _controller.ActualizarTipoEstadoCtrl(It.IsAny<TipoEstadoUpdateDTO>(), It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para crear tipo estado excepcion")]
        public void ActualizarTipoEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ActualizarTipoEstado(It.IsAny<TipoEstadoUpdateDTO>(), It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ActualizarTipoEstadoCtrl(It.IsAny<TipoEstadoUpdateDTO>(), It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para eliminar tipo estado (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para eliminar tipo estado exitoso")]
        public void EliminarTipoEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarTipoEstado(It.IsAny<Guid>()));//.Returns(true);
            var application = new ApplicationResponse<TipoEstadoCreateDTO>();

            //act
            var result = _controller.EliminarTipoEstadoCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para eliminar tipo estado excepcion")]
        public void EliminarTipoEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarTipoEstado(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarTipoEstadoCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}
