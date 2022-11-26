using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.ApplicationResponse;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Data;
using System.Text;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace PrioridadUnitTest
{
    [TestClass]
    public class PrioridadControllerTest
    {

        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPrioridadDAO> _serviceMock;
        private readonly PrioridadController _controller;



        public PrioridadControllerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _serviceMock = new Mock<IPrioridadDAO>();
            _controller = new PrioridadController(_serviceMock.Object, _mapperMock.Object);




        }

        //*
        //Prueba Unitaria para consultar todas las prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar todas las prioridades exitosamente")]
        public void TestObtenerPrioridadesCtrl()
        {
            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridades()).Returns(new List<PrioridadDTO>());
            var application = new ApplicationResponse<List<PrioridadDTO>>();



            //Prueba
            var resultado = _controller.ObtenerPrioridadesCtrl();



            //Verificación

            Assert.AreEqual(application.GetType(), resultado.GetType());


        }


        //*
        //Prueba Unitaria para consultar propiedades habilitadas
        //*

        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar prioridades habilitadas exitosamente")]

        public void TestObtenerPrioridadesHabilitadas()
        {
            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridadesHabilitadas()).Returns(new List<PrioridadDTO>());
            var application = new ApplicationResponse<List<PrioridadDTO>>();

            //Prueba
            var resultado = _controller.ObtenerPrioridadesHabilitadas();

            //Verificación
            StringAssert.Equals(application.GetType(), resultado.GetType());


        }


        //*
        //Prueba Unitaria para consultar prioridad por Guid
        //*

        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar todas las prioridades por estado exitosamente")]

        public void TestObtenerPrioridad()
        {

            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridad(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new PrioridadDTO());
            var application = new ApplicationResponse<PrioridadDTO>();



            //Prueba
            var resultado = _controller.ObtenerPrioridad("38f401c9-12aa-46bf-82a2-05ff65bb2c86");



            //Verificación

            //StringAssert.Equals(application.ToString(), resultado.ToString());
            Assert.AreEqual(application.GetType(), resultado.GetType());

        }



        //*
        //Prueba Unitaria para crear prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para crear prioridades exitosamente")]
        public void TestCrearPrioridadCtrl()

        {
            //Preparación

            //_serviceMock.Setup(p => p.CrearPrioridad(It.IsAny<PrioridadDTO>())).Returns(It.IsAny<string>());
            var application = new ApplicationResponse<String>();


            //Prueba
            //var resultado = _controller.crearPrioridadCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            //Assert.AreEqual(application.GetType(), resultado.GetType());


        }


        //*
        //Prueba Unitaria para modificar prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para modificar prioridades exitosamente")]
        public void TestModificarPrioridadEstadoPorNombreCtrl()

        {
            //Preparación

            _serviceMock.Setup(p => p.ModificarPrioridad(It.IsAny<PrioridadDTO>())).Returns(It.IsAny<string>());
            var application = new ApplicationResponse<String>();


            //Prueba
            var resultado = _controller.ModificarPrioridadEstadoPorNombreCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            Assert.AreEqual(application.GetType(), resultado.GetType());


        }

        //*
        //PRUEBAS UNITARIAS SOBRE LAS EXCEPCIONES
        //*


        //*
        //Prueba Unitaria para crear prioridades EXCEPCION
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para crear prioridades excepcion")]
        public void crearPrioridadCtrlExcepcionTest()
        {
            //Preparación
            //_serviceMock.Setup(p => p.CrearPrioridad(It.IsAny<PrioridadDTO>())).Throws(new Exception("", new Exception()));

            //Prueba
            //var ex = _controller.crearPrioridadCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            //Assert.IsNotNull(ex);
            //Assert.IsFalse(ex.Success);

        }


        //*
        //Prueba Unitaria para consultar prioridades EXCEPCION
        //*/*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar prioridades excepcion")]
        public void ObtenerPrioridadesCtrlExcepcionTest()
        {
            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridades()).Throws(new Exception("", new Exception()));

            //Prueba
            var ex = _controller.ObtenerPrioridadesCtrl();

            //Verificación
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);

        }

        //Prueba Unitaria para consultar prioridades habilitadas EXCEPCION
        //*/*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar prioridades habilitadas excepcion")]
        public void ObtenerPrioridadesHabilitadasCtrlExcepcionTest()
        {
            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridadesHabilitadas()).Throws(new Exception("", new Exception()));

            //Prueba
            var ex = _controller.ObtenerPrioridadesHabilitadas();

            //Verificación
            Assert.IsNotNull(ex);


        }


        //Prueba Unitaria para consultar prioridades por id EXCEPCION
        //*/*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar prioridades por id excepcion")]
        public void ObtenerPrioridadExcepcionTest()
        {
            //Preparación
            _serviceMock.Setup(p => p.ObtenerPrioridad(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Throws(new Exception("", new Exception()));

            //Prueba
            var ex = _controller.ObtenerPrioridad("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);


        }


        //*
        //Prueba Unitaria para modificar prioridades EXCEPCION
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para modificar prioridades excepcion")]
        public void ModificarPrioridadEstadoPorNombreCtrlExcepcionTest()
        {
            //Preparación
            _serviceMock.Setup(p => p.ModificarPrioridad(It.IsAny<PrioridadDTO>())).Throws(new Exception("", new Exception()));

            //Prueba
            var ex = _controller.ModificarPrioridadEstadoPorNombreCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);

        }


    }
}