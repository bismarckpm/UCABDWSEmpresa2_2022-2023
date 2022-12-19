using AutoMapper;
using Moq;

using UnitTestServicesDeskUCABWS.DataSeed;
using ServicesDeskUCABWS.BussinesLogic.DAO.CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.DTO.CargoDTO;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestCargo
{
    [TestClass]
    public class TestCargo
    {
        Mock<IDataContext> context;
        private readonly CargoService CargoDao;
        private IMapper mapper;
        public TestCargo()
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
            CargoDao = new CargoService(context.Object, mapper);
            context.SetupDbContextData();
        }

        [TestMethod]
        public void CaminoFelizTestConsultarCargo()
        {

            var Id = new Guid("CCACD411-1B46-4117-AA84-73EA64DEAC87");

            var result = CargoDao.ConsultarCargosDepartamento(Id);

            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod]
        public void CaminoFelizDesHabilitarCargo()
        {
            //arrange
            var data = new CargoDTOUpdate
            {
                Id = new Guid("17A696EE-BDCC-418C-BF60-B59F7A764416"),

            };
            //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = CargoDao.DeshabilitarCargo(data.Id);

            Assert.AreEqual(data.GetType(), result.GetType());
        }

        //Test para la excepcion Exception para deshabilitar estado  
        [TestMethod]
        public void EntrarEnExceptionControlDesHabilitarCargoTest()
        {
            //arrage
            var data = new CargoDTOUpdate
            {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

            };

            //context.Setup(a => a.Estados).Throws(new Exception(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => CargoDao.DeshabilitarCargo(data.Id));

        }

        [TestMethod]
        public void CaminoFelizHabilitarCargo()
        {
            //arrange
            var data = new CargoDTOUpdate
            {
                Id = new Guid("17A696EE-BDCC-418C-BF60-B59F7A764416"),

            };
            //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = CargoDao.HabilitarCargo(data.Id);

            Assert.AreEqual(data.GetType(), result.GetType());
        }

        //Test para la excepcion Exception para deshabilitar estado  
        [TestMethod]
        public void EntrarEnExceptionControlHabilitarCargoTest()
        {
            //arrage
            var data = new CargoDTOUpdate
            {
                Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

            };

            //context.Setup(a => a.Estados).Throws(new Exception(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => CargoDao.HabilitarCargo(data.Id));

        }

        /// <summary>
        /// Update Caargo
        /// </summary>

        [TestMethod]
        public void CaminoFelizUpdateCargo()
        {
            //arrange
            CargoDTOUpdate expected = new CargoDTOUpdate()
            {
                Id = new Guid("17A696EE-BDCC-418C-BF60-B59F7A764416"),
                nombre_departamental = "Aprobado D1",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.DbContext.SaveChanges());

            var result = CargoDao.ModificarCargo(expected);

            //assert
            Assert.AreEqual(result.nombre_departamental, "Aprobado D1");
            Assert.AreEqual(result.descripcion, "Descripcion D1");

        }
        //Test para la excepcion Exception para modificar estado  
        [TestMethod]
        public void EntrarEnExceptionControlCargoTest()
        {
            //arrage
            CargoDTOUpdate expected = new CargoDTOUpdate()
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                nombre_departamental = "Aprobado",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.Estados).Throws(new Exception(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => CargoDao.ModificarCargo(expected));

        }

        //Test para la excepcion ExceptionsControl para modificar estado  
        [TestMethod]
        public void EntrarEnExceptionControlCargo2Test()
        {
            //arrage
            CargoDTOUpdate expected = new CargoDTOUpdate()
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA60210C"),
                nombre_departamental = "Aprobado",
                descripcion = "Descripcion D1",

            };

            context.Setup(a => a.Estados).Throws(new ExceptionsControl(""));

            //assert
            Assert.ThrowsException<ExceptionsControl>(() => CargoDao.ModificarCargo(expected));

        }
    }
}
