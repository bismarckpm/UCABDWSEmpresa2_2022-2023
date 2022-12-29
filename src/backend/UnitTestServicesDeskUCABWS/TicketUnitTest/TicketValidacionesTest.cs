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



//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace TicketUnitTest
{

    [TestClass]
    public class TicketValidacionesTest
    {
        private readonly Mock<IDataContext> _contextMock;
        private readonly TicketValidaciones _ticketValidaciones;

        public TicketValidacionesTest()
    {
            _contextMock = new Mock<IDataContext>();
            _ticketValidaciones = new TicketValidaciones(_contextMock.Object);
            
            _contextMock.SetupDbContextDataTicket();
     }


        //*
        //Prueba Unitaria para validar ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION NO SE ENCUENTRA TICKET EN LA BD")]
        public void ValidarTicketTest()
        {
            _contextMock.SetUpContextDataVacioTicket();
            //* Verificación
            Assert.ThrowsException<TicketException>(() => _ticketValidaciones.validarTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70")));

        }

        //*
        //Prueba Unitaria para validar titulo
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION TITULO NO VALIDO")]
        public void ValidarTituloTest()
        {

            //* Verificación
            Assert.ThrowsException<TicketTituloException>(() => _ticketValidaciones.validarTitulo("a"));

        }

        //*
        //Prueba Unitaria para validar ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID NO PROVISTO")]
        public void ValidarTicketTest2()
        {
            //* Verificación
            _contextMock.SetupDbContextDataTicket();
            Assert.ThrowsException<TicketException>(() => _ticketValidaciones.validarTicket(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar descripcion
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION DESCRIPCION NO VALIDO")]
        public void ValidarDescripcionTest()
        {

            //* Verificación
            Assert.ThrowsException<TicketDescripcionException>(() => _ticketValidaciones.validarDescripcion("a"));

        }

        //*
        //Prueba Unitaria para validar fecha
        //*
        /*  [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION FECHA NO VALIDA")]
          public void ValidarFechaTest()
          {


              Assert.ThrowsException<TicketFechaException>(() => _ticketValidaciones.validarFecha(new DateTime()));

          }*/


        //*
        //Prueba Unitaria para validar departamento
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID DEPT NO PROVISTO")]
        public void ValidarDepartamentoTest()
        {   //* Verificación
            _contextMock.SetUpContextDataVacioTicket();
            Assert.ThrowsException<TicketDepartamentoException>(() => _ticketValidaciones.validarDepartamento(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar departamento
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION DEPT NO REGISTRADO")]
        public void ValidarDepartamentoTest2()
        {     //* Verificación
            _contextMock.SetUpContextDataVacioDeptartamento();
            Assert.ThrowsException<TicketDepartamentoException>(() => _ticketValidaciones.validarDepartamento(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar estado
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID ESTADO NO PROVISTO")]
        public void ValidarEstadoTest()
        {      //* Verificación
            _contextMock.SetUpContextDataVacioTicket();
            Assert.ThrowsException<TicketEstadoException>(() => _ticketValidaciones.validarTicketEstado(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar estado
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ESTADO NO REGISTRADO")]
        public void ValidarEstadoTest2()
        {       //* Verificación
            _contextMock.SetUpContextDataVacioEstado();
            Assert.ThrowsException<TicketEstadoException>(() => _ticketValidaciones.validarTicketEstado(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar prioridad
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID PRIORIDAD NO PROVISTO")]
        public void ValidarPrioridadTest()
        {    //* Verificación
            _contextMock.SetUpContextDataVacioTicket();
            Assert.ThrowsException<TicketPrioridadException>(() => _ticketValidaciones.validarPrioridad(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar prioridad
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION PRIORIDAD NO REGISTRADO")]
        public void ValidarPrioridadTest2()
        {     //* Verificación
            _contextMock.SetUpContextDataVacioPrioridad();
            Assert.ThrowsException<TicketPrioridadException>(() => _ticketValidaciones.validarPrioridad(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar votos
        //*
        /*[TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID VOTO NO PROVISTO")]
        public void ValidarVotoTest()
        {    //* Verificación
            _contextMock.SetUpContextDataVacioTicket();
            Assert.ThrowsException<TicketVotosException>(() => _ticketValidaciones.validarTicketVotos(Guid.Empty));

        }*/

        //*
        //Prueba Unitaria para validar votos
        //*
        /*[TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION VOTO NO REGISTRADO")]
        public void ValidarVotoTest2()
        {      //* Verificación
            _contextMock.SetUpContextDataVacioVotos();
            Assert.ThrowsException<TicketVotosException>(() => _ticketValidaciones.validarTicketVotos(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }*/

        //*
        //Prueba Unitaria para validar familia
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID Familia NO PROVISTO")]
        public void ValidarFamiliaTest()
        {     //* Verificación
            _contextMock.SetUpContextDataVacioTicket();
            Assert.ThrowsException<TicketFamiliaException>(() => _ticketValidaciones.validarTicketFamilia(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar familia
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION Familia NO REGISTRADO")]
        public void ValidarFamiliaTest2()
        {     //* Verificación
            _contextMock.SetUpContextDataVacioFamilia();
            Assert.ThrowsException<TicketFamiliaException>(() => _ticketValidaciones.validarTicketFamilia(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar emisor
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID EMISOR NO PROVISTO")]
        public void ValidarEmisorTest()
        {
            
            Assert.ThrowsException<TicketEmisorException>(() => _ticketValidaciones.validarEmisor(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar emisor
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION EMISOR NO REGISTRADO")]
        public void ValidarEmisorTest2()
        {    //* Verificación
            _contextMock.SetUpContextDataVacioEmpleado();
            Assert.ThrowsException<TicketEmisorException>(() => _ticketValidaciones.validarEmisor(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar bitacora
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION ID BITACORA NO PROVISTO")]
        public void ValidarBitacoraTest()
        {
            //* Verificación
            Assert.ThrowsException<TicketBitacoraException>(() => _ticketValidaciones.validarBitacora(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar bitacora
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION Bitacora NO REGISTRADO")]
        public void ValidarBitacoraTest2()
        {    //* Verificación
            _contextMock.SetUpContextDataVacioBitacora();
            Assert.ThrowsException<TicketBitacoraException>(() => _ticketValidaciones.validarBitacora(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }

        //*
        //Prueba Unitaria para validar tipo ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets EXCEPCION ID TIPO TICKET NO PROVISTO")]
        public void ValidarTipoTicketTest()
        {
            //* Verificación
            Assert.ThrowsException<TicketTipoException>(() => _ticketValidaciones.validarTipoTicket(Guid.Empty));

        }

        //*
        //Prueba Unitaria para validar tipo ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria para validar los tickets  EXCEPCION TIPO TICKET NO REGISTRADO")]
        public void ValidarTipoTicketTest2()
        {    //* Verificación
            _contextMock.SetUpContextDataVacioTipo();
            Assert.ThrowsException<TicketTipoException>(() => _ticketValidaciones.validarTipoTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c05")));

        }


    }
   
}
