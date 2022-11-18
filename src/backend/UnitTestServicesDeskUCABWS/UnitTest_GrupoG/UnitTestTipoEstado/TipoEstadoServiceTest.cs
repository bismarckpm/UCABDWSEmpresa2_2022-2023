using AutoMapper;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.Data;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using Microsoft.EntityFrameworkCore;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestTipoEstado
{
    [TestClass]
    public class TipoEstadoServiceTest
    {
        private readonly TipoEstadoService _TipoEstadoService;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;

        public TipoEstadoServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            var myProfile = new List<Profile>
            {
                new TipoEstadoMapper(),
                new EtiquetaMapper(),
                new EtiquetaTipoEstadoMapper()
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _TipoEstadoService = new TipoEstadoService(_contextMock.Object, _mapper);
            _contextMock.SetUpContextData();
        }

        //*
        //PRUEBAS UNITARIAS PARA CONSULTAR TODOS LOS TIPOS DE ESTADO
        //*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de los Tipos de estado exitosa")]                       //Se le quitó la programación asíncrona a todo lo que respecta la consulta plantilla
        public void ConsultaTipoEstadoServiceTest()
        {
            var result = _TipoEstadoService.ConsultaTipoEstados();
            Assert.IsTrue(result.Count() > 0);
        }

        [TestMethod(displayName: "Prueba Unitaria cuando la consulta de los tipos de estados retorna vacio o null")]      //Esta prueba está bien? 
        //[ExpectedException(typeof(ExceptionsControl))]
        public void ConsultarTipoEstadosRetornaVaciaServiceTest()
        {
            _contextMock.SetUpContextDataTipoEstadoVacio();
            //arrange
            var expected = new ExceptionsControl("No existen Tipos de estados registrados", new ExceptionsControl());
            var result = new ExceptionsControl();

            //act
            try
            {
                _TipoEstadoService.ConsultaTipoEstados();
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en la consulta")]        //Esto está bueno?
        public void ConsultarTipoEstadosRetornaExceptionServiceTest()
        {
            //arrange
            var expected = new ExceptionsControl("Hubo un problema en la consulta", new Exception());
            var result = new ExceptionsControl();
            _contextMock.Setup(p => p.Tipos_Estados).Throws(new Exception());

            //act
            try
            {
                _TipoEstadoService.ConsultaTipoEstados();
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA CONSULTAR TIPO ESTADO POR ID
        //*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de un tipo estado por id exitosa")]
        public void ConsultaTipoEstadoIDServiceTest()
        {
            //arrange
            var id = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");

            //act
            var result = _TipoEstadoService.ConsultarTipoEstadoGUID(id);

            //assert
            Assert.AreEqual(id, result.Id);
        }


        [TestMethod(displayName: "Prueba Unitaria de la excepcion consulta de una tipo estado por id que no existe")]
        public void ConsultaTipoEstadoIDExceptionServiceTest()
        {
            //arrange
            var id = Guid.Parse("99f401c9-12aa-46bf-82a2-05ff65bb2c88");
            var expected = new ExceptionsControl("No existe el tipo estado con ese ID", new Exception());
            var result = new ExceptionsControl();
            _contextMock.Setup(p => p.Tipos_Estados).Throws(new Exception());

            //act
            try
            {
                _TipoEstadoService.ConsultarTipoEstadoGUID(id);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA CONSULTAR TIPO ESTADO POR TITULO
        //*

        [TestMethod(displayName: "Prueba Unitaria de la consulta de un tipo estado por titulo exitosa")]
        public void ConsultaTipoEstadoTituloServiceTest()
        {
            //arrange
            var tituloTipoEstado = "Aprobado";

            //act
            var result = _TipoEstadoService.ConsultarTipoEstadoTitulo(tituloTipoEstado);

            //assert
            Assert.AreEqual(tituloTipoEstado, result.nombre);
        }


        [TestMethod(displayName: "Prueba Unitaria para la consulta de un tipo estado por titulo que no existe")]
        public void ConsultaTipoEstadoTituloExceptionServiceTest()
        {
            //arrange
            var titulo = "Plantilla";
            var expected = new ExceptionsControl("No existe la tipo estado con ese título", new Exception());
            var result = new ExceptionsControl();
            _contextMock.Setup(p => p.Tipos_Estados).Throws(new Exception());

            //act
            try
            {
                _TipoEstadoService.ConsultarTipoEstadoTitulo(titulo);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA REGISTRO DE PLANTILLA NOTIFICACION
        //*

        [TestMethod(displayName: "Prueba Unitaria cuando el registro del tipo estado notificación sea exitoso")]
        public void AgregarTipoEstadoServiceTest()
        {
            //arrange
            var tipoEstado = new TipoEstadoCreateDTO
            {
                
                nombre = "Plantilla Aprobado",
                descripcion = "Hola @Usuario su @Ticket fue @Estado",
                etiqueta = new HashSet<Guid>
                {
                    new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c")
                }
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());

            //act
            var result = _TipoEstadoService.RegistroTipoEstado(tipoEstado);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod(displayName: "Prueba Unitaria cuando el registro del tipo estado falla por campos vacios")]
        public void ExcepcionAgregarTipoEstadoCamposVacios()
        {
            //arrange
            var expected = new ExceptionsControl("alguno de los campos requeridos del tipo de estado está vacio", new DbUpdateException());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
            var result = new ExceptionsControl();
            var tipoEstadoTest = new TipoEstadoCreateDTO() { nombre = "Hola" };

            //act
            try
            {
                _TipoEstadoService.RegistroTipoEstado(tipoEstadoTest);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en el registro")]
        public void ExcepcionAgregarTipoEstado()
        {
            //arrange
            var expected = new ExceptionsControl("No se pudo registrar el tipo estado", new Exception());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new Exception());
            var result = new ExceptionsControl();
           

            //act
            try
            {
                _TipoEstadoService.RegistroTipoEstado(It.IsAny<TipoEstadoCreateDTO>());
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
            //Assert.ThrowsException<ExceptionsControl>(() => _plantillaService.RegistroPlantilla(It.IsAny<PlantillaNotificacionDTOCreate>()));
        }

        [TestMethod(displayName: "Prueba Unitaria cuando el registro falla por intentar asociar un tipo estado a una etiqueta que no existe")]
        public void ExcepcionAgregarTipoEstadoEtiquetaNoExiste()
        {
            //arrange
            var tipoEstado = new TipoEstadoCreateDTO
            {

                nombre = "Plantilla Aprobado",
                descripcion = "Hola @Usuario su @Ticket fue @Estado",
                etiqueta = new HashSet<Guid>
                {
                    new Guid("07c28457-f1fa-4a30-a347-b1fdb736bfd2")
                }
            };
            var expected = new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", new ExceptionsControl());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new ExceptionsControl());
            var result = new ExceptionsControl();

            //act
            try
            {
                _TipoEstadoService.RegistroTipoEstado(tipoEstado);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA ACTUALIZAR DE tIPO ESTADO
        //*

        [TestMethod(displayName: "Prueba Unitaria cuando la actualización del tipo estado sea exitoso")]
        public void ActualizarTipoEstadoServiceTest()
        {
            //arrange
            var idUpdate = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var tipoEstadoUpdate = new TipoEstadoCreateDTO()
            {

                nombre = "Aprobado",
                descripcion = "Hola @Usuario su @Ticket fue @Estado",
                etiqueta = new HashSet<Guid>
                {
                    new Guid("c76a9916-4cbb-434c-b88e-1fc8152eca8c")
                }
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());

            //act
            var result = _TipoEstadoService.ActualizarTipoEstado(tipoEstadoUpdate, idUpdate);

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando al actualizar el tipo estado con campos vacios")]
        public void ActualizarTipoEstadoCamposVacios()
        {
            //arrange
            var expected = new ExceptionsControl("Alguno de los campos requeridos del tipo de estado está vacio", new DbUpdateException());
            var result = new ExceptionsControl();
            var idUpdate = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var tipoEstadoUpdate = new TipoEstadoCreateDTO()
            {

                nombre = "Aprobado",
                descripcion = null,
                etiqueta = new HashSet<Guid>
                {
                    
                }
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());

            //act
            try
            {
                _TipoEstadoService.ActualizarTipoEstado(tipoEstadoUpdate, idUpdate);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
            Assert.AreEqual(expected.GetType(), result.GetType());
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en al actualizar")]
        public void ExcepcionActualizarTipoEstado()
        {
            //arrange
            var expected = new ExceptionsControl("No se pudo actualizar el tipo de estado", new Exception());
            var result = new ExceptionsControl();
            var idUpdate = It.IsAny<Guid>();
            var tipoEstadoUpdate = It.IsAny<TipoEstadoCreateDTO>();
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new Exception());

            //act
            try
            {
                _TipoEstadoService.ActualizarTipoEstado(tipoEstadoUpdate, idUpdate);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
            Assert.AreEqual(expected.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria cuando la actualizacion falla por intentar asociar un tipo estado a una etiqueta que no existe")]
        public void ExcepcionActualizarTipoEstadoEtiquetaNoExiste()
        {
            //arrange
            var idUpdate = Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var tipoEstado = new TipoEstadoCreateDTO
            {

                nombre = "Plantilla Aprobado",
                descripcion = "Hola @Usuario su @Ticket fue @Estado",
                etiqueta = new HashSet<Guid>
                {
                    new Guid("07c28457-f1fa-4a30-a347-b1fdb736bfd2")
                }
            };
            var expected = new ExceptionsControl("Se esta intentando asociar a una etiqueta que no existe", new ExceptionsControl());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new ExceptionsControl());
            var result = new ExceptionsControl();

            //act
            try
            {
                _TipoEstadoService.ActualizarTipoEstado(tipoEstado, idUpdate);
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA ELIMINAR TIPO ESTADO
        //*

        [TestMethod(displayName: "Prueba Unitaria cuando la eliminación del tipo estado sea exitoso")]
        public void EliminarTipoEstadoerviceTest()
        {
            //arrange
            
            _contextMock.Setup(set => set.DbContext.SaveChanges());
           // _contextMock.Setup(set => set.PlantillasNotificaciones).Returns(It.IsAny<PlantillaNotificacion>);

            //act
            var result = _TipoEstadoService.EliminarTipoEstado(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"));

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando la eliminación falla porque el tipo estado está en uso por un ticket")]
        public void ExcepcionEliminarTipoEstadoEnUso()
        {
            //arrange
            var expected = new ExceptionsControl("Un ticket está utilizado este tipo de estado, por lo tanto no se puede eliminar", new DbUpdateException());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
            var result = new ExceptionsControl();
           

            //act
            try
            {
                _TipoEstadoService.EliminarTipoEstado(Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c87"));
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }


        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto en la eliminación")]
        public void ExcepcionEliminarTipoEstado()
        {
            //arrange
            var expected = new ExceptionsControl("No se pudo eliminar el tipo de estado", new Exception());
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new Exception());
            var result = new ExceptionsControl();

            //act
            try
            {
                _TipoEstadoService.EliminarTipoEstado(Guid.Parse("38f401c9-12aa-46bf-82a2-05ff65bb2c87"));
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }

        //*
        //PRUEBAS UNITARIAS PARA AÑADIR RELACION DE ETIQUETA Y TIPO ESTADO
        //*

        [TestMethod(displayName: "Prueba Unitaria cuando ocurre cualquier error imprevisto agregando la relacion entre tipo estado y etiqueta")]
        public void ExcepcionAñadirRelacionEtiquetaTipoEstado()
        {
            //arrange
            var expected = new ExceptionsControl("No se pudo establecer la relacion entre las etiquetas y el tipo de estado", new Exception());
            _contextMock.Setup(set => set.DbContext.Add(It.IsAny<EtiquetaTipoEstado>)).Throws(new Exception());
            var result = new ExceptionsControl();

            //act
            try
            {
                _TipoEstadoService.AñadirRelacionEtiquetaTipoEstado(It.IsAny<Guid>(), It.IsAny<HashSet<Guid>>());
            }
            catch (ExceptionsControl ex)
            {
                result = ex;
            }

            //assert
            Assert.AreEqual(expected.Mensaje, result.Mensaje);
        }
    }
}
