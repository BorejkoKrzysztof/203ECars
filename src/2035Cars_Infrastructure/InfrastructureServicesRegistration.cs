using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using _2035Cars_Infrastructure.Repositories;
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

            services.AddScoped<IRentalRepository, RentalRepository>();

            return services;
        }
    }
}