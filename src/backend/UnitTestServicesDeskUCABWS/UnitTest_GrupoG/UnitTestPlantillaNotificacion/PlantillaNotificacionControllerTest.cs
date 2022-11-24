using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestPlantillaNotificacion
{
    [TestClass]
    public class PlantillaNotificacionControllerTest
    {

        private readonly PlantillaNotificacionController _controller;
        private readonly Mock<IPlantillaNotificacion> _serviceMock;
        
        public PlantillaNotificacionControllerTest()
        {
            _serviceMock = new Mock<IPlantillaNotificacion>();
            _controller = new PlantillaNotificacionController(_serviceMock.Object);  
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR TODAS LAS PLANTILLAS NOTIFICACIONES (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas las plantillas exitoso")]
        public void ConsultaPlantillasCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaPlantillas()).Returns(new List<PlantillaNotificacionDTO>());
            var application = new ApplicationResponse<List<PlantillaNotificacionDTO>>();

            //act
            var result = _controller.ConsultaPlantillasCtrl();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria controlador para consultar todas las plantillas excepcion")]
        public void ConsultaPlantillasCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultaPlantillas()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ConsultaPlantillasCtrl();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS PARA consultar una plantilla notificacion en especifico (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion en especifico exitoso")]
        public void GetByGuidCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaGUID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO());
            var application = new ApplicationResponse<PlantillaNotificacionDTO>();

            //act
            var result = _controller.GetByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion en especifico excepcion")]
        public void GetByGuidCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaGUID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByGuidCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar una plantilla notificacion por un título específico (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un título específico exitoso")]
        public void GetByTituloCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTitulo(It.IsAny<String>())).Returns(new PlantillaNotificacionDTO());
            var application = new ApplicationResponse<PlantillaNotificacionDTO>();

            //act
            var result = _controller.GetByTituloCtrl(It.IsAny<String>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un título específico excepción")]
        public void GetByTituloCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTitulo(It.IsAny<String>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTituloCtrl(It.IsAny<String>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar una plantilla notificacion por un tipo estado específico mediante su ID (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su ID exitoso")]
        public void GetByTipoEstadoIdCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO());
            var application = new ApplicationResponse<PlantillaNotificacionDTO>();

            //act
            var result = _controller.GetByTipoEstadoIdCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su ID excepcion")]
        public void GetByTipoEstadoIdCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTipoEstadoIdCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para consultar una plantilla notificacion por un tipo estado específico mediante su nombre (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su nombre exitoso")]
        public void GetByTipoEstadoCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTipoEstadoTitulo(It.IsAny<String>())).Returns(new PlantillaNotificacionDTO());
            var application = new ApplicationResponse<PlantillaNotificacionDTO>();

            //act
            var result = _controller.GetByTipoEstadoCtrl(It.IsAny<String>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar una plantilla notificacion por un tipo estado específico mediante su nombre excepcion")]
        public void GetByTipoEstadoCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ConsultarPlantillaTipoEstadoTitulo(It.IsAny<String>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.GetByTipoEstadoCtrl(It.IsAny<String>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para crear plantilla notificacion (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear plantilla notificacion exitoso")]
        public void CrearPlantillaCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
            var application = new ApplicationResponse<PlantillaNotificacionDTOCreate>();

            //act
            var result = _controller.CrearPlantillaCtrl(It.IsAny<PlantillaNotificacionDTOCreate>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para crear plantilla notificacion excepcion")]
        public void CrearPlantillaCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearPlantillaCtrl(It.IsAny<PlantillaNotificacionDTOCreate>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para crear plantilla notificacion (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar plantilla notificacion exitoso")]
        public void ActualizarPlantillaCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ActualizarPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>(), It.IsAny<Guid>()));
            var application = new ApplicationResponse<PlantillaNotificacionDTOCreate>();

            //act
            var result = _controller.ActualizarPlantillaCtrl(It.IsAny<PlantillaNotificacionDTOCreate>(), It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar plantilla notificacion excepcion")]
        public void ActualizarPlantillaCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.ActualizarPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>(), It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ActualizarPlantillaCtrl(It.IsAny<PlantillaNotificacionDTOCreate>(), It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


//*
//PRUEBAS UNITARIAS para eliminar plantilla notificacion (CONTROLLER)
//*

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar plantilla notificacio exitoso")]
        public void EliminarPlantillaCtrlTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarPlantilla(It.IsAny<Guid>()));
            var application = new ApplicationResponse<PlantillaNotificacionDTOCreate>();

            //act
            var result = _controller.EliminarPlantillaCtrl(It.IsAny<Guid>());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar plantilla notificacio excepción")]
        public void EliminarPlantillaCtrlExceptionTest()
        {
            //arrange
            _serviceMock.Setup(p => p.EliminarPlantilla(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarPlantillaCtrl(It.IsAny<Guid>());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }
    }
}
