using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Data;
using System.Text;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using static ServicesDeskUCABWS.BussinesLogic.Excepciones.PrioridadExcepciones;



//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace PrioridadUnitTest
{
    [TestClass]
    public class PrioridadValidacionesTest


    {
        private readonly Mock<IDataContext> _contextMock;
        private readonly PrioridadValidaciones _prioridadValidaciones;

        public PrioridadValidacionesTest()
        {
            _contextMock = new Mock<IDataContext>();
            _prioridadValidaciones = new PrioridadValidaciones(_contextMock.Object);

            _contextMock.SetupDbContextData();
        }

        //*
        //Prueba Unitaria para validar prioridad id
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los guid de prioridad  EXCEPCION NO SE ENCUENTRA PRIORIDAD EN LA BD")]
        public void ValidarPrioridadTest()
        {
            //* Preparación
            _contextMock.SetUpContextDataVacio();
            //* Prueba y Verificación
            Assert.ThrowsException<PrioridadNoExisteException>(() => _prioridadValidaciones.validarPrioridadGuid(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70")));

        }

        //*
        //Prueba Unitaria para validar nombre
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar las prioridades  EXCEPCION NOMBRE NO VALIDO")]
        public void ValidarNombreTest()
        {

            //* Prueba y Verificación
            Assert.ThrowsException<PrioridadNombreLongitudException>(() => _prioridadValidaciones.validarPrioridadNombre("a"));

        }

        //*
        //Prueba Unitaria para validar descripcion
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar las prioridades  EXCEPCION DESCRIPCION NO VALIDO")]
        public void ValidarDescripcionTest()
        {

            //* Prueba y Verificación
            Assert.ThrowsException<PrioridadDescripcionLongitudException>(() => _prioridadValidaciones.validarPrioridadDescripcion("a"));

        }

        //*
        //Prueba Unitaria para validar estado
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar las prioridades  EXCEPCION ESTADO NO VALIDO")]
        public void ValidarEstadoTest()
        {

            //* Prueba y Verificación
            Assert.ThrowsException<PrioridadEstadoException>(() => _prioridadValidaciones.validarPrioridadEstado("a"));

        }
    }
}
