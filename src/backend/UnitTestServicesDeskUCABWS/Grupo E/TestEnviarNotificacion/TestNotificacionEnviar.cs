using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEnviarNotificacion
{
    [TestClass]
    public class TestNotificacionEnviar
    {
        private readonly NotificacionService _notificacionDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;


        public TestNotificacionEnviar()
        {
            _contextMock = new Mock<IDataContext>();
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            _contextMock.SetupDbContextData();
            _notificacionDAO = new NotificacionService(_contextMock.Object,plantillaNotificacionDAO.Object);
        }

        /*[TestMethod]
        public void TicketAprobado()
        {
            //Arrange
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO {
                Titulo = "Pantilla1", 
                Descripcion = "Descripcion 1",
                TipoEstado = new TipoEstadoDTO()
                {
                    nombre = "lwlfknwelkf",
                    etiqueta = new HashSet<EtiquetaDTO>()
                }
            });
            var ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA04"));
            var ListaEmpleado = new List<Empleado>()
            {
                ticket.Emisor,
                new Empleado() { correo ="prueba123@gmail.com"}
            };
            //Act
            var result =_notificacionDAO.EnviarNotificacion(ticket, TipoNotificacion.Aprobado, ListaEmpleado,_contextMock.Object);


            //Assert
            Assert.IsTrue(result.Result);
        }

        [TestMethod]
        public void TicketSiendoProcesado()
        {
            //Arrange
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO
            {
                Titulo = "Pantilla1",
                Descripcion = "Descripcion 1",
                TipoEstado = new TipoEstadoDTO()
                {
                    nombre = "lwlfknwelkf",
                    etiqueta = new HashSet<EtiquetaDTO>()
                }
            });
            var ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA05"));
            var ListaEmpleado = new List<Empleado>()
            {
                ticket.Emisor,
                new Empleado() { correo ="prueba123@gmail.com"}
            };
            //Act
            var result = _notificacionDAO.EnviarNotificacion(ticket, TipoNotificacion.SiendoProcesado, ListaEmpleado, _contextMock.Object);


            //Assert
            Assert.IsTrue(result.Result);
        }

        [TestMethod]
        public void TicketPendiente()
        {
            //Arrange
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO
            {
                Titulo = "Pantilla1",
                Descripcion = "Descripcion 1",
                TipoEstado = new TipoEstadoDTO()
                {
                    nombre = "lwlfknwelkf",
                    etiqueta = new HashSet<EtiquetaDTO>()
                }
            });
            var ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA05"));
            var ListaEmpleado = new List<Empleado>()
            {
                ticket.Emisor,
                new Empleado() { correo ="prueba123@gmail.com"}
            };
            //Act
            var result = _notificacionDAO.EnviarNotificacion(ticket, TipoNotificacion.Pendiente, ListaEmpleado, _contextMock.Object);


            //Assert
            Assert.IsTrue(result.Result);
        }

        [TestMethod]
        public void TicketDefault()
        {
            //Arrange
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO
            {
                Titulo = "Pantilla1",
                Descripcion = "Descripcion 1",
                TipoEstado = new TipoEstadoDTO()
                {
                    nombre = "lwlfknwelkf",
                    etiqueta = new HashSet<EtiquetaDTO>()
                }
            });
            var ticket = _contextMock.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA05"));
            var ListaEmpleado = new List<Empleado>()
            {
                ticket.Emisor,
                new Empleado() { correo ="prueba123@gmail.com"}
            };
            //Act
            var result = _notificacionDAO.EnviarNotificacion(ticket, TipoNotificacion.Normal, ListaEmpleado, _contextMock.Object);


            //Assert
            Assert.IsTrue(result.Result);
        }*/

    }
}
