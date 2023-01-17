using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO;
using ServicesDeskUCABWS.Controllers;
using ServicesDeskUCABWS.Data;
using System.Text;
using System.Linq;
using System;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;
using ServicesDeskUCABWS.BussinesLogic.Mappers;
using System.Collections.Generic;


//* Preparación  -> Organizar las precondiciones
//* Prueba -> Actuar, es decir, ejecutar lo que se quiere probar
//* Verificación  -> Verificar que se han cumplido las postcondiciones

namespace PrioridadUnitTest
{
    [TestClass]
    public class PrioridadDAOTest
    {
        private readonly PrioridadDAO _PrioridadDAO;
        private readonly Mock<IDataContext> _contextMock;
        
        private readonly IMapper _mapper;

        public PrioridadDAOTest()
        {

            //Preparación
            _contextMock = new Mock<IDataContext>();
            
            var myProfile = new List<Profile>
                {
                new PrioridadMapper()
                
            };
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(myProfile));
            _mapper = new Mapper(configuration);
            _PrioridadDAO = new PrioridadDAO(_contextMock.Object, _mapper);
            _contextMock.SetupDbContextData();
        }

        //*
        //Prueba Unitaria para consultar todas las prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar las prioridades")]
        public void ObtenerPrioridadesTest()
        {
            //Prueba
            var resultado = _PrioridadDAO.ObtenerPrioridades();
            //Verificación
            Assert.IsTrue(resultado.Count() > 0);
        }


        //*
        //Prueba Unitaria para consultar prioridades habilitadas
        //*

      
        [TestMethod(displayName: "Prueba Unitaria para consultar las prioridades habilitadas exitosamente")]
        public void ObtenerPrioridadesHabilitadasTest()
        {
           
            var prioridad = new List<PrioridadDTO> {
                new PrioridadDTO
                {
                    Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
                    nombre = "nombre",
                    descripcion = "descripcion",
                    estado = "Habilitado",
                    fecha_descripcion = new DateTime(2008, 5, 1, 8, 30, 52),
                    fecha_ultima_edic = new DateTime(2008, 5, 1, 8, 30, 52)

                    }
                };
            _contextMock.Setup(set => set.DbContext.SaveChanges());



            //Prueba
            var resultado = _PrioridadDAO.ObtenerPrioridadesHabilitadas();

            //Verificación
             Assert.IsTrue(resultado.Count() > 0);
           // Assert.AreEqual(prioridad.GetType(), resultado.GetType());
        }

        //*
        //Prueba Unitaria para consultar prioridades por id
        //*
        [TestMethod(displayName: "Prueba Unitaria para consultar las prioridades por id")]
        public void ObtenerPrioridadTest()
        {
            //Preparación
            var id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808");


            //Prueba
            var resultado = _PrioridadDAO.ObtenerPrioridad(id);

            //Verificación
            Assert.AreEqual(id, resultado.Id);
        }

        //*
        //Prueba Unitaria para crear prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria para crear prioridades")]
        public void CrearPrioridadTest()
        {
            //Preparación
            var prioridad = new PrioridadSolicitudDTO
            {
                
                nombre = "nombre",
                descripcion = "descripcion",
                estado = "Habilitado",
                
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());


            //Prueba
            var resultado = _PrioridadDAO.CrearPrioridad(prioridad);
            var mensaje = "Prioridad creada satisfactoriamente";

            //Verificación

            StringAssert.Equals(mensaje.GetType(), resultado.GetType());
            StringAssert.Equals(mensaje, resultado);
        

        }

        //*
        //Prueba Unitaria para modificar prioridades
        //*
        [TestMethod(displayName: "Prueba Unitaria para crear prioridades")]
        public void ModificarPrioridadTest()
        {
            //Preparación
            
            var prioridad = new PrioridadDTO
            {
                Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
                nombre = "nombre",
                descripcion = "descripcion",
                estado = "Habilitado",
                fecha_descripcion = new DateTime(2008, 5, 1, 8, 30, 52),
                fecha_ultima_edic = new DateTime(2008, 5, 1, 8, 30, 52)
            };
            _contextMock.Setup(set => set.DbContext.SaveChanges());


            //Prueba
            var resultado = _PrioridadDAO.ModificarPrioridad(prioridad);
            var mensaje = "Prioridad modificada satisfactoriamente";

            //Verificación

            StringAssert.Equals(mensaje.GetType(), resultado.GetType());
            //StringAssert.Equals(mensaje, resultado);
            //Assert.AreEqual(mensaje, resultado);

        }


        //*
        //Pruebas Unitarias EXCEPCIONES
        //*



        //*
        //Prueba Unitaria para consultar prioridades excepcion
        //*
        /* [TestMethod(displayName: "Prueba Unitaria cuando la consulta de las prioridades retorna  excepcion")]   

         public void ObtenerPrioridadesTestException()
         {
             //Preparación y Prueba
             _contextMock.Setup(p => p.Prioridades).Throws(new Exception(""));


             //Verificación
         Assert.ThrowsException<Exception>(() => _PrioridadDAO.ObtenerPrioridades());
         }*/




        //*
        //Prueba Unitaria para consultar prioridades por estado excepcion
        //*
        [TestMethod(displayName: "Prueba Unitaria cuando la consulta por estado de las prioridades retorna excepcion")]

        public void ObtenerPrioridadesHabilitadasTestException()
        {
            //Preparación y Prueba
            _contextMock.Setup(p => p.Prioridades).Throws(new Exception(""));


            //Verificación
            Assert.ThrowsException<Exception>(() => _PrioridadDAO.ObtenerPrioridadesHabilitadas());
        }




        //*
        //Prueba Unitaria para consultar prioridades por id excepcion
        //*
       /* [TestMethod(displayName: "Prueba Unitaria cuando la consulta por id de las prioridades retorna excepcion")]

        public void ObtenerPrioridadTestException()
        {
            //Preparación y Prueba
            _contextMock.Setup(p => p.Prioridades).Throws(new Exception(""));


            //Verificación
            Assert.ThrowsException<Exception>(() => _PrioridadDAO.ObtenerPrioridad(It.IsAny<Guid>()));
        }*/



        //*
        //Prueba Unitaria para modificar prioridades excepcion
        //*
       /* [TestMethod(displayName: "Prueba Unitaria cuando la modificacion de las prioridades retorna excepcion")]

        public void ModificarPrioridadTestException()
        {
            //Preparación y Prueba
            _contextMock.Setup(p => p.Prioridades).Throws(new Exception(""));


            //Verificación
            Assert.ThrowsException<Exception>(() => _PrioridadDAO.ModificarPrioridad(It.IsAny<PrioridadDTO>()));
        }*/

        //*
        //Prueba Unitaria para crear prioridades excepcion
        //*
      /*  [TestMethod(displayName: "Prueba Unitaria cuando la creacion de las prioridades retorna excepcion")]

        public void CrearPrioridadTestException()
        {
            //Preparación y Prueba
            _contextMock.Setup(p => p.Prioridades).Throws(new Exception(""));


            //Verificación
            Assert.ThrowsException<Exception>(() => _PrioridadDAO.CrearPrioridad(It.IsAny<PrioridadDTO>()));
        }*/

    }
}
  