using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ServicesDeskUCABWS.BussinesLogic.DAO.PrioridadDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DTO.TicketsDTO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EtiquetaDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.NotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.TipoEstadoDAO;
using ServicesDeskUCABWS.Data;
using ServicesDeskUCABWS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ServicesDeskUCABWS.BussinesLogic.DAO.UsuarioDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.UserRolDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.DepartamentoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.GrupoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.PlantillaNotificacionDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Votos_TicketDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.Tipo_CargoDAO;
using ServicesDeskUCABWS.BussinesLogic.DAO.EstadoDAO;

namespace ServicesDeskUCABWS
{
    public class Startup
    {

	

		public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

          

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup).Assembly);

			//Se agrega en generador de Swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{ Title = "Empresa B", Version = "v1" });
			});
			services.AddDbContext<DataContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient<IPrioridadDAO, PrioridadDAO>();
            services.AddTransient<ITicketDAO, TicketDAO>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner")));
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLJesus")));
            
            //Se agrega en generador de Swagger
            services.AddTransient<IDepartamentoDAO,DepartamentoDAO>();
			services.AddScoped<IGrupoDAO, GrupoDAO>();
			services.AddAutoMapper(typeof(Startup).Assembly);

			services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPlantillaNotificacion, PlantillaNotificacionService>();

            services.AddTransient<INotificacion, NotificacionService>();

            services.AddTransient<IEtiqueta, EtiquetaService>();

            services.AddTransient<ITipoEstado, TipoEstadoService>();
            
            services.AddTransient<IEstadoDAO, EstadoService>();

			services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnetion")));

            services.AddControllers();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        }*/

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            /*services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner"))
            );*/

			//Habilitar swagger
			app.UseSwagger();

            app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Caduca REST");
			});

			app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
