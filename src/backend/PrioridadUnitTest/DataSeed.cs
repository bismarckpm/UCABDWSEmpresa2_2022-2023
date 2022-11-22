using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using ServicesDeskUCABWS.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServicesDeskUCABWS.BussinesLogic.DTO.PrioridadDTO;

//Información Falsa creada con el fin de usarse en Pruebas Unitarias//

namespace PrioridadUnitTest
{
    public static class DataSeed
    {

        public static void SetupDbContextData(this Mock<IDataContext> _mockContext)
        {

            var ListaPrioridad = new List<Prioridad>
            {
                
                new Prioridad{
                Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
                nombre ="nombre",
                descripcion ="descripcion",
                estado ="habilitado",
                fecha_descripcion=new DateTime(2008, 5, 1, 8, 30, 52),
                fecha_ultima_edic=new DateTime(2008, 5, 1, 8, 30, 52)
                }
             
            };

            _mockContext.Setup(c => c.Prioridades).Returns(ListaPrioridad.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(c => c.Prioridades.Find(It.IsAny<object[]>())).Returns((object[] input) => ListaPrioridad.Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            _mockContext.Setup(set => set.Prioridades.Add(It.IsAny<Prioridad>())).Callback<Prioridad>(ListaPrioridad.Add);
            _mockContext.Setup(set => set.Prioridades.AddRange(It.IsAny<IEnumerable<Prioridad>>())).Callback<IEnumerable<Prioridad>>(ListaPrioridad.AddRange);
            _mockContext.Setup(set => set.Prioridades.Add(It.IsAny<Prioridad>()));
            _mockContext.Setup(e => e.Prioridades.Update(It.IsAny<Prioridad>()));



        }

        public static void SetupCrear(this Mock<IDataContext> _mockContext)
        {
            new PrioridadDTO
            {
                Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650809"),
                nombre = "nombre",
                descripcion = "descripcion",
                estado = "estado",
                fecha_descripcion = new DateTime(2008, 5, 1, 8, 30, 52),
                fecha_ultima_edic = new DateTime(2008, 5, 1, 8, 30, 52)
            };




        }


        public static void SetUpContextDataVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<Prioridad>() { };

            _mockContext.Setup(c => c.Prioridades).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }




        public static void SetupDbContextDTO(this Mock<IDataContext> _mockContext)
        {

            var ListaPrioridad = new List<PrioridadDTO>
            {
                
                new PrioridadDTO{
                Id = new Guid("2DF5B096-DC5A-421F-B109-2A1D1E650808"),
                nombre ="nombre",
                descripcion ="descripcion",
                estado ="habilitado",
                fecha_descripcion=new DateTime(2008, 5, 1, 8, 30, 52),
                fecha_ultima_edic=new DateTime(2008, 5, 1, 8, 30, 52)
                }
              

            };




        }


    }
}