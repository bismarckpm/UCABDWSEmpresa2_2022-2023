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
            var Ticket = new Ticket()
            {
                Id = Guid.Parse("132A191C-95AE-4538-8E78-C5EDD3092552"),
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
                    Id = Guid.Parse("F863DBA2-5093-4E89-917A-03B5F585B3E7"),
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
                        Departamento = new Departamento()
                        {
                            id = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87"),
                            nombre = "nombreDepartamento",
                            grupo = new Grupo()
                            {
                                nombre = "nombreGrupo"
                            }
                        },
                    }

                },
                
        };
           var ListaFlujo = new List<Flujo_Aprobacion>
            { 
                new Flujo_Aprobacion { 
                    IdTicket = new Guid("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E"),
                    Cargo=new Cargo {
                            nombre_departamental= "Cargos 1",
                            descripcion= "Descripcion 1",

                            Departamento = new Departamento {
                                id = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87"),
                                 nombre = "Cargos 1",
                                descripcion= "Descripcion 1"
                            }
                        }
                    /*Cargo = new Cargo("Nombre 1", "Descripcion 1"){ 
                    Cargos_Asociados= new List<Cargo> {
                       new Cargo {
                            nombre_departamental= "Cargos 1",
                            descripcion= "Descripcion 1",

                            Departamento = new Departamento {
                                id = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87"),
                                 nombre = "Cargos 1",
                                descripcion= "Descripcion 1"
                            }
                        }
                    }
                  }*/
                } 
            };

            //context.Setup(x => x.Flujos_Aprobaciones).Returns(ListaFlujo.AsQueryable().BuildMockDbSet().Object); 
            plantillaNotificacionDAO.Setup(x => x.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>())).Returns(new PlantillaNotificacionDTO { Titulo = "Pantilla1", Descripcion = "Descripcion 1" });


            //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = ticketDAO.FlujoParalelo(Ticket);

            //Assert

        }

   

    //Test para el servicio de un excepcion para flujo paralelo
    [TestMethod]
    public void CaminoFelizFlujoParaleloExceptions()
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
        context.Setup(x => x.Flujos_Aprobaciones).Throws(new ExceptionsControl(""));

        var result = ticketDAO.FlujoParalelo(Ticket);

        //assert
        Assert.IsNotNull(result);

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