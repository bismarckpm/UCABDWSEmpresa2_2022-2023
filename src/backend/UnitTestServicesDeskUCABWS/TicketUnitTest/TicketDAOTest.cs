using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        //Prueba Unitaria para crear los tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para crear los tickets")]
        public void crearTicketTest()
        {

            //Prueba
            var ticket = new TicketNuevoDTO
            {
                titulo = "titulo",
                descripcion = "a",
                empleado_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70"),
                prioridad_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c60"),
                tipoTicket_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c50"),
                departamentoDestino_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c40")
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var application = "Ticket creado satisfactoriamente";
            var resultado = _TicketDAO.crearTicket(ticket);
            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
            StringAssert.Equals(application, resultado);

        }


        //*
        //Prueba Unitaria para consultar tickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por id")]
        public void ObtenerTicketPorIdTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var application = "Proceso de búsqueda exitoso";


            //Prueba
            var resultado = _TicketDAO.obtenerTicketPorId(id);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
            StringAssert.Equals(application, resultado);

        }



        //*
        //Prueba Unitaria para consultar tickets por estado y departamento
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por estado y departamento")]
        public void ObtenerTicketPorEstadoYDepartamentoTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var estado = "habilitado";
            var application = "Proceso de búsqueda exitoso";


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsPorEstadoYDepartamento(id, estado);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
            StringAssert.Equals(application, resultado);
        }
    }

}