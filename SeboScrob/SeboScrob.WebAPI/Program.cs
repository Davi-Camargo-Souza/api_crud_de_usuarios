using SeboScrob.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SeboScrob.WebAPI.Extensions;
using SeboScrob.Persistence.Extensions;
using AutoMapper;
using System.Reflection;

namespace SeboScrob.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.;
            builder.Services.ConfigureApplicationApp();
            builder.Services.ConfigurePersistenceApp(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
