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

            bool rentalsExists = context.Rentals.Any();
            bool carsExists = context.Cars.Any();
            bool employeesExists = context.Employees.Any();
            bool clientsExists = context.Clients.Any();
            bool ordersExists = context.Orders.Any();

            if(!rentalsExists && !carsExists && !employeesExists
                ||  !clientsExists
                ||  !ordersExists )
            {
                using var transaction = context.Database.BeginTransaction();

                try
                {
                    if (!rentalsExists && !carsExists && !employeesExists)
                    {
                        var seeder = new Seeder(context, webPath);
                        seeder.SeedRentals();
                    }

                    if (!clientsExists)
                    {
                        var seeder = new Seeder(context, webPath);
                        seeder.SeedClients();
                    }

                    if (!ordersExists)
                    {
                        var seeder = new Seeder(context, webPath);
                        seeder.SeedOrders();
                    }

                    transaction.Commit();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"ERROR: {ex.Message}");
                    throw;
                }
            }

            return app;
        }
    }
}