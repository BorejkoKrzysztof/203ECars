using System.Reflection;
using _2035Cars_Application.Interfaces;
using _2035Cars_Application.Mapping;
using _2035Cars_Application.Services;
using _2035Cars_Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _2035Cars_Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton(RentalProfile.Initialize());
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}