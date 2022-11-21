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
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones


namespace TicketUnitTest
{
    [TestClass]
    public class TicketControllerTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ITicketDAO> _serviceMock;
        private readonly TicketController _controller;

        public TicketControllerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _serviceMock = new Mock<ITicketDAO>(); 
            _controller = new TicketController(_mapperMock.Object, _serviceMock.Object);
        }


        //*
        //Prueba Unitaria para crear tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para crear tickets exitosamente")]
        public void TestCrearTicketCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.crearTicket(It.IsAny<TicketNuevoDTO>())).Returns(It.IsAny<string>());
            var application = new ApplicationResponse<String>();

            //Prueba
            var resultado = _controller.crearTicketCtrl(It.IsAny<TicketNuevoDTO>());

            //Verificación
            Assert.AreEqual(application.GetType(), resultado.GetType());
        }
        //*
        //Prueba Unitaria para consultar tickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar tickets por id exitosamente")]

        public void TestObtenerTicketPorIdCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketPorId(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new Ticket());
            var application = new ApplicationResponse<Ticket>();

            //Prueba
            var resultado = _controller.obtenerTicketPorIdCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación
          
            StringAssert.Equals(application.ToString(), resultado.ToString());
            
            
             
        }

        

        //*
        //Prueba Unitaria para consultar tickets por estado y departamento
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar tickets por estado y departamento exitosamente")]

        public void TestObtenerTicketsPorEstadoYDepartamentoCtrl()

        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketPorEstadoYDepartamento(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), It.IsAny<string>())).Returns(new List<Ticket>());
            var application = new ApplicationResponse<List<Ticket>>();

            //Prueba
            var resultado = _controller.obtenerTicketsPorEstadoYDepartamentoCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86", "");

            //Verificación
            StringAssert.Equals(application.ToString(), resultado.ToString());

        }

       

        //*
        //Prueba Unitaria para consultar familiatickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar familiatickets por id exitosamente")]

        public void TestObtenerFamiliaTicketCtrl()
        {
            //Preparación
            _serviceMock.Setup(p => p.obtenerFamiliaTickets(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new List<Ticket>());
            var application = new ApplicationResponse<List<Ticket>>();

            //Prueba
            var resultado = _controller.obtenerFamiliaTicketCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación
            StringAssert.Equals(application.ToString(), resultado.ToString());

        }


        

 


    }

   
}