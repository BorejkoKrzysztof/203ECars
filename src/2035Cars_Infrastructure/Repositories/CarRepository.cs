using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Car>> GetAllNotRentedCarsByRentalLoactionAsync
                            (string city, string rentalTitle, int pageNumber = 1, int pageSize = 5)
        {
            var cars = this._dbContext.Rentals
            .First(x => string.Equals(x.Address.City, city) && string.Equals(x.Title, rentalTitle))
            .Cars
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return await Task.FromResult(cars);
        }

        public async Task<List<Car>> GetAllCarsByCarTypeAsync
                                        (CarType carType, int pageNumber = 1, int pageSize = 5)
        {
            return await this._dbContext.Cars
                                        .Where(x => x.CarType == carType)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        }
    }
}