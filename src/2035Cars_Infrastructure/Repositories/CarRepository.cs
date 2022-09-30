using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
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
            .Where(x => !x.IsRented)
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

        public async Task<List<Car>> GetAllSelectedCarsAsync(string city, string rentalTitle,
                                                    CarEquipment desiredCarEquipment, int fuelTypeOption = 0,
                                                    int carBodyOption = 0, int pageNumber = 0,
                                                    int pageSize = 5, decimal minPrice = 0,
                                                    decimal maxPrice =  0, int amountOfDoor = 0,
                                                    int amountOfSeats = 0)
        {
            IQueryable<Car> cars = this._dbContext.Cars
                                .Where(x => string.Equals(x.Rental.Address.City, city) &&
                                            string.Equals(x.Rental.Title, rentalTitle) &&
                                            CarEquipment.ComparePreferableOptions(desiredCarEquipment, x.Equipment));

            if (carBodyOption > 0)
                cars.Where(x => x.CarType == (CarType)carBodyOption);
                
            if (fuelTypeOption > 0)
                cars.Where(x => x.DriveType == (DriveOfCar)fuelTypeOption);

            if (minPrice > 0)
                cars.Where(x => minPrice >= x.PriceForOneHour);

            if (maxPrice != 0)
                cars.Where(x => maxPrice <= x.PriceForOneHour);

            if (amountOfDoor != 0)
                cars.Where(x => x.AmountOfDoor == amountOfDoor);

            if (amountOfSeats != 0)
                cars.Where(x => x.AmountOfSeats == amountOfSeats);


            return await cars.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}