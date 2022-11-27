using ServiceDeskUCAB.Servicios.ModuloDepartamento;
using ServiceDeskUCAB.Servicios.ModuloGrupo;
using ServiceDeskUCAB.Servicios;
using Microsoft.Extensions.DependencyInjection;
using ModuloPlantillasNotificaciones.Servicios;
using Microsoft.AspNetCore.Authentication.Cookies;
using ServiceDeskUCAB.Servicios.ModuloCargo;
using ServiceDeskUCAB.Servicios.ModuloTipoCargo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServicioUsuario_API, ServicioUsuario_API>();

builder.Services.AddScoped<IServicioCargo_API, ServicioCargo_API>();
builder.Services.AddScoped<IServicioTipo_Cargo_API, ServicioTipo_Cargo_API>();
builder.Services.AddScoped<IServicioDepartamento_API, ServicioDepartamento_API>();
builder.Services.AddScoped<IServicioPlantillaNotificacion_API, ServicioPlantillaNotificacion_API>();
builder.Services.AddScoped<IServicioTipoEstado_API, ServicioTipoEstado_API>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
         .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, cookieAuthOptions =>
         {
             cookieAuthOptions.Cookie.Name = "MyApplicationCookie";
             cookieAuthOptions.LoginPath = "/Login/Login";
             //cookieAuthOptions.LogoutPath = "/signOut";
             cookieAuthOptions.AccessDeniedPath = "/Home/Index";
         });
builder.Services.AddScoped<IServicioGrupo_API, ServicioGrupo_API>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClienteAccess",
         policy => policy.RequireAssertion(c=> c.User.Identities.First().Claims.ToList()[2].Value=="Cliente"));

    options.AddPolicy("AdminAccess",
         policy => policy.RequireAssertion(c => c.User.Identities.First().Claims.ToList()[2].Value == "Administrador"));

    options.AddPolicy("EmpleadoAccess",
         policy => policy.RequireAssertion(c => c.User.Identities.First().Claims.ToList()[2].Value == "Empleado"));
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
