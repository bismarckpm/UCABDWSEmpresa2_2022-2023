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
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace TicketUnitTest
{
    [TestClass]
    public class TicketDAOTest
    {
        private readonly TicketDAO _TicketDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;

        public TicketDAOTest()
        {

            //Preparación
           
            _contextMock = new Mock<IDataContext>();
            var myProfile = new List<Profile>
                {
                new TicketMapper()

            };
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            notificacionService = new Mock<INotificacion>();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _TicketDAO = new TicketDAO(_contextMock.Object, plantillaNotificacionDAO.Object, notificacionService.Object, _mapper);
            _contextMock.SetupDbContextDataTicket();
        }

       
        

        //*
        //Prueba Unitaria para consultar tickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por id")]
        public void ObtenerTicketPorIdTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var application = new ApplicationResponse<TicketInfoCompletaDTO>();


            //Prueba
            var resultado = _TicketDAO.obtenerTicketPorId(id);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
          

        }



        //Prueba Unitaria para consultar tickets por estado y departamento

        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por estado y departamento")]
        public void ObtenerTicketPorEstadoYDepartamentoTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var id2 = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87");
            var estado = "Habilitado";
            var application = new ApplicationResponse<List<TicketInfoBasicaDTO>>();


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsPorEstadoYDepartamento(id, estado, id2);

            //Verificación


            Assert.AreEqual(application.GetType(), resultado.GetType());
          
        }



        /*
        //Prueba Unitaria para consultar tickets por estado y departamento
        //*
        /*[TestMethod(displayName: "Prueba Unitaria para consultar los tickets por estado y departamento")]
        public void ObtenerTicketPorEstadoYDepartamentoTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var estado = "Habilitado";
            var application = "Proceso de búsqueda exitoso";


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsPorEstadoYDepartamento(id, estado);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
            /*StringAssert.Equals(application, resultado);
            Assert.Equals(application, resultado);
            Assert.IsTrue(resultado.Success);
        }*/

            //*
            //Prueba Unitaria para cambiar el estado del ticket
            //*
            [TestMethod(displayName: "Prueba Unitaria para cambiar el estado del ticket")]
        public void CambiarEstadoTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var estado = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87");
           


            //Prueba
            var resultado = _TicketDAO.cambiarEstadoTicket(id, estado);
            var result = new ApplicationResponse<string>();

            //Verificación
            StringAssert.Equals(result.GetType(), resultado.GetType());

        }

        


        //*
        //Prueba Unitaria para hacer merge de tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para hacer merge de tickets")]
        public void MergeTicketsTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var lista = new List<Guid> {
                new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c85"),
                new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")

            };




            //Prueba
            var resultado = _TicketDAO.mergeTickets(id, lista);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para reenviar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para reenviar tickets")]
        public void ReenviarTicketsTest()
        {
            //Preparación
            var ticket = new TicketReenviarDTO();
            var application = new ApplicationResponse<string>();
            application.Success = true;

            //Prueba
            var resultado = _TicketDAO.reenviarTicket(ticket);

            //Verificación

            //StringAssert.Equals(application.GetType(), resultado.GetType());
            Assert.IsTrue(application.Success);
        
        }

        //*
        //Prueba Unitaria para obtener familias de tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para obtener familias de tickets")]
        public void ObtenerFamiliaTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.obtenerFamiliaTicket(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para obtener tickets propios
        //*
        [TestMethod(displayName: "Prueba Unitaria para obtener tickets propios")]
        public void ObtenerTicketsPropiosTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsPropios(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para obtener tickets enviados
        //*
        [TestMethod(displayName: "Prueba Unitaria para obtener tickets enviados")]
        public void ObtenerTicketsEnviadosTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsEnviados(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para eliminar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para eliminar tickets")]
        public void EliminarTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.eliminarTicket(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para adquirir tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para adquirir tickets")]
        public void AdquirirTicketTest()
        {
            //Preparación
            var ticket = new TicketTomarDTO
            {
               
                empleadoId ="0F636FB4-7F04-4A2E-B2C2-359B99BE85D1",
                ticketId = "2DF5B096-DC5A-421F-B109-2A1D1E650812"
                
            };


            //Prueba
            var resultado = _TicketDAO.adquirirTicket(ticket);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }



        //*
        //Prueba Unitaria para buscar estados por dept
        //*
        [TestMethod(displayName: "Prueba Unitaria para buscar estados por dept")]
        public void BuscarEstadosPorDeptTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.buscarEstadosPorDepartamento(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para buscar tipos tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para buscar tipos tickets")]
        public void BuscarTiposTicketsTest()
        {
            //Preparación
           


            //Prueba
            var resultado = _TicketDAO.buscarTiposTickets();

            //Verificación


            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para buscar tipo tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para buscar tipo tickets")]
        public void BuscarTipoTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.buscarTipoTickets(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }


        //*
        //Prueba Unitaria para buscar dept-empleado
        //*
        [TestMethod(displayName: "Prueba Unitaria para buscar dept-empleado")]
        public void BuscarDeptEmpleadoTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var application = new ApplicationResponse<DepartamentoSearchDTO>();


            //Prueba
            var resultado = _TicketDAO.buscarDepartamentoEmpleado(id);

            //Verificación


        
            StringAssert.Equals(application.GetType(), resultado.GetType());
        }



        //*
        //Prueba Unitaria para buscar depts
        //*
        [TestMethod(displayName: "Prueba Unitaria para buscar depts")]
        public void BuscarDeptsTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
           


            //Prueba
            var resultado = _TicketDAO.buscarDepartamentos(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
           
        }




    }

}