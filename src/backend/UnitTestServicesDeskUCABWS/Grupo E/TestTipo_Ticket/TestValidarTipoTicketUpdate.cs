using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_Ticket
{
    [TestClass]
    public class TestValidarTipoTicketUpdate
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private readonly IMapper mapper;

        public TestValidarTipoTicketUpdate()
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
            context = new Mock<IDataContext>();
            TipoticketDAO = new Tipo_TicketService(context.Object,mapper);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void NoSeEncuentraTipoTicket()
        {
            //arrange
            Tipo_TicketDTOUpdate entrada = new Tipo_TicketDTOUpdate()
            {
                Id = "5992E4A2-4737-42FB-88E2-FBC37EF26751",
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=1,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.TIPO_TICKET_DESC);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket_Update(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            //assert
            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);
        }

        [TestMethod]
        public void NoSePermiteCambiarTipoDeAprobacionATicketsConAprobacionPendiente()
        {
            //arrange
            Tipo_TicketDTOUpdate entrada = new Tipo_TicketDTOUpdate()
            {
                Id = "F863DBA2-5093-4E89-917A-03B5F585B3E7",
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=1,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.ERROR_UPDATE_MODELO_APROBACION);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket_Update(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            //assert
            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);
        }

        [TestMethod]
        public void CaminoFelizValidacionUpdate()
        {
            //arrange
            Tipo_TicketDTOUpdate entrada = new Tipo_TicketDTOUpdate()
            {
                Id = "36B2054E-BC66-4EA7-A5CC-7BA9137BC20E",
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=1,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };





            //act

            TipoticketDAO.ActualizarTipo_Ticket(entrada);

            //assert


        }

        [TestMethod]
        public void ErrorFormatoDeIDs()
        {

            //arrange
            Tipo_TicketDTOUpdate entrada = new Tipo_TicketDTOUpdate()
            {
                Id = "36B2054E-BC66-4EA7-A5CC-dsd",
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=1,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.FORMATO_ID_TICKET, new FormatException());
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket_Update(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);

        }

    }
}
