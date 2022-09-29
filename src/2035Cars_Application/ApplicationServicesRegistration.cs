using _2035Cars_Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace _2035Cars_Application
 {
     public static class ApplicationServicesRegistration
     {
         public static IServiceCollection AddApplicationServices(this IServiceCollection services)
         {
            services.AddScoped<IRentalService, RentalService>();

             return services;
         }
     }
}