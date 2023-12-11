using System.Data.Entity.Infrastructure.Interception;
using Microsoft.EntityFrameworkCore;
using RazorPages.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//ahora con esto si trabajamos sobre la base de datos
builder.Services.AddTransient<IAlumnoRepositorio, AlumnoRepositorioBD>();

//Con esto ACCEDEREMOS A JSON Y BUSCAREMOS EL connectionString, objeto de clase capaz de manipular lo que haya dentro del proyecto
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

//ahora  metemos en el sevices la base de datos
//atraves al objeto configuration de arriba llamamos al metodo GetConnectionString
builder.Services.AddDbContextPool<ColegioDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("ColegioDBConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
