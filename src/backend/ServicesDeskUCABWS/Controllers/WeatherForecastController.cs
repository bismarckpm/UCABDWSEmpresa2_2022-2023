using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesDeskUCABWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext contexto;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Tipo_Ticket> Get()
        {

            using (var context = contexto)
            {

                /*List<Departamento> ListaDepartamento = new List<Departamento>();
                ListaDepartamento.Add(contexto.Departamentos.Find(Guid.Parse("CCACD411-1B46-4117-AA84-73EA64DEAC87")));
                var Tipo_Tickets = new Tipo_Ticket("Solicitud","Tickets que se utilizan para cuando una persona de un departamento necesita un material.","Modelo_Paralelo");
                Tipo_Tickets.Departamento = ListaDepartamento;
                context.Tipos_Tickets.Add(Tipo_Tickets);

                var flujo = new Flujo_Aprobacion();
                flujo.IdTicket = Tipo_Tickets.Id; 
                flujo.IdTipo_cargo = Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C");//id_cargo
                flujo.Tipo_Ticket = Tipo_Tickets;
                flujo.Tipo_Cargo = context.Tipos_Cargos.Find(Guid.Parse("DDC1A0D0-FA70-48E1-9ACE-747057B0002C"));//id_cargo
                context.Flujos_Aprobaciones.Add(flujo);
                context.SaveChanges();

                
                /*return this.contexto.Tipos_Tickets.Join(contexto.Flujos_Aprobaciones,
                p => p.Id,
                e => e.Tipo_Ticket.Id,
                (p, e) => new FlujoAprobacionDTO
                {
                    IdTipoTicket = p.Id,
                    nombreTipoTicket = p.nombre,
                    tipo = p.tipo,
                    IdTipoCargo = e.Tipo_Cargo.Id,
                    tipo_cargo = e.Tipo_Cargo.nombre
                }).ToList();*/
                
                
                var tipo2=context.Tipos_Tickets.Include(x=>x.Flujo_Aprobacion).ToList();
                return (IEnumerable<Tipo_Ticket>)tipo2;
            }
        }

    }
}
