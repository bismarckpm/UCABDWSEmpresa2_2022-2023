using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestEtiqueta
{
    [TestClass]
    public class EtiquetaServiceTest
    {
        private readonly EtiquetaService _EtiquetaService;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;

        public EtiquetaServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaTipoEstadoMapper(),
                new EtiquetaMapper()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _EtiquetaService = new EtiquetaService(_contextMock.Object, _mapper);
            _contextMock.SetUpContextData();
        }

        //*
        //PRUEBAS UNITARIAS PARA CONSULTAR TODAS LAS ETIQUETAS
        //*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de las etiquetas")]
        public void ConsultaEtiquetaServiceTest()
        {
            var result = _EtiquetaService.ConsultaEtiquetas();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod(displayName: "Prueba Unitaria cuando la consulta de las etiquetas retorna vacio o null")]      //Esta prueba está bien? 
        //[ExpectedException(typeof(ExceptionsControl))]
        public void ConsultarEtiquetasRetornaVaciaServiceTest()
        {
            _contextMock.SetUpContextDataEtiquetaVacio();
            //_contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new ExceptionsControl(""));
            Assert.ThrowsException<ExceptionsControl>(() => _EtiquetaService.ConsultaEtiquetas());
        }

        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en la consulta de etiquetas")]        //Esto está bueno?
        public void ConsultarEtiquetaRetornaExceptionServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.Etiquetas).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _EtiquetaService.ConsultaEtiquetas());
        }

        //*
        //PRUEBAS UNITARIAS PARA CONSULTAR ETIQUETAS NOTIFICACIÓN POR ID
        //*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de una ETIQUETA por id exitosa")]
        public void ConsultaEtiquetaIDServiceTest()
        {
            //arrange
            var id = Guid.Parse("c76a9916-4cbb-434c-b88e-1fc8152eca8c");

            //act
            var result = _EtiquetaService.ConsultarEtiquetaGUID(id);

            //assert
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod(displayName: "Prueba Unitaria de la excepcion consulta de una ETIQUETA por id que no existe")]
        public void ConsultaEtiquetaIDExceptionServiceTest()
        {
            _contextMock.Setup(p => p.Etiquetas).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _EtiquetaService.ConsultarEtiquetaGUID(It.IsAny<Guid>()));
        }

    }
}
