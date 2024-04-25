using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using personaapi_dotnet.Context;
using personaapi_dotnet.DAO;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Registrar servicio para la conexión de base de datos con Entity Framework Core y SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar DAO con su implementación utilizando AddScoped
builder.Services.AddScoped<IPersonaDAO, PersonaDAO>();
builder.Services.AddScoped<IProfesionDAO, ProfesionDAO>();
builder.Services.AddScoped<IEstudioDAO, EstudioDAO>();
builder.Services.AddScoped<ITelefonoDAO, TelefonoDAO>();



// Agregar servicios de controladores
builder.Services.AddControllers();

// Agregar servicios para MVC (controladores y vistas)
builder.Services.AddControllersWithViews();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "Descripción de mi API",
        Contact = new OpenApiContact
        {
            Name = "Tu nombre",
            Email = "tu.email@dominio.com"
        }
    });
});

// Construir la aplicación
var app = builder.Build();

// Configurar el middleware
if (app.Environment.IsDevelopment())
{
    // Configurar Swagger y SwaggerUI solo en entornos de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    });
}
else
{
    // Configurar un controlador de excepciones para entornos de producción
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Habilitar redirección a HTTPS
app.UseHttpsRedirection();

// Configurar manejo de archivos estáticos
app.UseStaticFiles();

// Configurar enrutamiento
app.UseRouting();

// Habilitar autorización
app.UseAuthorization();

// Mapear rutas de controladores
app.MapControllers();

// Configurar las rutas de la aplicación
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ejecutar la aplicación
app.Run();
