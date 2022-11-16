using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using ServicesDeskUCABWS.BussinessLogic.Exceptions;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed
{
    public static class DataSeed
    {
        public static void SetUpContextData(this Mock<IDataContext> _mockContext)
        {
            var request = new List<PlantillaNotificacion>
            {
                new PlantillaNotificacion
                {
                    Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    Titulo = "Plantilla Aprobado",
                    Descripcion = "Hola @Usuario su @Ticket",
                    TipoEstadoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                    TipoEstado = new Tipo_Estado()
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c86"),
                        nombre = "Aprobado",
                        descripcion = "Cuando se aprueba un ticket",
                        etiquetaTipoEstado = null
                    }
                },
                new PlantillaNotificacion
                {
                    Id = new Guid("99f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                    Titulo = "Plantilla Rechazado",
                    Descripcion = "Hola @Usuario su @Ticket",
                    TipoEstadoId = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                    TipoEstado = new Tipo_Estado()
                    {
                        Id = new Guid("38f401c9-12aa-46bf-82a2-05ff65bb2c87"),
                        nombre = "Rechazado",
                        descripcion = "Cuando se rechaza un ticket",
                        etiquetaTipoEstado = null
                    }
                },
            };

            _mockContext.Setup(c => c.PlantillasNotificaciones).Returns(request.AsQueryable().BuildMockDbSet().Object);
            _mockContext.Setup(set => set.PlantillasNotificaciones.Add(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(e => e.PlantillasNotificaciones.Update(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(e => e.PlantillasNotificaciones.Remove(It.IsAny<PlantillaNotificacion>()));
            _mockContext.Setup(set => set.DbContext.SaveChanges());
            //_mockContext.Setup(set => set.PlantillasNotificaciones.AddAsync(It.IsAny<PlantillaNotificacion>(),default));
            //_mockContext.Setup(c => c.DbContext.SaveChangesAsync(It.IsAny<CancellationToken>())).Verifiable();
            //_mockContext.Setup(m => m.DbContext.SaveChanges());

            //_mockContext.Setup(c => c.PlantillasNotificaciones.Find(It.IsAny<object[]>())).Returns((object[] input) => .Where(x => x.Id == (Guid)input.First()).FirstOrDefault());
            //_mockContext.Setup(set => set.Tipo_Estados.Add(It.IsAny<Tipo_Estado>())).Callback<Tipo_Estado>(ListaTipoEstados.Add);
            //_mockContext.Setup(set => set.Tipo_Estados.AddRange(It.IsAny<IEnumerable<Tipo_Estado>>())).Callback<IEnumerable<Tipo_Estado>>(ListaTipoEstados.AddRange);
            //_mockContext.Setup(set => set.DbContext.SaveChanges()).Throws(new ExceptionsControl("", new DbUpdateException()));
        }

        public static void SetUpContextDataVacio(this Mock<IDataContext> _mockContext)
        {
            var request = new List<PlantillaNotificacion>() { };

            _mockContext.Setup(c => c.PlantillasNotificaciones).Returns(request.AsQueryable().BuildMockDbSet().Object);
        }
    }
}
