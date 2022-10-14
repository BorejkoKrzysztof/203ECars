using System.Reflection;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database.Seeder.Data;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Database.Seeder
{
    public class Seeder
    {
        public Seeder(CarDbContext dbContext, string wwwrootPath)
        {
            this._dbContext = dbContext;
            this._wwwRootPath = wwwrootPath;
        }

        private readonly CarDbContext _dbContext;
        private readonly string _wwwRootPath;



        public void SeedRentals()
        {
            _dbContext.Database.EnsureCreated();

            if (!_dbContext.Rentals.Any() &&
                !_dbContext.Cars.Any() &&
                !_dbContext.Employees.Any())
            {
                var rentalSeeder = new RentalData(this._wwwRootPath);

                _dbContext.Rentals.AddRange(rentalSeeder.GetRentals());
                _dbContext.SaveChanges();
            }
        }

        public void SeedClients()
        {
            this._dbContext.Database.EnsureCreated();

            if (!_dbContext.Clients.Any())
            {
                var carSeeder = new ClientsData();

                _dbContext.Clients.AddRange(carSeeder.GetClients());
                _dbContext.SaveChanges();
            }
        }

        public void SeedOrders()
        {
            this._dbContext.Database.EnsureCreated();

            if (!_dbContext.Orders.Any())
            {
                var rentals = this._dbContext.Rentals.Include(x => x.Cars)
                                                     .Include(x => x.Employees)
                                                     .ToList();

                var clients = this._dbContext.Clients.ToList();

                var orderSeeder = new OrderData(rentals, clients);

                this._dbContext.Orders.AddRange(orderSeeder.GetOrders());
                this._dbContext.SaveChanges();

                this._dbContext.Rentals.UpdateRange(rentals);
                this._dbContext.SaveChanges();

                this._dbContext.Clients.UpdateRange(clients);
                this._dbContext.SaveChanges();
            }
        }
    }
}