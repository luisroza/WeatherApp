using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WeatherApp.Business.Data;
using WeatherApp.Business.Interfaces;
using WeatherApp.Business.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WeatherForecast API",
        Description = "Temperature, Humidity percentage, Rainfall percentage and WeatherForecast",
        Contact = new OpenApiContact
        {
            Name = "Luis Mauricio Roza",
            Email = "roza.mauricio@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/mauricioroza/"),
        }
    });
});

builder.Services.AddScoped<ITemperatureService, TemperatureService>();
builder.Services.AddScoped<IHumidityService, HumidityService>();
builder.Services.AddScoped<IRainfallService, RainfallService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

var app = builder.Build();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherForecast API V1");
});

app.UseApiVersioning();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
