using AutoMapper;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestFlujos
{
    [TestClass]
    public class TestFlujoParalelo
    {
        Mock<IDataContext> context;
        private readonly TicketDAO ticketDAO;
        private readonly Mock<IPlantillaNotificacion> plantillaNotificacionDAO;
        private readonly Mock<INotificacion> notificacionService;

        private readonly IMapper mapper;

        public TestFlujoParalelo()
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


        //Prueba Unitaria para flujo paralelo
        [TestMethod]
        public void CaminoFelizFlujoParaleloTest()
        {
            //arrange
            var Ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA03"));
            

            //context.Setup(x => x.Flujos_Aprobaciones).Returns(ListaFlujo.AsQueryable().BuildMockDbSet().Object); 
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO { Titulo = "Pantilla1", Descripcion = "Descripcion 1" });


            //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.FlujoAprobacionCreacionTicket(Ticket);

            //Assert
            Assert.AreEqual("Pendiente D1", Ticket.Estado.nombre);
            Assert.AreEqual(1, Ticket.Bitacora_Tickets.Count);
            Assert.AreEqual(1, context.Object.Bitacora_Tickets.Where(x => x.Ticket.Id == Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA03")).Count());
            Assert.AreEqual(4, context.Object.Votos_Tickets.Where(x => x.IdTicket == Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA03")).Count());
        }



        //Test para el servicio de un excepcion para flujo paralelo
        [TestMethod]
        public void FlujoParaleloExceptions()
        {
            //Arrage
            var Ticket = context.Object.Tickets.Find(Guid.Parse("7060BA23-7E03-4084-B496-527ABAA0AA03"));

            var Expected = new ApplicationResponse<string>()
            {
                Success = false,

            };

            //act
            context.Setup(x => x.Flujos_Aprobaciones).Throws(new ExceptionsControl(""));

            ticketDAO.FlujoAprobacionCreacionTicket(Ticket);

            //assert
            //Assert.IsTrue(result != "Exitoso");

        }

    }
}






/*  public string FlujoParalelo(Ticket ticket)
        {
            string result = null;
            try
            {

                var tipoCargos = _dataContext.Flujos_Aprobaciones
                    .Include(x => x.Tipo_Cargo)
                    .ThenInclude(x => x.Cargos_Asociados)
                    .Where(x => x.IdTicket == ticket.Tipo_Ticket.Id);

                var Cargos = new List<Cargo>();
                foreach (var tc in tipoCargos)
                {
                    Cargos.Add(tc.Tipo_Cargo.Cargos_Asociados.ToList()
                        .Where(x => x.Departamento.id == ticket.Emisor.Cargo.Departamento.id).First());
                }

                var ListaEmpleado = new List<Empleado>();
                foreach (var c in Cargos)
                {
                    ListaEmpleado.AddRange(_dataContext.Empleados.Where(x => x.Cargo.Id == c.Id));
                }

                var ListaVotos = ListaEmpleado.Select(x => new Votos_Ticket
                {
                    IdTicket = ticket.Id,
                    Ticket = ticket,
                    IdUsuario = x.Id,
                    Empleado = x,
                    voto = "Pendiente"
                });

                _dataContext.Votos_Tickets.AddRange(ListaVotos);

                CambiarEstado(ticket,"Pendiente", ListaEmpleado);

                _dataContext.DbContext.SaveChanges();

                return result;
            }
            catch (ExceptionsControl ex)
            {
                result = ex.Message;
                return result;
            }
        }
*/