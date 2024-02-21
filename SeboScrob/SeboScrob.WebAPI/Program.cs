using SeboScrob.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using SeboScrob.WebAPI.Extensions;
using SeboScrob.Persistence.Extensions;
using AutoMapper;
using System.Reflection;
using SeboScrob.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
            builder.Services.JWTBearerConfiguration();

            builder.Environment.IsDevelopment();
            //builder.Environment.IsProduction();

            builder.Services.AddCors();
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

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
            });

            if (app.Environment.IsProduction())
            {
                app.UseAuthentication();
                app.UseAuthorization();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
