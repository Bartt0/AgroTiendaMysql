using Microsoft.EntityFrameworkCore; //En este estas usando el EntityFramework.NET 8.0//
using Pomelo.EntityFrameworkCore.MySql; //Este es tu EntityFramework//
using Agrotienda_2.data; //Este es el nombre de tu prollecto que esta en DbContext//
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



// Esto es para configurar el DbContext a Mysql//
builder.Services.AddDbContext<Creador_de_TablasContext>(Options =>
Options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
new MySqlServerVersion(new Version(9,0,0))));



// Add services to the container//
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
