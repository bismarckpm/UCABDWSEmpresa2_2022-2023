using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.DepartamentoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DataSeed;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoH.DepartamentoTest
{
    [TestClass]
    public class DepartamentoDAOTest
    {
        private readonly DepartamentoDAO _DepartamentoDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly Mock<IDataContext> _contextMockDG;
        private readonly Mock<IGrupoDAO> _serviceMock;
        private readonly IGrupoDAO _servicioGrupo;
        private readonly IMapper mapper;

        public DepartamentoDAOTest()
        {
            _contextMock = new Mock<IDataContext>();
            _contextMockDG = new Mock<IDataContext>();
            _servicioGrupo = new GrupoDAO(_contextMockDG.Object);
            _DepartamentoDAO = new DepartamentoDAO(_contextMock.Object, mapper);
            _contextMock.SetUpContextDataDepartamento();
            _serviceMock = new Mock<IGrupoDAO>();            
            _contextMockDG.SetUpContextDataDepartamentoYGrupo();
           
        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Departamento")]
        public void AgregarDepartamentoTest()
        {
            //arrange
            var ListaTipoEstados = new List<Tipo_Estado>
            {
                new Tipo_Estado("Aprobado", "Tipo Estado prueba")
                {
                    Id=new Guid("A4D4417A-9A80-4EC2-B01E-02F57EB31144")
                },
                new Tipo_Estado("Rechazado","Tipo Estado prueba")
                {
                    Id=new Guid("3DD45003-3829-473B-92E5-03199E545C6C")
                }
            };
            var ListaEstados = new List<Estado>();

            _contextMock.Setup(c => c.Tipos_Estados).Returns(ListaTipoEstados.AsQueryable().BuildMockDbSet().Object);
            _contextMock.Setup(set => set.Estados.AddRange(It.IsAny<IEnumerable<Estado>>())).Callback<IEnumerable<Estado>>(ListaEstados.AddRange);

            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _DepartamentoDAO.AgregarDepartamentoDAO(request);

            Assert.AreEqual(request.nombre, "Seguridad Ambiental");
        }

        [TestMethod(displayName: "Prueba Unitaria para agregar un Departamento Condicional")]
        public void AgregarDepartamentoTestIf()
        {
            //arrange
            var ListaTipoEstados = new List<Tipo_Estado>
            {
                new Tipo_Estado("Aprobado", "Tipo Estado prueba")
                {
                    Id=new Guid("A4D4417A-9A80-4EC2-B01E-02F57EB31144")
                },
                new Tipo_Estado("Rechazado","Tipo Estado prueba")
                {
                    Id=new Guid("3DD45003-3829-473B-92E5-03199E545C6C")
                }
            };
            var ListaEstados = new List<Estado>();

            _contextMock.Setup(c => c.Tipos_Estados).Returns(ListaTipoEstados.AsQueryable().BuildMockDbSet().Object);
            _contextMock.Setup(set => set.Estados.AddRange(It.IsAny<IEnumerable<Estado>>())).Callback<IEnumerable<Estado>>(ListaEstados.AddRange);


            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental 2",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _DepartamentoDAO.AgregarDepartamentoDAO(request);

            Assert.AreNotEqual(request.nombre, result.Nombre);
        }



        [TestMethod(displayName: "Prueba Unitaria para agregar un Departamento excepcion general")]
        public void AgregarDepartamentoTestExceptionGeneral()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre = "",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.AgregarDepartamentoDAO(request));
        }

       
        [TestMethod(displayName: "Prueba Unitaria para consultar departamentos")]
        public void ConsultarDepartamentosTest()
        {

            var result = _DepartamentoDAO.ConsultarDepartamentos();
            Assert.AreEqual(result.Count(), _contextMock.Object.Departamentos.ToList().Count());
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar departamentos excepcion")]
        public void ConsultarDepartamentosTestException()
        {
            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ConsultarDepartamentos());
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar departamentos por ID")]
        public void ConsultarDepartamentosPorIDTest()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            var result = _DepartamentoDAO.ConsultarPorID(request.id);
            Assert.AreEqual(result.Id, request.id);
        }

        [TestMethod(displayName: "Prueba Unitaria para consultar departamentos por ID excepcion")]
        public void ConsultarDepartamentosTestExceptionID()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c88"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ConsultarPorID(request.id));
        }

        [TestMethod(displayName: "Eliminar Departamento por ID")]
        public void EliminarDepartamentoPorID()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86")                

            };

            var obj = new DepartamentoDto();
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _DepartamentoDAO.eliminarDepartamento(request.id);
            Assert.IsInstanceOfType(obj,result.GetType());
        }



        [TestMethod(displayName: "Excepcion de eliminar Departamento por ID")]
        public void ExcepcionEliminarDepartamentoPorID()
        {
            var data = new Departamento
            {
                id = new Guid("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E")

            };      

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.eliminarDepartamento(data.id));
        }

        [TestMethod(displayName: "Prueba Unitaria para editar un Departamento")]
        public void ActualizarDepartamentoTest()
        {
            //arrange
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _DepartamentoDAO.ActualizarDepartamento(request);

            Assert.AreEqual(request.nombre, "Seguridad Ambiental");
        }

     
        [TestMethod(displayName: "Prueba Unitaria cuando la actualizacion de un departamento falla por campos vacios")]
        public void ExcepcionDBUpdateActualizarDepartamento()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = null,

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };
            _contextMock.Setup(set => set.DbContext.SaveChanges()).Throws(new DbUpdateException());
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ActualizarDepartamento(request));
        }


        [TestMethod(displayName: "Prueba Unitaria para editar un departamento excepcion general")]
        public void ExcepcionEditarDepartamentoTestExceptionGeneral()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ActualizarDepartamento(request));
        }
    
        [TestMethod(displayName: "Prueba Unitaria para mostrar departamentos no eliminados")]
        public void MostrarDepartamentosNoEliminados()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _DepartamentoDAO.DepartamentosNoEliminados();

            Assert.AreEqual(result.Count(),2);
        }

        [TestMethod(displayName: "Prueba Unitaria para mostrar departamentos no eliminados excepcion")]
        public void ExcepcionMostrarDepartamentosNoEliminados()
        {
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = DateTime.Now.Date,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.DepartamentosNoEliminados());
        }

        [TestMethod(displayName: "Prueba Unitaria para mostrar departamentos no asociados a un grupo")]
        public void MostrarDepartamentosNoAsociados()
        {
            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.DepartamentosNoEliminados());
        }


        [TestMethod(displayName: "Prueba Unitaria para listar los departamentos que no están asociados a un grupo")]
        public void NoAsociado()
        {

            _contextMock.Setup(set => set.DbContext.SaveChanges());

            var result = _DepartamentoDAO.NoAsociado();

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod(displayName: "Prueba Unitaria para listar los departamentos que no están asociados a un grupo excepcion")]
        public void ExcepcionNoAsociado()
        {

            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.NoAsociado());
        }

        
        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de departamento")]
        public void ExisteDepartamento()
        {

           
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };


            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _DepartamentoDAO.ExisteDepartamento(request);
            Assert.IsTrue(result);
        }

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de departamento con excepcion")]
        public void ExcepcionExisteDepartamento()
        {
            
            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2cab"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ExisteDepartamento(request));
        }

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de departamento al momento de modificar exitoso primer caso")]
        public void NoExisteDepartamentoModificar()
        {


            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };


            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _DepartamentoDAO.ExisteDepartamentoModificar(request);
            Assert.IsFalse(result);
        }

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de departamento al momento de modificar exitoso segundo caso")]
        public void ExisteDepartamentoModificar()
        {


            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),

                nombre = "Seguridad Ambiental",

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };


            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var result = _DepartamentoDAO.ExisteDepartamentoModificar(request);
            Assert.IsTrue(result);
        }

        [TestMethod(displayName: "Prueba Unitaria para verificar existencia de departamento al momento de modificar con excepcion")]
        public void ExcepcionExisteDepartamentoModificar()
        {

            var request = new Departamento
            {

                id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2cab"),

                nombre = null,

                descripcion = "Cuida el ambiente",

                fecha_creacion = DateTime.Now.Date,

                fecha_ultima_edicion = null,

                fecha_eliminacion = null,

                id_grupo = null

            };

            _contextMock.Setup(p => p.Departamentos).Throws(new Exception(""));
            Assert.ThrowsException<ExceptionsControl>(() => _DepartamentoDAO.ExisteDepartamento(request));
        }


     

    }
}

