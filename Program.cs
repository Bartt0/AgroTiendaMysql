using Microsoft.EntityFrameworkCore; // Entity Framework
using Pomelo.EntityFrameworkCore.MySql; // MySQL EF Core Provider
using Agrotienda_2.data; // Tu DbContext
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configuración de DbContext para MySQL
builder.Services.AddDbContext<Creador_de_TablasContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(9, 0, 0)))); // Versión MySQL 9.0.0

// Agregar servicios necesarios para la aplicación
builder.Services.AddControllers();  // Añadir soporte para controladores API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Habilitar Swagger para documentación de API

var app = builder.Build();

// Configuración de la tubería de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilitar Swagger solo en el entorno de desarrollo
    app.UseSwaggerUI(); // Interfaz gráfica de Swagger
}

// Asegurarse de redirigir todas las solicitudes HTTP a HTTPS
app.UseHttpsRedirection();

// Registrar las rutas de los controladores
app.MapControllers(); 

// Definir una ruta simple de ejemplo (opcional)
app.MapGet("/", () => "¡Bienvenido a AgroTienda!");

// Si necesitas una ruta adicional para el clima (como ejemplo), la puedes dejar aquí
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run(); // Iniciar la aplicación

// Definir la estructura de WeatherForecast (ejemplo de modelo de datos)
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556); // Convertir de Celsius a Fahrenheit
}
