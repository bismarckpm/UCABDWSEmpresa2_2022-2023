using Moq;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacioneDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.Etiqueta;
using ServicesDeskUCABWS.BussinesLogic.DTO.Plantilla;
using ServicesDeskUCABWS.BussinesLogic.DTO.TipoEstado;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestServicesDeskUCABWS.UnitTest_GrupoG.DataSeed;

namespace UnitTestServicesDeskUCABWS.UnitTest_GrupoG.UnitTestNotificacion
{
    [TestClass]
    public class NotificacionServiceTest
    {
        private readonly Mock<IDataContext> _contextMock;
        private readonly NotificacionService _NotificacionService;


        public NotificacionServiceTest()
        {
            _contextMock = new Mock<IDataContext>();
            _NotificacionService = new NotificacionService(_contextMock.Object);
            _contextMock.SetUpContextData();
        }

        //*
        //PRUEBAS UNITARIAS PARA REEMPLAZAR ETIQUETAS EN PLANTILLA NOTIFICACION
        //*

        [TestMethod(displayName: "Prueba Unitaria para reemplazar las etiquetas en la plantilla notificación")]                       //Se le quitó la programación asíncrona a todo lo que respecta la consulta plantilla
        public void ReemplazarEtiquetasNotificacionServiceTest()
        {

            var Ticket = new Ticket()
            {
                Id = Guid.NewGuid(),
                titulo = "titulo",
                descripcion = "descripcion",
                fecha_creacion = DateTime.Now,
                Estado = new Estado() {
                    Id = Guid.NewGuid(),
                    nombre = "nombreEstado"
                },
                Tipo_Ticket = new Tipo_Ticket()
                {
                  nombre = "nombreTipoTicket"  
                },
                Departamento_Destino = new Departamento()
                {
                    nombre = "nombreDepartamento",
                    Grupo = new Grupo()
                    {
                        nombre = "nombreGrupo"
                    }
                },
                Prioridad = new Prioridad()
                {
                    nombre = "nombrePrioridad"
                },
                empleado = new Empleado()
                {
                    Id = Guid.Parse("18f401c9-12aa-460f-80a2-00ff05bb0c06"),
                    primer_nombre = "nombreEmpleado",
                    primer_apellido = "apellidoEmpleado",
                    Cargo = new Cargo()
                    {
                        Id = Guid.NewGuid(),
                        nombre_departamental = "nombreDepartamento",
                        descripcion = "descrip",
                        fecha_creacion = DateTime.Now,
                    }
                },
                Votos_Ticket = new HashSet<Votos_Ticket>
                {
                    new Votos_Ticket()
                    {
                        Id = Guid.NewGuid(),
                        comentario = "comentarioVoto",
                    }
                }
            };

            var Plantilla = new PlantillaNotificacionDTO()
            {
                Id = Guid.NewGuid(),
                Titulo = "tituloPlantilla",
                Descripcion = "@Cargo @Ticket @Estado @Departamento @Grupo @Prioridad @Usuario @TipoTicket @ComentarioVoto",
                TipoEstado = new TipoEstadoDTO()
                {
                    etiqueta = new HashSet<EtiquetaDTO>()
                    {
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Usuario"
                        },
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Departamento"
                        },
                        new EtiquetaDTO() {
                            Id = Guid.NewGuid(),
                            Descripcion = "nombreDescripcion",
                            Nombre = "@Grupo"
                        }
                    }
                }
            };

            var result = _NotificacionService.ReemplazoEtiqueta(Ticket, Plantilla);
            Assert.AreEqual(result, "@Cargo @Ticket @Estado nombreDepartamento nombreGrupo @Prioridad nombreEmpleado apellidoEmpleado @TipoTicket @ComentarioVoto");
        }
    }
}
