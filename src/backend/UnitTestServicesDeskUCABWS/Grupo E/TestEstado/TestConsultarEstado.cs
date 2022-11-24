using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.EstadoDTO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.Mapper;
using ServicesDeskUCABWS.BussinesLogic.Response;
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
        
        //Test camino feliz para hacer el consultar estado

        [TestMethod]
        public void CaminoFelizConsultarEstadoTest()
        {

            //arrange
            var entrada = Guid.Parse("19C117F4-9C2A-49B1-A633-969686E0B57E");

            //act 
            var result = EstadoDAO.ConsultarEstadosDepartamento(entrada);

            //assert
            Assert.IsTrue(result.Count() > 0);
            
        }
    }
}




