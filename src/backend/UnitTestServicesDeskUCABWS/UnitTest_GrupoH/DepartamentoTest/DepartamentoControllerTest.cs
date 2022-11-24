using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Controllers.ControllerDepartamento;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DepartamentoTest
{
    [TestClass]
    public class DepartamentoControllerTest
    {
        private readonly DepartamentoController _controller;
        private readonly Mock<IDepartamentoDAO> _serviceMock;
        public Departamento dept = It.IsAny<Departamento>();
        public DepartamentoDto deptDto = It.IsAny<DepartamentoDto>();


        public DepartamentoControllerTest()
        {
            _serviceMock = new Mock<IDepartamentoDAO>();
            _controller = new DepartamentoController(_serviceMock.Object);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Departamento exitoso")]
        public void Crear()
        {
            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarDepartamentoDAO(It.IsAny<Departamento>())).Returns(new DepartamentoDto());
            var application = new ApplicationResponse<DepartamentoDto>();

            //act
            var result = _controller.CrearDepartamento(dept);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Departamento excepcion")]
        public void CrearDepartamentoExcepcion()
        {

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarDepartamentoDAO(It.IsAny<Departamento>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearDepartamento(dept);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los departamentos")]
        public void ConsultarDepartamentos()
        {
            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarDepartamentoDAO(It.IsAny<Departamento>())).Returns(new DepartamentoDto());
            var application = new ApplicationResponse<DepartamentoDto>();

            //act
            var result = _controller.CrearDepartamento(dept);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para crear Departamento excepcion")]
        public void ConsultarDepartamentosExcepcion()
        {

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,
            };

            //arrange
            _serviceMock.Setup(p => p.AgregarDepartamentoDAO(It.IsAny<Departamento>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.CrearDepartamento(dept);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar departamento exitoso")]
        public void EliminarDepartamento()
        {
            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,
            };


            //arrange
            _serviceMock.Setup(p => p.eliminarDepartamento(It.IsAny<Guid>())).Returns(new DepartamentoDto());
            var application = new ApplicationResponse<DepartamentoDto>();

            //act
            var result = _controller.EliminarDepartamento(dept.id);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para eliminar Departamento excepcion")]
        public void EliminarDepartamentosExcepcion()
        {

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.eliminarDepartamento(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EliminarDepartamento(dept.id);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar departamento exitoso")]
        public void ActualizarDepartamento()
        {
            var dept = new DepartamentoDto_Update()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = DateTime.Now.Date,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.ActualizarDepartamento(It.IsAny<Departamento>())).Returns(new DepartamentoDto_Update());
            var application = new ApplicationResponse<DepartamentoDto_Update>();

            //act
            var result = _controller.ActualizarDepartamento(dept);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para actualizar Departamento excepcion")]
        public void ActualizarDepartamentosExcepcion()
        {

            var dept = new DepartamentoDto_Update()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            //arrange
            _serviceMock.Setup(p => p.ActualizarDepartamento(It.IsAny<Departamento>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ActualizarDepartamento(dept);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }


        [TestMethod(displayName: "Prueba Unitaria Controlador para modificar departamento por id de grupo exitoso")]
        public void ConsultarDepartamentoPorIDGrupo()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
                
            };

            //arrange
            _serviceMock.Setup(p => p.GetByIdDepartamento(It.IsAny<Guid>())).Returns(new List<DepartamentoDto>());
            var application = new ApplicationResponse<List<DepartamentoDto>>();

            //act
            var result = _controller.ListaDepartamentosGrupo(grupo.id);

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar departamento por id de grupo excepcion")]
        public void ExcepcionConsultarDepartamentoPorIDGrupo()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };
          
            //arrange
            _serviceMock.Setup(p => p.GetByIdDepartamento(It.IsAny<Guid>())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ListaDepartamentosGrupo(grupo.id);

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para asignar grupo a departamento exitoso")]
        public void AsignarGrupoToDepartamento()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.AsignarGrupoToDepartamento(It.IsAny<Guid>(),dept.id.ToString())).Returns(new List<string>());
            var application = new ApplicationResponse<List<string>>();

            //act
            var result = _controller.AsignarGrupoToDepartamento(grupo.id, dept.id.ToString());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para asignar grupo a departamento excepcion")]
        public void ExcepcionAsignarGrupoToDepartamento()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.AsignarGrupoToDepartamento(It.IsAny<Guid>(), dept.id.ToString())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.AsignarGrupoToDepartamento(grupo.id,dept.id.ToString());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los departamentos no asociados exitoso")]
        public void ListaDepartamentoNoAsociado()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.NoAsociado()).Returns(new List<DepartamentoDto>());
            var application = new ApplicationResponse<List<DepartamentoDto>>();

            //act
            var result = _controller.ListaDepartamentoNoAsociado();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los departamentos no asociados excepcion")]
        public void ExcepcionListaDepartamentoNoAsociado()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.NoAsociado()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ListaDepartamentoNoAsociado();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los departamentos no eliminados exitoso")]
        public void ListaDepartamentonoEliminado()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.DeletedDepartamento()).Returns(new List<DepartamentoDto>());
            var application = new ApplicationResponse<List<DepartamentoDto>>();

            //act
            var result = _controller.ListaDepartamentonoEliminado();

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para consultar los departamentos no eliminados excepcion")]
        public void ExcepcionListaDepartamentoNoEliminados()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.DeletedDepartamento()).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.ListaDepartamentonoEliminado();

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para editar la relacion de departamentos con grupo de forma exitosa")]
        public void EditarRelacion()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.EditarRelacion(It.IsAny<Guid>(), dept.id.ToString())).Returns(new List<string>());
            var application = new ApplicationResponse<List<string>>();

            //act
            var result = _controller.EditarRelacion(grupo.id, dept.id.ToString());

            //assert
            Assert.AreEqual(application.GetType(), result.GetType());
        }

        [TestMethod(displayName: "Prueba Unitaria Controlador para editar la relacion de departamentos con grupo de forma excepcion")]
        public void ExcepcionEditarRelacion()
        {
            var grupo = new Grupo()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Nuevo Grupo",

                descripcion = "Grupo nuevo",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null
            };

            var dept = new DepartamentoDto()
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null

            };

            //arrange
            _serviceMock.Setup(p => p.EditarRelacion(It.IsAny<Guid>(), dept.id.ToString())).Throws(new ExceptionsControl("", new Exception()));

            //act
            var ex = _controller.EditarRelacion(grupo.id, dept.id.ToString());

            //assert
            Assert.IsNotNull(ex);
            Assert.IsFalse(ex.Success);
        }

    }
}
