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


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace PrioridadUnitTest
{
    [TestClass]
    public class PrioridadControllerTest
    {
        //private readonly Mock<DataContext> _contextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IPrioridadDAO> _serviceMock;
        private readonly PrioridadController _controller;
        //private readonly PrioridadDAO _dao;


        public PrioridadControllerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _serviceMock = new Mock<IPrioridadDAO>();
            _controller = new PrioridadController(_serviceMock.Object, _mapperMock.Object);
            
            


        }

        //*
        //Prueba Unitaria para consultar todas las prioridades
        //*
        /*[TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar todas las prioridades exitosamente")]
        public void TestObtenerPrioridadesCtrl()
        {
            //Preparación
            _serviceMock.Setup(p => p.obtenerPrioridades()).Returns(new List<PrioridadDTO>());
            var application = new ApplicationResponse<List<PrioridadDTO>>();
            


            //Prueba
            var resultado = _controller.obtenerPrioridadesCtrl();



            //Verificación

            Assert.AreEqual(application.GetType(), resultado.GetType());


        }


        //*
        //Prueba Unitaria para consultar una prioridad por nombre
        //*

        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar prioridades por nombre exitosamente")]

        public void TestObtenerPrioridadPorNombreCtrl()
        {
            //Preparación
            _serviceMock.Setup(p => p.obtenerPrioridadPorNombre(It.IsAny<string>())).Returns(new PrioridadDTO());
            var application = new ApplicationResponse<PrioridadDTO>();

            //Prueba
            var resultado = _controller.obtenerPrioridadPorNombreCtrl(It.IsAny<string>());

            //Verificación
            StringAssert.Equals(application.GetType(), resultado.GetType());

        }


        //*
        //Prueba Unitaria para consultar prioridades por estado
        //*

        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para consultar todas las prioridades por estado exitosamente")]

        public void TestObtenerPrioridadesPorEstadoCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerPrioridadesPorEstado(It.IsAny<string>())).Returns(new List<PrioridadDTO>());
            var application = new ApplicationResponse<List<PrioridadDTO>>();



            //Prueba
            var resultado = _controller.obtenerPrioridadesPorEstadoCtrl(It.IsAny<string>());



            //Verificación

            Assert.AreEqual(application.GetType(), resultado.GetType());

        }



        //*
        //Prueba Unitaria para crear prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para crear prioridades exitosamente")]
        public void TestCrearPrioridadCtrl()

        {
            //Preparación

            _serviceMock.Setup(p => p.crearPrioridad(It.IsAny<PrioridadDTO>())).Returns(It.IsAny<string>());
            var application = new ApplicationResponse<String>();


            //Prueba
            var resultado = _controller.crearPrioridadCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            Assert.AreEqual(application.GetType(), resultado.GetType());


        }


        //*
        //Prueba Unitaria para modificar prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Prioridad para modificar prioridades exitosamente")]
        public void TestModificarPrioridadEstadoPorNombreCtrl()

        {
            //Preparación

            _serviceMock.Setup(p => p.modificarPrioridad(It.IsAny<PrioridadDTO>())).Returns(It.IsAny<string>());
            var application = new ApplicationResponse<String>();


            //Prueba
            var resultado = _controller.modificarPrioridadEstadoPorNombreCtrl(It.IsAny<PrioridadDTO>());

            //Verificación
            Assert.AreEqual(application.GetType(), resultado.GetType());


        }




        */
     


    }
}