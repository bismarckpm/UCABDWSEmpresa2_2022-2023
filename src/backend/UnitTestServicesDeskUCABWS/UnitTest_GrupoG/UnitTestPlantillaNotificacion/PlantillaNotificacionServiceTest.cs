using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestPlantillaNotificacion
{
    [TestClass]
    public class PlantillaNotificacionServiceTest
    {
        private readonly PlantillaNotificacionService _plantillaService;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;

        public PlantillaNotificacionServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            var myProfile = new List<Profile>
            {
                new PlantillaNotificacionMapper(),
                new TipoEstadoMapper(),
                new EtiquetaTipoEstadoMapper(),
                new EtiquetaMapper()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _plantillaService = new PlantillaNotificacionService(_contextMock.Object, _mapper);
            _contextMock.SetUpContextData();
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR TODAS LAS PLANTILLAS NOTIFICACIONES
//*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de las plantillas exitosa")]                       //Se le quitó la programación asíncrona a todo lo que respecta la consulta plantilla
        public void ConsultaPlantillasServiceTest()
        {
            var result = _plantillaService.ConsultaPlantillas();
            Assert.IsTrue(result.Count() > 0);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando la consulta de las plantillas retorna vacio o null")]      //Esta prueba está bien? 
        //[ExpectedException(typeof(ExceptionsControl))]
        public void ConsultarPlantillasRetornaVaciaServiceTest()
        {
            _contextMock.SetUpContextDataVacio();
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new ExceptionsControl(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultaPlantillas());
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en la consulta")]        //Esto está bueno?
        public void ConsultarPlantillasRetornaExceptionServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultaPlantillas());
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR PLANTILLA NOTIFICACIÓN POR ID
//*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de una plantilla por id exitosa")]        
        public void ConsultaPlantillaIDServiceTest()
        {
            //arrange
            var id = Guid.Parse("99f401c9-12aa-46bf-82a2-05ff65bb2c87");

            //act
            var result = _plantillaService.ConsultarPlantillaGUID(id);

            //assert
            Assert.AreEqual(id, result.Id);
        }


        [TestMethod(displayName: "Prueba Unitaria de la excepcion consulta de una plantilla por id que no existe")]
        public void ConsultaPlantillaIDExceptionServiceTest()
        {
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultarPlantillaGUID(It.IsAny<Guid>()));
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR PLANTILLA NOTIFICACIÓN POR TITULO
//*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de una plantilla por titulo exitosa")]
        public void ConsultaPlantillaTituloServiceTest()
        {
            //arrange
            var titulo = "Plantilla Rechazado";

            //act
            var result = _plantillaService.ConsultarPlantillaTitulo(titulo);

            //assert
            Assert.AreEqual(titulo, result.Titulo);
        }


        [TestMethod(displayName: "Prueba Unitaria de la consulta de una plantilla por titulo que no titulo")]
        public void ConsultaPlantillaTituloExceptionServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultarPlantillaTitulo(It.IsAny<String>()));
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR PLANTILLA NOTIFICACIÓN POR TIPO ESTADO TITULO
//*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de una plantilla por tipo estado titulo exitosa")]
        public void ConsultaPlantillaTipoEstadoTituloServiceTest()
        {
            //arrange
            var tituloTipoEstado = "Aprobado";

            //act
            var result = _plantillaService.ConsultarPlantillaTipoEstadoTitulo(tituloTipoEstado);

            //assert
            Assert.AreEqual(tituloTipoEstado, result.TipoEstado.nombre);
        }


        [TestMethod(displayName: "Prueba Unitaria para la consulta de una plantilla por tipo estado título que no existe")]
        public void ConsultaPlantillaTipoEstadoTituloExceptionServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultarPlantillaTipoEstadoTitulo(It.IsAny<String>()));
        }


//*
//PRUEBAS UNITARIAS PARA CONSULTAR PLANTILLA NOTIFICACIÓN POR TIPO ESTADO ID
//*

        [TestMethod(displayName: "Prueba Unitaria para la consulta de una plantilla por tipo estado ID exitosa")]
        public void ConsultaPlantillaTipoEstadoIDServiceTest()
        {
            //arrange
            var idTipoEstado = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //act
            var result = _plantillaService.ConsultarPlantillaTipoEstadoID(idTipoEstado);

            //assert
            Assert.AreEqual(idTipoEstado, result.TipoEstado.Id);
        }


        [TestMethod(displayName: "Prueba Unitaria para la consulta de una plantilla por tipo estado ID que no existe")]
        public void ConsultaPlantillaTipoEstadoIDIncompatibleServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new InvalidOperationException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>()));
        }


        [TestMethod(displayName: "Prueba Unitaria para la consulta de una plantilla por tipo estado ID que y ocurre cualquier error imprevisto")]
        public void ConsultaPlantillaTipoEstadoIDExceptionServiceTest()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.ConsultarPlantillaTipoEstadoID(It.IsAny<Guid>()));
        }


//*
//PRUEBAS UNITARIAS PARA REGISTRO DE PLANTILLA NOTIFICACION
//*

        [TestMethod(displayName: "Prueba Unitaria cuando el registro de la plantilla notificación sea exitoso")]
        public void AgregarPlantillaServiceTest()
        {
            //arrange
            var plantilla = new PlantillaNotificacionDTOCreate
            {
                Titulo = "Plantilla Aprobado",
                Descripcion = "Hola @Usuario su @Ticket fue @Estado",
                TipoEstadoId = Guid.Parse("99f401c9-12aa-46bf-82a2-05ff65bb2c86"),
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());

            //act
            var result = _plantillaService.RegistroPlantilla(plantilla);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando el registro de la plantilla notificación falla por campos vacios")]
        public void ExcepcionAgregarPlantillaCamposVacios()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new DbUpdateException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en el registro")]
        public void ExcepcionAgregarPlantilla()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
        }


//*
//PRUEBAS UNITARIAS PARA ACTUALIZAR DE PLANTILLA NOTIFICACION
//*

        [TestMethod(displayName: "Prueba Unitaria cuando la actualización de la plantilla notificación sea exitoso")]
        public void ActualizarPlantillaServiceTest()
        {
            //arrange
            var idUpdate = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var plantillaUpdate = new PlantillaNotificacionDTOCreate()
            {
                Titulo = "Plantilla Aprobado",
                Descripcion = "Hola @Usuario su @Ticket",
                TipoEstadoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
            };
            //_contextMock.Setup(set => set.DbContext.SaveChanges());

            //act
            var result = _plantillaService.ActualizarPlantilla(plantillaUpdate,idUpdate);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando al actualizar el id del tipo estado ya está asignado a otra plantilla o hay campos vacios")]
        public void ActualizarPlantillaIdTipoEstadoIncompatibleCamposVacios()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new DbUpdateException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en al actualizar")]
        public void ExcepcionActualizarPlantillaNotificacion()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
        }

//*
//PRUEBAS UNITARIAS PARA ELIMINAR PLANTILLA NOTIFICACION
//*

        [TestMethod(displayName: "Prueba Unitaria cuando la eliminación de la plantilla notificación sea exitoso")]
        public void EliminarPlantillaServiceTest()
        {
            //arrange
            var data = new PlantillaNotificacion
            {
                Id = new Guid("99f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                Titulo = "Plantilla Rechazado",
                Descripcion = "Hola @Usuario su @Ticket",
                TipoEstadoId = null,
                TipoEstado = null
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());

            //act
            var result = _plantillaService.EliminarPlantilla(data.Id);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando al eliminar no encuentra la plantilla notificación de acuerdo al id")]
        public void ExcepcionEliminarlantillaIdIncompatible()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new ArgumentNullException(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.EliminarPlantilla(It.IsAny<Guid>()));
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en la eliminación")]
        public void ExcepcionEliminarPlantillaNotificacion()
        {
            //arrange
            _contextMock.Setup(p => p.PlantillasNotificaciones).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.EliminarPlantilla(It.IsAny<Guid>()));
        }
    }
}
