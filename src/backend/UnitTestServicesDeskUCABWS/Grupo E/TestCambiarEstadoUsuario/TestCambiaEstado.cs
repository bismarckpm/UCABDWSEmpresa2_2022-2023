using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestCambiarEstadoUsuario
{
    [TestClass]
    public class TestCambiaEstado
    {
        Mock<IDataContext> context;
        private readonly TicketDAO ticketDAO;
        private readonly Mock<IPlantillaNotificacion> mockPlantilla;
        private readonly Mock<INotificacion> mockNotificacion;
        private IMapper mapper;


        public TestCambiaEstado()
        {
            context = new Mock<IDataContext>();
            mockNotificacion= new Mock<INotificacion>();
            mockPlantilla = new Mock<IPlantillaNotificacion>();
            ticketDAO = new TicketDAO(context.Object, mockPlantilla.Object,mockNotificacion.Object, mapper);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizCambiarEstado()
        {
            //arrange 
            var ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA04"));
            var Estado = context.Object.Tipos_Estados.Find(Guid.Parse("822D08E6-713D-4F03-A634-520693D31E96"));

            mockNotificacion.Setup(x => x.EnviarNotificacion(It.IsAny<Ticket>(), It.IsAny<TipoNotificacion>(), It.IsAny<List<Empleado>>(), It.IsAny<IDataContext>())).ReturnsAsync(true);

            //act
            var result = ticketDAO.CambiarEstado(ticket,Estado.nombre, new List<Empleado>());

            Assert.IsTrue(result);
            Assert.AreEqual("Cancelado D2", ticket.Estado.nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ThrowExceptionCambiarEstado()
        {
            //arrange 
            var ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA04"));
            var Estado = context.Object.Tipos_Estados.Find(Guid.Parse("822D08E6-713D-4F03-A634-520693D31E96"));

            mockNotificacion.Setup(x => x.EnviarNotificacion(It.IsAny<Ticket>(), It.IsAny<TipoNotificacion>(), It.IsAny<List<Empleado>>(), It.IsAny<IDataContext>())).Throws(new Exception());

            //act
            var result = ticketDAO.CambiarEstado(ticket, Estado.nombre, new List<Empleado>());
        }
    }
}
