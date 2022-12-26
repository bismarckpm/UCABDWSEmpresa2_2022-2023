using AutoMapper;
using Moq;
using UnitTestServicesDeskUCABWS.DataSeed;
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
            var Ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA02"));
            
           //Act
            context.Setup(a => a.DbContext.SaveChanges());
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO { Titulo = "Pantilla1", Descripcion = "Descripcion 1" });

            ticketDAO.FlujoAprobacion(Ticket);

            //Assert
            Assert.AreEqual("Siendo Procesado", Ticket.Estado.nombre);
            Assert.AreEqual(3, Ticket.Bitacora_Tickets.Count);
            Assert.AreEqual(3 , context.Object.Bitacora_Tickets.Where(x => x.Ticket.Id == Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA02")).Count());
        }

        //Test para el servicio de un excepcion para flujo no aprobacion
        [TestMethod]
        public void FlujoNoAprobacionExceptions()
        {
            //Arrage
            var Ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA02"));

            var Expected = new ApplicationResponse<string>()
            {
                Success = false,

            };
            //act
            context.Setup(x => x.Tickets).Throws(new Exception(""));
            var result = ticketDAO.FlujoNoAprobacion(Ticket);

            //assert
            Assert.IsTrue(result != "Exitoso");
        }
    }

}
 