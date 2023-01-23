using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.Exceptions;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperEtiquetaTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Mapper.MapperTipoEstado;
using ServicesDeskUCABWS.BussinesLogic.Response;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.DataSeed;

namespace UnitTestServicesDeskUCABWS.Grupo_E.TestEstado
{



    [TestClass]
    public class TestConsultarEstado
    {
        Mock<IDataContext> context;
        private readonly EstadoService EstadoDAO;
        private IMapper mapper;
        public TestConsultarEstado()
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
            EstadoDAO = new EstadoService(context.Object, mapper);
            context.SetupDbContextData();
        }

        //Test para Consultar el servicio Estado por Departamento 
        [TestMethod]
        public void CaminoFelizConsultarEstadoDepartamento()
        {
            //arrange
            var data = new EstadoDTOUpdate
            {
                Id = new Guid("B74DF138-BA05-45A8-B890-E424CA69210C"),
            };

            //Act
            context.Setup(a => a.DbContext.SaveChanges());

            var result = EstadoDAO.ConsultarEstadosDepartamento(data.Id);

            //Assert
            Assert.AreEqual(typeof(List<EstadoDTOUpdate>), result.GetType());

        }

        [TestMethod]
        public void ConsultarEstadosNoNullExitoso()
        {
            //arrage

            var data = new Departamento
            {
                id = Guid.Parse("36B2054E-BC66-4EA7-A5CC-7BA9137BC20E"),

            };
            context.Setup(a => a.DbContext.SaveChanges());

            //act 
            var result = EstadoDAO.ConsultarEstadosDepartamento(data.id);

            //assert
            Assert.AreEqual(typeof(List<EstadoDTOUpdate>), result.GetType());

        }


    } 
}




