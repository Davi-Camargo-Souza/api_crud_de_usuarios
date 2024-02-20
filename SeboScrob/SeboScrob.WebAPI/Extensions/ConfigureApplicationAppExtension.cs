using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SeboScrob.WebAPI.DTOs.Requests.User;
using SeboScrob.WebAPI.Mappers;
using SeboScrob.WebAPI.Shared.Behavior;
using System.Reflection;

namespace SeboScrob.WebAPI.Extensions
{
    public static class ConfigureApplicationAppExtension
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
