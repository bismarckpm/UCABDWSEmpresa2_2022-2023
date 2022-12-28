using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.TestTipo_Ticket
{
    [TestClass]
    public class TestValidarTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketService TipoticketDAO;
        private IMapper mapper;
        public TestValidarTipoTicket()
        {
            context = new Mock<IDataContext>();
            TipoticketDAO = new Tipo_TicketService(context.Object,mapper);
            context.SetupDbContextData();
        }


        [TestMethod]
        public void ValidaciondeDatosCorrecta()
        {

            //arrange
            Tipo_TicketDTOCreate expected = new Tipo_TicketDTOCreate()
            {
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
            TipoticketDAO.ValidarDatosEntradaTipo_Ticket(expected);

            //assert

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void ValidaciondeDatosErrorTipoAprobacion()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Hola",
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.TIPO_NO_VALIDO);
            ExceptionsControl actualException = null;
            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);
        }

        [TestMethod]
        public void ValidaciondeDatosErrorNombre()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "aknsklcnskcndeskcnwecknwiowmiodwjiodjwoidmodijdioweniowemoiedoiedoiewjdoeiwjweoifjoeiwjweoifjoewifjoweifjweijewoidjwdewkldjweomoimferfjhfuierhfuirehfureihferijfeorifjeroifjeroifjoreifjoierfjoeirfjoreifjoriefjo",
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.NOMBRE_FUERA_DE_RANGO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);
        }

        [TestMethod]
        public void ValidaciondeDatosDescripcion()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Tic",
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.DESCRIPCION_FUERA_DE_RANGO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }


        [TestMethod]
        public void ValidaciondeDatosDepartamentoNoValido()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticcsndmdl",
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
                    "19C117F4-9C2A-49B1-A633-989686E0B57E"
                }
            };
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.DEPARTAMENTO_NO_VALIDO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }


        /*Arrange de prueba
         Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdTipoCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdTipoCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1,
            };*/
        [TestMethod]
        public void ValidaciondeDatosCargoVacioenModeloParaleloOJerarquico()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",

                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1,
            };
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.CARGO_VACIO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void ValidaciondeDatosCargoInvalidoModelo_ParaleloOJerarquico()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B1002C",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1,
            };
            //TipoticketDAO.Setup(x => x.ValidarDatosEntradaTipo_Ticket(ticketDTO));

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.CARGO_NO_VALIDO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void ValidaciondeMODELO_PARALELO_NO_VALIDO()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = null,
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NO_VALIDO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }
        [TestMethod]
        public void NoDejaIngresarValoresenOrdenaprobacionEnModeloParalelo()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="24259113-437B-417F-9159-A8E27C34A871",
                        OrdenAprobacion=null,
                        Minimo_aprobado_nivel=null,
                        Maximo_Rechazado_nivel=null
                    }
                },
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1,
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.MODELO_PARALELO_NULL);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        /*arrange ModeloJerarquico
         Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdTipoCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=1
                    },
                    new FlujoAprobacionDTOCreate()
                    {
                        IdTipoCargo="24259113-437B-417F-9159-A8E27C34A871",
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
            };*/

        [TestMethod]
        public void NoPermiteValoresNoNullEnOrdenMinimoMaximoModeloJerarquico()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=2,
                        Minimo_aprobado_nivel=1,
                        Maximo_Rechazado_nivel=null
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.MODELO_JERARQUICO_NULL);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void LosValoresOrdenAprobacionNoSiguenUnaSecuenciaModeloJerarquico()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=4,
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.ERROR_SEC_ORDEN_APROB);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void LosValoresMinimoMaximoDebenSerNullModeloNoAprobacion()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_No_Aprobacion",
                Departamento = new List<string>
                {
                    "CCACD411-1B46-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1,
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_NO_VALIDO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void LosValoresCargosDebenSerNullModeloNoAprobacion()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_No_Aprobacion",
                Flujo_Aprobacion = new List<FlujoAprobacionDTOCreate> {
                    new FlujoAprobacionDTOCreate()
                    {
                        IdCargo="DDC1A0D0-FA70-48E1-9ACE-747057B0002C",
                        OrdenAprobacion=4,
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

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.MODELO_NO_APROBACION_CARGO);
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.AreEqual(expectedException.Excepcion, actualException.Excepcion);

        }

        [TestMethod]
        public void ErrorFormatoDeIDs()
        {

            //arrange
            Tipo_TicketDTOCreate entrada = new Tipo_TicketDTOCreate()
            {
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_No_Aprobacion",
                Departamento = new List<string>
                {
                    "CCACD411-1B6-4117-AA84-73EA64DEAC87",
                    "19C117F4-9C2A-49B1-A633-969686E0B57E"
                }
            };

            ExceptionsControl expectedException = new ExceptionsControl(ErroresTipo_Tickets.FORMATO_NO_VALIDO, new FormatException());
            ExceptionsControl actualException = null;

            //act
            try
            {
                TipoticketDAO.ValidarDatosEntradaTipo_Ticket(entrada);
            }
            catch (ExceptionsControl ex)
            {
                actualException = ex;
            }

            Assert.AreEqual(expectedException.Mensaje, actualException.Mensaje);
            Assert.IsTrue(typeof(FormatException) == actualException.Excepcion.GetType());

        }
    }

}
