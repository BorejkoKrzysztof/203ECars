using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Infrastructure.Database.Seeder
{
    public static class SeederExtension
    {
        public static IApplicationBuilder SeedExtension(this IApplicationBuilder app, string webPath)
        {

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<CarDbContext>();
            
            using var transaction = context.Database.BeginTransaction();

            if(!context.Rentals.Any() && !context.Cars.Any() && !context.Employees.Any())
            {
                var seeder = new Seeder(context, webPath);
                seeder.SeedRentals();
            }

            if (!context.Clients.Any())
            {
                var seeder = new Seeder(context, webPath);
                seeder.SeedClients();
            }

            transaction.Commit();

            return app;
        }
    }
}