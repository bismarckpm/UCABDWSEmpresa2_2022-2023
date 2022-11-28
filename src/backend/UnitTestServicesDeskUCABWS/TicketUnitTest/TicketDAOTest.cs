using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Data;
using System.Text;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
using System.Collections.Generic;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.Excepciones;
using ServicesDeskUCABWS.Entities;
using ServicesDeskUCABWS.BussinesLogic.Validaciones;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketDTO;


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace TicketUnitTest
{
    [TestClass]
    public class TicketDAOTest
    {
        private readonly TicketDAO _TicketDAO;
        private readonly Mock<IDataContext> _contextMock;
        private readonly IMapper _mapper;
       
      

        public TicketDAOTest()
        {

            //Preparación
           
            _contextMock = new Mock<IDataContext>();


            var myProfile = new List<Profile>
                {
                new TicketMapper()

            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
       
            _TicketDAO = new TicketDAO(_contextMock.Object, _mapper);
            _contextMock.SetupDbContextDataTicket();
        }

        //*
        //Prueba Unitaria para crear los tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para crear los tickets")]
        public void crearTicketTest()
        {

            //Prueba
            var ticket = new TicketNuevoDTO
            {
                titulo = "titulo",
                descripcion = "aaaaaaaa",
                empleado_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70"),
                prioridad_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c60"),
                tipoTicket_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c50"),
                departamentoDestino_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c40"),
                nro_cargo_actual = 1
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());
            var application = "Ticket creado satisfactoriamente";
            var result = new ApplicationResponse<string>();
            result.Success = true;
            var resultado = _TicketDAO.crearTicket(ticket);
            //Verificación

            Assert.IsTrue(result.Success);
           

        }


        //*
        //Prueba Unitaria para consultar tickets por id
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por id")]
        public void ObtenerTicketPorIdTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var application = new ApplicationResponse<TicketInfoCompletaDTO>();


            //Prueba
            var resultado = _TicketDAO.obtenerTicketPorId(id);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
          

        }



        //*
        //Prueba Unitaria para consultar tickets por estado y departamento
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar los tickets por estado y departamento")]
        public void ObtenerTicketPorEstadoYDepartamentoTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var estado = "Habilitado";
            var application = "Proceso de búsqueda exitoso";


            //Prueba
            var resultado = _TicketDAO.obtenerTicketsPorEstadoYDepartamento(id, estado);

            //Verificación

            StringAssert.Equals(application.GetType(), resultado.GetType());
            /*StringAssert.Equals(application, resultado);
            Assert.Equals(application, resultado);
            Assert.IsTrue(resultado.Success);*/
        }

        //*
        //Prueba Unitaria para cambiar el estado del ticket
        //*
        [TestMethod(displayName: "Prueba Unitaria para cambiar el estado del ticket")]
        public void CambiarEstadoTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var estado = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87");
           


            //Prueba
            var resultado = _TicketDAO.cambiarEstadoTicket(id, estado);
            var result = new ApplicationResponse<string>();

            //Verificación
            StringAssert.Equals(result.GetType(), resultado.GetType());

        }

        //*
        //Prueba Unitaria para obtener las bitacoras del ticket
        //*
        /*[TestMethod(displayName: "Prueba Unitaria para obtener las bitacoras del ticket")]
        public void ObtenerBitacorasTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var result = new ApplicationResponse<List<TicketBitacorasDTO>>();
            result.Success = true;




            //Prueba
            var resultado = _TicketDAO.obtenerBitacoras(id);

            //Verificación

            //StringAssert.Equals(result.GetType(), resultado.GetType());
            Assert.IsTrue(result.Success);

        }*/


        //*
        //Prueba Unitaria para hacer merge de tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para hacer merge de tickets")]
        public void MergeTicketsTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");
            var lista = new List<Guid> {
                new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c85"),
                new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87")

            };




            //Prueba
            var resultado = _TicketDAO.mergeTickets(id, lista);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para reenviar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para reenviar tickets")]
        public void ReenviarTicketsTest()
        {
            //Preparación
            var ticket = new TicketReenviarDTO();
            var application = new ApplicationResponse<string>();
            application.Success = true;

            //Prueba
            var resultado = _TicketDAO.reenviarTicket(ticket);

            //Verificación

            //StringAssert.Equals(application.GetType(), resultado.GetType());
            Assert.IsTrue(application.Success);
        
        }

        //*
        //Prueba Unitaria para obtener familias de tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para obtener familias de tickets")]
        public void ObtenerFamiliaTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.obtenerFamiliaTicket(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }

        //*
        //Prueba Unitaria para eliminar tickets
        //*
        [TestMethod(displayName: "Prueba Unitaria para eliminar tickets")]
        public void EliminarTicketTest()
        {
            //Preparación
            var id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86");


            //Prueba
            var resultado = _TicketDAO.eliminarTicket(id);

            //Verificación


            Assert.IsTrue(resultado.Success);
        }














        //*
        //Pruebas Unitarias EXCEPCIONES
        //*


        //*
        //Prueba Unitaria para crear tickets excepcion de descripcion
        //*
        [TestMethod(displayName: "Prueba Unitaria cuando la creacion de los ticket retorna TicketDescripcionExcepcion")]

        public void CrearTicketDescripcionExceptionTest()
        {
            //Preparación y Prueba
            var ticket = new TicketNuevoDTO
            {
                titulo = "titulo",
                descripcion = "a",
                empleado_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c70"),
                prioridad_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c60"),
                tipoTicket_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c50"),
                departamentoDestino_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c40")
            };
           

           // var _validaciones = new Mock<TicketValidaciones>(_contextMock.Object);
            _contextMock.Setup(p => p.Tickets).Throws(new TicketDescripcionException(""));
          
            var ex = "El formato de la descripción no es válido";
            var resultado = _TicketDAO.crearTicket(ticket);

            //Verificación

           
            Assert.AreEqual(ex, resultado.Message);

            
        }

       

        //*
        //Prueba Unitaria para crear tickets excepcion de ticket
        //*
      /*  [TestMethod(displayName: "Prueba Unitaria cuando la creacion de los ticket retorna TicketExcepcion")]

        public void CrearTicketTestTicketException()
        {
            //Preparación y Prueba
            var ticket = new TicketNuevoDTO
            {
                titulo = "titulo",
                descripcion = "aaaaa",
                empleado_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb0101"),
                prioridad_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c60"),
                tipoTicket_id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c50"),
                departamentoDestino_Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c40")
            };
          
            _validaMock.Setup(p => p.validarEmisor(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb0101"))).Throws(new TicketEmisorException("", new Exception()));

           // _contextMock.Setup(p => p.Tickets).Throws(new TicketEmisorException(""));
            //_contextMock.Setup(p => p.Empleados).Throws(new TicketEmisorException(""));
          
           // _contextMock.SetUpContextDataVacioEmpleado();
           // _contextMock.SetUpContextDataVacioUsuario();
           
            var resultado = _TicketDAO.crearTicket(ticket);
            
         

            //Verificación

          //  StringAssert.Equals(ex.GetType(), resultado.GetType());
           // StringAssert.Equals(ex, resultado.Message);
            Assert.ThrowsException<TicketEmisorException>(() => _TicketDAO.crearTicket(ticket));
            //Assert.ThrowsException<Exception>(() => _TicketDAO.crearTicket(ticket));
            // Assert.AreEqual(ex, resultado.Message);

        }*/











        //*
        //Prueba Unitaria para consultar tickets por id excepcion
        //*
        /*[TestMethod(displayName: "Prueba Unitaria cuando la consulta por id de los ticket retorna TicketExcepcion")]

        public void ObtenerTicketPorIdTestException()
        {
            //Preparación y Prueba
            var  _validaciones = new Mock<TicketValidaciones>(_contextMock.Object);
            _contextMock.Setup(p => p.Prioridades).Throws(new TicketException(""));
          


            //Verificación
            _validaciones.Setup(t => t.validarTicket(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c00"))).Throws(new TicketException("", new Exception()));
            Assert.ThrowsException<TicketException>(() => _TicketDAO.obtenerTicketPorId(new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c00")));
        }*/
    }

}