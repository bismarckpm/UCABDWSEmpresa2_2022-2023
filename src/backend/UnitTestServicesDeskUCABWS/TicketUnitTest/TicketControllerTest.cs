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
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;


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
            _serviceMock.Setup(p => p.CrearTicket(It.IsAny<TicketNuevoDTO>())).Returns(new Ticket());
            var ticket = new Ticket();
           

            //Prueba
            var resultado = _controller.crearTicketCtrl(It.IsAny<TicketNuevoDTO>());

            //Verificación
            StringAssert.Equals(ticket, resultado);    
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
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para consultar tickets por estado y departamento exitosamente")]

        public void TestObtenerTicketsPorEstadoYDepartamentoCtrl()

        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketsPorEstadoYDepartamento(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), It.IsAny<string>(), new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<TicketInfoBasicaDTO>>());
            var application = new ApplicationResponse<List<TicketInfoBasicaDTO>>();

            //Prueba
            var resultado = _controller.obtenerTicketsPorEstadoYDepartamentoCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86", "", "38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación
            
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado.Success);

        }

       

        


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
            
            
            //Assert.IsTrue(application.Success);
            Assert.IsTrue(resultado.Success);
           // Assert.IsNotNull(resultado);


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
            //Assert.IsNotNull(resultado);
           // Assert.IsTrue(application.Success);
            Assert.IsTrue(resultado.Success);

        }

        //*
        //Prueba Unitaria para cambiar el estado de tickets
        //*

        
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para cambiar el estado de tickets exitosamente")]

        public void TestCambiarEstadoTicketCtrl()

        {

            //Preparación
            _serviceMock.Setup(p => p.cambiarEstadoTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"), new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"))).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<string>();
            var dto = new ActualizarDTO()
            {
                estadoId = "38f401c9-12aa-46bf-82a2-05ff65bb2c86",
                ticketId = "38f401c9-12aa-46bf-82a2-05ff65bb2c88"
            };

            //Prueba
            var resultado = _controller.cambiarEstadoTicketCtrl(dto);

            //Verificación

            
            //Assert.IsTrue(application.Success);
            //Assert.IsTrue(resultado.Success);
           // Assert.IsNotNull(resultado.Data);
            StringAssert.Equals(application, resultado);

        }


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

        //*
        //Prueba Unitaria para buscar departamentos
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener departamentos exitosamente")]
        public void TestObtenerDepartamentos()
        {

            //Preparación
            _serviceMock.Setup(p => p.buscarDepartamentos(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<DepartamentoSearchDTO>>());
            

            //Prueba
            var resultado = _controller.obtenerDepartamentos("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación

          
            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar departamento-empleados
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener departamentos-empleados exitosamente")]
        public void TestObtenerDepartamentoEmpleado()
        {

            //Preparación
            _serviceMock.Setup(p => p.buscarDepartamentoEmpleado(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<DepartamentoSearchDTO>());


            //Prueba
            var resultado = _controller.obtenerDepartamentoEmpleado("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar un tipo de ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener un tipo de ticket exitosamente")]
        public void TestObtenerTipoTickets()
        {

            //Preparación
            _serviceMock.Setup(p => p.buscarTipoTickets(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<Tipo_TicketDTOSearch>>());


            //Prueba
            var resultado = _controller.obtenerTipoTicketPorDepartamento("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar tipos de ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener tipos de ticket exitosamente")]
        public void TestObtenerTiposTickets()
        {

            //Preparación
            _serviceMock.Setup(p => p.buscarTiposTickets()).Returns(new ApplicationResponse<List<Tipo_Ticket>>());


            //Prueba
            var resultado = _controller.obtenerTiposTicketsPorDepartamento();

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar estados por departamentos
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener estados por departamento exitosamente")]
        public void TestObtenerEstadosPorDepartamentos()
        {

            //Preparación
            _serviceMock.Setup(p => p.buscarEstadosPorDepartamento(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<Estado>>());


            //Prueba
            var resultado = _controller.obtenerEstadosPorDepartamento("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para tomar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para tomar tickets exitosamente")]
        public void TestTomarTicketsCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.adquirirTicket(It.IsAny<TicketTomarDTO>())).Returns(new ApplicationResponse<string>());
            var application = new ApplicationResponse<String>();
            application.Success = true;

            //Prueba
            var resultado = _controller.tomarTicketCtrl(It.IsAny<TicketTomarDTO>());

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar tickets propios
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener tickets propios exitosamente")]
        public void TestObtenerTicketsPropiosCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketsPropios(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<TicketInfoBasicaDTO>>());


            //Prueba
            var resultado = _controller.obtenerTicketsPropiosCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para buscar tickets enviados
        //*
        [TestMethod(displayName: "Prueba Unitaria del Controlador de Ticket para obtener tickets enviados exitosamente")]
        public void TestObtenerTicketsEnviadosCtrl()
        {

            //Preparación
            _serviceMock.Setup(p => p.obtenerTicketsEnviados(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"))).Returns(new ApplicationResponse<List<TicketInfoBasicaDTO>>());


            //Prueba
            var resultado = _controller.obtenerTicketsEnviadosCtrl("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

    }
}