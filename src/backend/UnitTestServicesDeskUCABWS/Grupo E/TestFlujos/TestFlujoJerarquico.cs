using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;
using Telerik.JustMock.Setup;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestFlujos
{
    [TestClass]
    public class FlujoJerarquicoTest
    {
        private readonly TicketDAO _TicketDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;


        public FlujoJerarquicoTest()
        {

            //Preparación
            _contextMock = new Mock<IDataContext>();
            var myProfile = new List<Profile>
                {
                new TicketMapper()

            };
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            notificacionService = new Mock<INotificacion>();

            notificacionService.Setup(x => x.EnviarCorreo(null, "drbonavista@gmail.com"));
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _TicketDAO = new TicketDAO(_contextMock.Object, plantillaNotificacionDAO.Object, notificacionService.Object, _mapper);
            _contextMock.SetupDbContextData();
        }

        /*void Mock.SetupStatic(Type staticType);
        void Mock.SetupStatic(Type targetType, Behavior behavior);*/

        [TestMethod]
        public void CaminoFelizFlujoJerarquicoTest()
        {
            //arrange
            var ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA04"));

            notificacionService.Setup(x => x.EnviarNotificacion(It.IsAny<Ticket>(), It.IsAny<TipoNotificacion>(), It.IsAny<List<Empleado>>(), It.IsAny<IDataContext>())).ReturnsAsync(true);


            //Act
            _contextMock.Setup(a => a.DbContext.SaveChanges());
            _TicketDAO.FlujoAprobacionCreacionTicket(ticket);

            //Assert
            Assert.AreEqual("Pendiente D1", ticket.Estado.nombre);
            Assert.AreEqual(0, ticket.Bitacora_Tickets.Count);
            //Assert.AreEqual(1, ticket.Bitacora_Tickets.Count);
            Assert.AreEqual(2, ticket.Votos_Ticket.Count);
        }



        //Test para el servicio de un excepcion para flujo paralelo
        [TestMethod]
        public void FlujoJerarquicoExceptions()
        {
            //Arrage
            var Ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA03"));

            var Expected = new ApplicationResponse<string>()
            {
                Success = false,

            };
            notificacionService.Setup(x => x.EnviarNotificacion(It.IsAny<Ticket>(), It.IsAny<TipoNotificacion>(), It.IsAny<List<Empleado>>(), It.IsAny<IDataContext>())).ReturnsAsync(true);

            //act
            _contextMock.Setup(x => x.Flujos_Aprobaciones).Throws(new ExceptionsControl(""));

            var result = _TicketDAO.FlujoAprobacionCreacionTicket(Ticket);

            //assert
            Assert.IsTrue(result!="Exitoso");

        }
    }

}
