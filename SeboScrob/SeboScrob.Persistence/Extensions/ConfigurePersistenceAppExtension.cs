using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeboScrob.Domain.Interfaces;
using SeboScrob.Persistence.Context;
using SeboScrob.Persistence.Repositories;

namespace SeboScrob.Persistence.Extensions
{
    public static class ConfigurePersistenceAppExtension
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Sqlite");
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("SeboScrob.WebAPI")));
            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
