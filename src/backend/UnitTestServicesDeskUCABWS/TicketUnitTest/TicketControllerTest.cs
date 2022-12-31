using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Data;
using System.Text;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;


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
            _serviceMock.Setup(p => p.crearTicket(It.IsAny<TicketNuevoDTO>())).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<String>();
            application.Success = true;

            //Prueba
            var resultado = _controller.crearTicketCtrl(It.IsAny<TicketNuevoDTO>());

            //Verificación
            Assert.IsTrue(application.Success);
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);
        }
        //*
        //Prueba Unitaria para consultar tickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar tickets por id exitosamente")]

        public void TestObtenerTicketPorIdCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketPorId(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<TicketInfoCompletaDTO>());
            var application = new ApplicationResponse<TicketInfoCompletaDTO>();

            //Prueba
            var resultado = _controller.obtenerTicketPorIdCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación

            
            Assert.IsNotNull(resultado); 
            Assert.IsTrue(resultado.Success);



        }

        

        //*
        //Prueba Unitaria para consultar tickets por estado y departamento
        //*
        /*[TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar tickets por estado y departamento exitosamente")]

        public void TestObtenerTicketsPorEstadoYDepartamentoCtrl()

        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketsPorEstadoYDepartamento(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), It.IsAny<string>())).Returns(new ApplicationResponse<List<TicketInfoBasicaDTO>>());
            var application = new ApplicationResponse<List<TicketInfoBasicaDTO>>();

            //Prueba
            var resultado = _controller.obtenerTicketsPorEstadoYDepartamentoCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86", "");

            //Verificación
            
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);

        }*/

       

        


        //*
        //Prueba Unitaria para obtener la bitacora de tickets
        //*
        
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener las bitacoras exitosamente")]
        public void TestobtenerBitacorasCtrl()

        {
            //Preparación
            _serviceMock.Setup(p => p.obtenerBitacoras((new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86")))).Returns(new ApplicationResponse<List<TicketBitacorasDTO>>());

            var application = new ApplicationResponse<List<TicketBitacorasDTO>>();
            application.Success = true;

            //Prueba
            var resultado = _controller.obtenerBitacorasCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Verificación
            
            
            Assert.IsTrue(application.Success);
            Assert.IsTrue(resultado.Success);
            Assert.IsNotNull(resultado);


        }


        


        //*
        //Prueba Unitaria para realizar un merge de tickets
        //*
     
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para realizar merge de tickets exitosamente")]

        public void TestMergeTicketsCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.mergeTickets(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), new List<Guid>
            {

                new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
                new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650809")})).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<String>();
            application.Success = true;

            //Prueba
            var ticketMergeDTO =
            new TicketsMergeDTO
{
    ticketPrincipalId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
    ticketsSecundariosId = new List<Guid>
    {

        new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
        new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650809") }
       };
            var resultado = _controller.mergeTicketsCtrl(ticketMergeDTO);

            //Verificación
            Assert.IsNotNull(resultado);
            Assert.IsTrue(application.Success);
            Assert.IsTrue(resultado.Success);

        }

        //*
        //Prueba Unitaria para cambiar el estado de tickets
        //*
        /*[TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para cambiar el estado de tickets exitosamente")]

        public void TestCambiarEstadoTicketCtrl()

        {

            //Preparación
            _serviceMock.Setup(p => p.cambiarEstadoTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"))).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<string>();

            //Prueba
            var resultado = _controller.cambiarEstadoTicketCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86", "38f401c9-12aa-46bf-82a2-05ff65bb2c87");

            //Verificación

            
            Assert.IsTrue(application.Success);
            Assert.IsTrue(resultado.Success);

        }*/


        //*
        //Prueba Unitaria para reenviar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para reenviar tickets exitosamente")]
        public void TestReenviarTicket()
        {

            //Preparación
            _serviceMock.Setup(p => p.reenviarTicket(It.IsAny<TicketReenviarDTO>())).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<String>();
            application.Success = true;

            //Prueba
            var resultado = _controller.reenviarTicket(It.IsAny<TicketReenviarDTO>());

            //Verificación
         
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para obtener familia de tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener familia de tickets exitosamente")]
        public void TestObtenerFamiliaTicket()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerFamiliaTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<TicketInfoCompletaDTO>>());
            var application = new ApplicationResponse<List<TicketInfoCompletaDTO>>();
            application.Success = true;

            //Prueba
            var resultado = _controller.obtenerFamiliaTicketCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para eliminar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para eliminar tickets exitosamente")]
        public void TestEliminarTicket()
        {

            //Preparación
            _serviceMock.Setup(p => p.eliminarTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<string>());
         ;

            //Prueba
            var resultado = _controller.eliminarTicket("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación

            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);
        }



    }
}