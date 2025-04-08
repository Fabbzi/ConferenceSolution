
using ConferenceAPI.Data;
using ConferenceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDBConnect>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"));
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            // Attendees APIs
            app.MapGet("/attendees", async (ApplicationDBConnect db) =>
                await db.Attendees.ToListAsync());
            app.MapGet("/attendees/{id}", async (ApplicationDBConnect context, int id) =>
                await context.Attendees.FindAsync(id) is Attendee attendee
            ? Results.Ok(attendee)
            : Results.NotFound());

            app.MapGet("/Test", (HttpContext HttpContext) =>
                {
                    return "HelloWorld";
                })
                .WithName("GetHello")
                .WithOpenApi();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}
