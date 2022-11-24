using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServiceDeskUCAB.Servicios.DepartamentoEstado;
using Microsoft.Extensions.Hosting;
using ServiceDeskUCAB.Servicios;
using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServicioUsuario_API, ServicioUsuario_API>();
builder.Services.AddScoped<IServicio_API, Servicio_API>();
builder.Services.AddScoped<IServicioDepartamento_API, ServicioDepartamento_API>();
builder.Services.AddScoped<IServicioPlantillaNotificacion_API, ServicioPlantillaNotificacion_API>();
builder.Services.AddScoped<IServicioTipoEstado_API, ServicioTipoEstado_API>();
builder.Services.AddScoped<IServicioGrupo_API, ServicioGrupo_API>();
builder.Services.AddScoped<IServicioDepartamentoEstado, ServicioDepartamentoEstado>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
