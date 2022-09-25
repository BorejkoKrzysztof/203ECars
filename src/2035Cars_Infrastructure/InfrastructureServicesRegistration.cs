using _2035Cars_Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _2035Cars_Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("LocalConnectionString"));
            });

            return services;
        }
    }
}