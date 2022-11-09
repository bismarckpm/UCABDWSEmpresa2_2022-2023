using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.CTipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Recursos;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_GrupoE.DataSeed;

namespace UnitTest_GrupoE.TestTipo_Ticket
{
    [TestClass]
    public class TestAgregarTipoTicket
    {
        Mock<IDataContext> context;
        private readonly Tipo_TicketDAO TipoticketDAO;



        public TestAgregarTipoTicket()
        {
            context = new Mock<IDataContext>();
            TipoticketDAO = new Tipo_TicketDAO(context.Object);
            context.SetupDbContextData();
        }



        [TestMethod]
        public void RegistroTipoTicketJerarquicoExitoso()
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
            };

            Tipo_Ticket expected = new Tipo_Ticket()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Jerarquico",
                fecha_creacion = DateTime.UtcNow,
                fecha_ult_edic = DateTime.UtcNow,
                fecha_elim = null,
                Flujo_Aprobacion = new List<Flujo_Aprobacion>()
                {
                    new Flujo_Aprobacion()
                    {
                        OrdenAprobacion = 2,
                        Minimo_aprobado_nivel = 1,
                        Maximo_Rechazado_nivel = 1,
                        IdTipo_cargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                        IdTicket = Guid.Parse("00000000-0000-0000-0000-000000000000")
                    },
                    new Flujo_Aprobacion()
                    {
                        OrdenAprobacion = 1,
                        Minimo_aprobado_nivel = 1,
                        Maximo_Rechazado_nivel = 1,
                        IdTipo_cargo = Guid.Parse("24259113-437b-417f-9159-a8e27c34a871"),
                        IdTicket = Guid.Parse("00000000-0000-0000-0000-000000000000")
                    }
                },
                Departamento = new List<Departamento>()
                {
                    new Departamento()
                    {
                        Id= Guid.Parse("ccacd411-1b46-4117-aa84-73ea64deac87"),
                        nombre= "Almacen",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    },
                    new Departamento()
                    {
                        Id= Guid.Parse("19c117f4-9c2a-49b1-a633-969686e0b57e"),
                        nombre= "Almacen de Electronica",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    }
                },
                Minimo_Aprobado = null,
                Maximo_Rechazado = null
            };

            //act
            var result = TipoticketDAO.RegistroTipo_Ticket(entrada);

            //assert

            Assert.AreEqual(result.Data.nombre, expected.nombre);
            Assert.IsTrue(result.Data.Departamento.Count == expected.Departamento.Count);
            Assert.IsTrue(result.Data.Flujo_Aprobacion.Count == expected.Flujo_Aprobacion.Count);
        }

        [TestMethod]
        public void RegistroTipoTicketParaleloExitoso()
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

            };

            Tipo_Ticket expected = new Tipo_Ticket()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_Paralelo",
                fecha_creacion = DateTime.UtcNow,
                fecha_ult_edic = DateTime.UtcNow,
                fecha_elim = null,
                Flujo_Aprobacion = new List<Flujo_Aprobacion>()
                {
                    new Flujo_Aprobacion()
                    {
                        OrdenAprobacion = 2,
                        Minimo_aprobado_nivel = 1,
                        Maximo_Rechazado_nivel = 1,
                        IdTipo_cargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"),
                        IdTicket = Guid.Parse("00000000-0000-0000-0000-000000000000")
                    },
                    new Flujo_Aprobacion()
                    {
                        OrdenAprobacion = 1,
                        Minimo_aprobado_nivel = 1,
                        Maximo_Rechazado_nivel = 1,
                        IdTipo_cargo = Guid.Parse("24259113-437b-417f-9159-a8e27c34a871"),
                        IdTicket = Guid.Parse("00000000-0000-0000-0000-000000000000")
                    }
                },
                Departamento = new List<Departamento>()
                {
                    new Departamento()
                    {
                        Id= Guid.Parse("ccacd411-1b46-4117-aa84-73ea64deac87"),
                        nombre= "Almacen",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    },
                    new Departamento()
                    {
                        Id= Guid.Parse("19c117f4-9c2a-49b1-a633-969686e0b57e"),
                        nombre= "Almacen de Electronica",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    }
                },
                Minimo_Aprobado = 1,
                Maximo_Rechazado = 1
            };

            //act
            var result = TipoticketDAO.RegistroTipo_Ticket(entrada);

            //assert
            Assert.AreEqual(result.Data.nombre, expected.nombre);
            Assert.IsTrue(result.Data.Departamento.Count == expected.Departamento.Count);
            Assert.IsTrue(result.Data.Flujo_Aprobacion.Count == expected.Flujo_Aprobacion.Count);
        }

        [TestMethod]
        public void RegistroTipoTicketNOAprobacionExitoso()
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
                }
            };

            Tipo_Ticket expected = new Tipo_Ticket()
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                nombre = "Mantenimiento",
                descripcion = "Ticket para manejar el Mantenimiento de un recurso dentro de un departamento",
                tipo = "Modelo_No_Aprobacion",
                fecha_creacion = DateTime.UtcNow,
                fecha_ult_edic = DateTime.UtcNow,
                fecha_elim = null,
                Departamento = new List<Departamento>()
                {
                    new Departamento()
                    {
                        Id= Guid.Parse("ccacd411-1b46-4117-aa84-73ea64deac87"),
                        nombre= "Almacen",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    },
                    new Departamento()
                    {
                        Id= Guid.Parse("19c117f4-9c2a-49b1-a633-969686e0b57e"),
                        nombre= "Almacen de Electronica",
                        descripcion= "Lugar donde se guardan todos los recursos de la empresa",
                        fecha_creacion= DateTime.UtcNow,
                        fecha_ultima_edicion= DateTime.UtcNow,
                        fecha_eliminacion= null,
                    }
                },
            };

            //act
            var result = TipoticketDAO.RegistroTipo_Ticket(entrada);

            //assert
            Assert.AreEqual(result.Data.nombre, expected.nombre);
            Assert.IsTrue(result.Data.Departamento.Count == expected.Departamento.Count);
        }
        [TestMethod]
        public void RegistroTipoTicketExcepcion()
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

            };

            var Expected = new ApplicationResponse<Tipo_Ticket>()
            {
                Success = false,
                Exception = ErroresTipo_Tickets.TIPO_NO_VALIDO
            };

            //act
            var result=TipoticketDAO.RegistroTipo_Ticket(entrada);


            //assert
            Assert.AreEqual(Expected.Exception, result.Exception);
            Assert.AreEqual(Expected.Success, result.Success);
        }

        


    }
}
