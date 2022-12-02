using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Flujo_AprobacionDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.Tipo_TicketDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEstado
{

    [TestClass]
    public class TestModificarEstado
    {
        Mock<IDataContext> context;
        private readonly EstadoService EstadoDAO;
        private IMapper mapper;



        public TestModificarEstado()
        {
            context = new Mock<IDataContext>();

            var myprofile = new List<Profile>
            {
                new Mappers()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myprofile));
            mapper = new Mapper(configuration);

            EstadoDAO = new EstadoService(context.Object, mapper);
            context.SetupDbContextData();
        }

        //Test camino feliz para hacer el modificar estado
        [TestMethod]
        public void CaminoFelizUpdateEstado()
        {
            //arrange
            EstadoDTOUpdate expected = new EstadoDTOUpdate()
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                nombre = "Aprobado D1",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.DbContext.SaveChanges());

            var result = EstadoDAO.ModificarEstado(expected);

            //assert
            Assert.AreEqual(result.nombre, "Aprobado D1");
            Assert.AreEqual(result.descripcion, "Descripcion D1");

        }
        //Test para la excepcion Exception para modificar estado  
        [TestMethod]
        public void EntrarEnExceptionControlEstadoTest()
        {
            //arrage
            EstadoDTOUpdate expected = new EstadoDTOUpdate()
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                nombre = "Aprobado",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.Estados).Throws(new Exception(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => EstadoDAO.ModificarEstado(expected));

        }

        //Test para la excepcion ExceptionsControl para modificar estado  
        [TestMethod]
        public void EntrarEnExceptionControlEstado2Test()
        {
            //arrage
            EstadoDTOUpdate expected = new EstadoDTOUpdate()
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                nombre = "Aprobado",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.Estados).Throws(new ExceptionsControl(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => EstadoDAO.ModificarEstado(expected));

        }
    }
}

