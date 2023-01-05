using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestTipo_Ticket
{
    [TestClass]
    public class TestUpdateTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private readonly IMapper mapper;


        public TestUpdateTipoTicket()
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
        public void CaminoFelizUpdateTicket()
        {
            //arrange
            Tipo_TicketDTOUpdate expected = new Tipo_TicketDTOUpdate()
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
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            //act
            var result = TipoticketDAO.ActualizarTipo_Ticket(expected);

            //assert

            Assert.AreEqual(result.Data.Departamento.Count(), 2);
            Assert.AreEqual(result.Data.Flujo_Aprobacion.Count(), 2);

            Assert.AreEqual(result.Data.nombre, "Mantenimiento");
            Assert.AreEqual(result.Data.descripcion, "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento");
            Assert.AreEqual(result.Data.tipo, "Modelo_Jerarquico");
            Assert.IsNull(result.Data.Maximo_Rechazado);
            Assert.IsNull(result.Data.Minimo_Aprobado);
        }

        [TestMethod]
        public void CaminoFelizUpdateTicketSinDepartamentos()
        {
            //arrange
            Tipo_TicketDTOUpdate expected = new Tipo_TicketDTOUpdate()
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
                
            };
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            //act
            var result = TipoticketDAO.ActualizarTipo_Ticket(expected);

            //assert

            Assert.AreEqual(result.Data.Departamento.Count(), 0);
            Assert.AreEqual(result.Data.Flujo_Aprobacion.Count(), 2);

            Assert.AreEqual(result.Data.nombre, "Mantenimiento");
            Assert.AreEqual(result.Data.descripcion, "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento");
            Assert.AreEqual(result.Data.tipo, "Modelo_Jerarquico");
            Assert.IsNull(result.Data.Maximo_Rechazado);
            Assert.IsNull(result.Data.Minimo_Aprobado);
        }

        [TestMethod]
        public void CaminoFelizUpdateTicketModeloNoAprobacion()
        {
            //arrange
            Tipo_TicketDTOUpdate expected = new Tipo_TicketDTOUpdate()
            {
                Id = "36B2054E-BC66-4EA7-A5CC-7BA9137BC20E",
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_No_Aprobacion",
                
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            //act
            var result = TipoticketDAO.ActualizarTipo_Ticket(expected);

            //assert

            Assert.AreEqual(result.Data.Departamento.Count(), 2);
            Assert.AreEqual(result.Data.Flujo_Aprobacion.Count(), 0);

            Assert.AreEqual(result.Data.nombre, "Mantenimiento");
            Assert.AreEqual(result.Data.descripcion, "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento");
            Assert.AreEqual(result.Data.tipo, "Modelo_No_Aprobacion");
            Assert.IsNull(result.Data.Maximo_Rechazado);
            Assert.IsNull(result.Data.Minimo_Aprobado);
        }

        [TestMethod]
        public void EntrarExceptionControl()
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
            var result = TipoticketDAO.ActualizarTipo_Ticket(entrada);


            Assert.AreEqual(expectedException.Mensaje, result.Message);
            Assert.AreEqual(false, result.Success);
        }

    }

}
