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

            services.AddTransient<IDataContext, DataContext>();
            services.AddTransient<IPrioridadDAO, PrioridadDAO>();
            services.AddTransient<ITicketDAO, TicketDAO>();
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLRayner")));
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("cadenaSQLJesus")));

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
