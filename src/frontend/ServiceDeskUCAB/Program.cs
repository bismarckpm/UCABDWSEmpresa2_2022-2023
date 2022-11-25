using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;
using Microsoft.Extensions.DependencyInjection;
using ServiceDeskUCAB.Servicios.ModuloTipoCargo;
using ServiceDeskUCAB.Servicios.ModuloCargo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServicioDepartamento_API, ServicioDepartamento_API>();
builder.Services.AddScoped<IServicioGrupo_API, ServicioGrupo_API>();
builder.Services.AddScoped<IServicioTipo_Cargo_API, ServicioTipo_Cargo_API>();
builder.Services.AddScoped<IServicioCargo_API, ServicioCargo_API>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
