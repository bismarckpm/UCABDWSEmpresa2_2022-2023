using AutoMapper;
using Moq;
using PrioridadUnitTest;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestFlujos
{
    [TestClass]
    public class TestFlujoNoAprobacion
    {
        Mock<IDataContext> context;
        private readonly TicketDAO ticketDAO;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;

        private readonly IMapper mapper;

        public TestFlujoNoAprobacion()
        {
           
            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);
            context = new Mock<IDataContext>();
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            notificacionService = new Mock<INotificacion>();
            ticketDAO = new TicketDAO(context.Object, plantillaNotificacionDAO.Object, notificacionService.Object, mapper);
            context.SetupDbContextData();
        }

        //Prueba Unitaria para flujo no aprobacion
        [TestMethod]
        public void CaminoFelizFlujoNoAprobacionTest()
        {
            //arrange
            var Ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                titulo = "titulo",
                descripcion = "descripcion",
                fecha_creacion = DateTime.Now,
                Estado = new Estado()
                {
                    Id = Guid.NewGuid(),
                    nombre = "nombreEstado"
                },
                Tipo_Ticket = new Tipo_Ticket()
                {
                    nombre = "nombreTipoTicket"
                },
                Departamento_Destino = new Departamento()
                {
                    nombre = "nombreDepartamento",
                    grupo = new Grupo()
                    {
                        nombre = "nombreGrupo"
                    }
                },
                Prioridad = new Prioridad()
                {
                    nombre = "nombrePrioridad"
                },
                Emisor = new Empleado()
                {
                    Id = Guid.Parse("18f401c9-12aa-460f-80a2-00ff05bb0c06"),
                    primer_nombre = "nombreEmpleado",
                    primer_apellido = "apellidoEmpleado",
                    Cargo = new Cargo()
                    {
                        id = Guid.NewGuid(),
                        nombre_departamental = "nombreDepartamento",
                        descripcion = "descrip",
                        fecha_creacion = DateTime.Now,
                    }
                }
            };
           //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.FlujoNoAprobacion(Ticket);

            //Assert

        }

        //Test para el servicio de un excepcion para flujo no aprobacion
        [TestMethod]
        public void CaminoFelizFlujoNoAprobacionExceptions()
        {
            //Arrage
            var Ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                titulo = "titulo",
                descripcion = "descripcion",
                fecha_creacion = DateTime.Now,
                Estado = new Estado()
                {
                    Id = Guid.NewGuid(),
                    nombre = "nombreEstado"
                },
               
                Departamento_Destino = new Departamento()
                {
                    nombre = "nombreDepartamento",
                    grupo = new Grupo()
                    {
                        nombre = "nombreGrupo"
                    }
                },
                Prioridad = new Prioridad()
                {
                    nombre = "nombrePrioridad"
                },
                Emisor = new Empleado()
                {
                    Id = Guid.Parse("18f401c9-12aa-460f-80a2-00ff05bb0c06"),
                    primer_nombre = "nombreEmpleado",
                    primer_apellido = "apellidoEmpleado",
                    Cargo = new Cargo()
                    {
                        id = Guid.NewGuid(),
                        nombre_departamental = "nombreDepartamento",
                        descripcion = "descrip",
                        fecha_creacion = DateTime.Now,
                    }
                }
            };


            var Expected = new ApplicationResponse<string>()
            {
                Success = false,

            };

            //act
            context.Setup(x => x.Tickets).Throws(new Exception(""));

            var result = ticketDAO.FlujoNoAprobacion(Ticket);

            //assert
            Assert.IsNotNull(result);
           
        }
    }

}
 