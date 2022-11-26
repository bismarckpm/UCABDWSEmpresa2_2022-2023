using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestVotos_Ticket
{
    [TestClass]
    public class testCambiarEstado
    {
        Mock<IDataContext> context;
        private readonly TicketService ticketDAO;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;

        public testCambiarEstado()
        {
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            notificacionService = new Mock<INotificacion>();
            context = new Mock<IDataContext>();
            ticketDAO = new TicketService(context.Object,plantillaNotificacionDAO.Object,notificacionService.Object);
            context.SetupDbContextData();
        }

        //Prueba Unitaria para cuando el Estado es Pendiente
        [TestMethod]
        public void CaminoFelizCambiarEstadoPendiente()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));

           
           List <Empleado> ListaEmpleado = new List<Empleado>() { 
            
                
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO { Titulo = "Pantilla1", Descripcion="Descripcion 1" });

            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.CambiarEstado(entrada, "Pendiente" , ListaEmpleado);

            //Assert
            Assert.AreEqual(result,true);

        }

        //Prueba Unitaria para cuando el Estado es Aprobado
        [TestMethod]
        public void CaminoFelizCambiarEstadoAprobado()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));


            List<Empleado> ListaEmpleado = new List<Empleado>() {


                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO { Titulo = "Pantilla1", Descripcion = "Descripcion 1" });

            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.CambiarEstado(entrada, "Aprobado", ListaEmpleado);

            //Assert
            Assert.AreEqual(result, true);

        }

        //Prueba Unitaria para cuando el Estado es Aprobado
        [TestMethod]
        public void CaminoFelizCambiarEstadoAprobadoException()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));


            List<Empleado> ListaEmpleado = new List<Empleado>() {


                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.CambiarEstado(entrada, "Aprobado", ListaEmpleado);

            //Assert
            Assert.AreEqual(result, true);

        }

        //Prueba Unitaria para cuando el Estado es Siendo Procesado
        [TestMethod]
        public void CaminoFelizCambiarEstadoProcesadoException()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));


            List<Empleado> ListaEmpleado = new List<Empleado>() {


                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.CambiarEstado(entrada, "Aprobado", ListaEmpleado);

            //Assert
            Assert.AreEqual(result, true);

        }
        //Prueba Unitaria para cuando el Estado es Pendiente
        [TestMethod]
        public void CaminoFelizCambiarEstadoPendienteException()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));


            List<Empleado> ListaEmpleado = new List<Empleado>() {


                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.CambiarEstado(entrada, "Pendiente", ListaEmpleado);

            //Assert
            Assert.AreEqual(result, false);

        }

    }
}
