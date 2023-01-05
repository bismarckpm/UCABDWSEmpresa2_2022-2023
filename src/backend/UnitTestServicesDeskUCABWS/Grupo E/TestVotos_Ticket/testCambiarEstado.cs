using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestVotos_Ticket
{
    [TestClass]
    public class testCambiarEstado
    {
        Mock<IDataContext> context;
        private readonly TicketDAO ticketDAO;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;
        private readonly IMapper mapper;

        public testCambiarEstado()
        {
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaMapper(),
                new EtiquetaTipoEstadoMapper(),
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            mapper = new Mapper(configuration);
            plantillaNotificacionDAO = new Mock<IPlantillaNotificacion>();
            notificacionService = new Mock<INotificacion>();
            context = new Mock<IDataContext>();
            ticketDAO = new TicketDAO(context.Object,plantillaNotificacionDAO.Object,notificacionService.Object,mapper);
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

            var result = entrada.CambiarEstado(entrada, "Pendiente", context.Object);

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

            var result = entrada.CambiarEstado(entrada, "Aprobado",context.Object);

            //Assert
            Assert.AreEqual(result, true);

        }

        //Prueba Unitaria para cuando el Estado es Aprobado
        [TestMethod]
        public void CambiarEstadoAprobadoException()
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

            var result = entrada.CambiarEstado(entrada, "Aprobado", context.Object);

            //Assert
            Assert.AreEqual(result, true);

        }

        //Prueba Unitaria para cuando el Estado es Siendo Procesado
        [TestMethod]
        public void CambiarEstadoProcesadoException()
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

            var result = entrada.CambiarEstado(entrada, "Aprobado", context.Object);
            //Assert
            Assert.AreEqual(result, true);

        }
        //Prueba Unitaria para cuando el Estado es Pendiente
        [TestMethod]
        public void CambiarEstadoPendienteException()
        {
            //arrange
            var entrada = context.Object.Tickets.Find(Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"));


            List<Empleado> ListaEmpleado = new List<Empleado>() {


                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria"),
                new Empleado(123456, "Jose", "Vargas", "Rojas", "20/12/1999", 'M', "jmvargas@gmail.com", "1234", "Maria")

            };

            //Act
            context.Setup(x => x.Tickets).Throws(new ExceptionsControl("", new Exception()));

            context.Setup(a => a.DbContext.SaveChanges());

            var result = entrada.CambiarEstado(entrada, "Pendiente", context.Object);
            //Assert
            Assert.AreEqual(result, false);

        }

    }
}
