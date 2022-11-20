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
using ServicesDeskUCABWS.Data;
using System;
using System.Text.Json.Serialization;

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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPrioridadDAO, PrioridadDAO>();
<<<<<<< HEAD
            //services.AddTransient<ITicketDAO, TicketDAO>();
			services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner")));
            
=======
            services.AddTransient<ITicketDAO, TicketDAO>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLJesus")));
>>>>>>> 4b6f7c0a7b3933ac418b139414d149f012f3314d

            //Se agrega en generador de Swagger
            services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{ Title = "Empresa B", Version = "v1" });
			});

            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			//Habilitar swagger
			app.UseSwagger();

<<<<<<< HEAD
			//indica la ruta para generar la configuraciï¿½n de swagger
			app.UseSwaggerUI(c =>
=======
            //indica la ruta para generar la configuración de swagger
            app.UseSwaggerUI(c =>
>>>>>>> 4b6f7c0a7b3933ac418b139414d149f012f3314d
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
