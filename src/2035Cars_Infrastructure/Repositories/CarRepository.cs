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

        public async Task<List<Car>> GetAllSelectedCarsByCityAndLocationAsync
                                                            (string city, 
                                                            string rentalTitle, 
                                                            DateTime availableFrom, 
                                                            bool desiredSuvtype, 
                                                            bool desiredSporttype, 
                                                            bool desiredConvertibletype, 
                                                            bool desiredSedantype, 
                                                            bool hasAirCooling, 
                                                            bool hasHeatingSeats, 
                                                            bool hasAutomaticGearBox, 
                                                            bool hasBuildInNavigation, 
                                                            bool hasHybridDrive, 
                                                            bool hasElectricDrive, 
                                                            int pageNumber, 
                                                            int pageSize, 
                                                            decimal minPrice, 
                                                            decimal maxPrice, 
                                                            int amountOfDoor, 
                                                            int amountOfSeats)
        {
            var halfFilteredCarsCollection = await this.FilterCarsByForm
                                                            (availableFrom,
                                                            desiredSuvtype,
                                                            desiredSporttype,
                                                            desiredConvertibletype,
                                                            desiredSedantype,
                                                            hasAirCooling,
                                                            hasAirCooling,
                                                            hasAutomaticGearBox,
                                                            hasBuildInNavigation,
                                                            hasHybridDrive,
                                                            hasElectricDrive,
                                                            minPrice,
                                                            maxPrice,
                                                            amountOfDoor,
                                                            amountOfSeats);

            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection
                                    .Where(x => x.Rental.Address.City == city);

            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection
                                    .Where(x => x.Rental.Title == rentalTitle);

            // Order by ascending
            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection.OrderBy(x => x.PriceForOneHour);

            return await halfFilteredCarsCollection
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        }

        public async Task<int> CountAllSelectedCarsByCityAndLocationAsync(string city, string rentalTitle, DateTime availableFrom, bool desiredSuvtype, bool desiredSporttype, bool desiredConvertibletype, bool desiredSedantype, bool hasAirCooling, bool hasHeatingSeats, bool hasAutomaticGearBox, bool hasBuildInNavigation, bool hasHybridDrive, bool hasElectricDrive, decimal minPrice, decimal maxPrice, int amountOfDoor, int amountOfSeats)
        {
            var halfFilteredCarsCollection = await this.FilterCarsByForm
                                                            (availableFrom,
                                                            desiredSuvtype,
                                                            desiredSporttype,
                                                            desiredConvertibletype,
                                                            desiredSedantype,
                                                            hasAirCooling,
                                                            hasAirCooling,
                                                            hasAutomaticGearBox,
                                                            hasBuildInNavigation,
                                                            hasHybridDrive,
                                                            hasElectricDrive,
                                                            minPrice,
                                                            maxPrice,
                                                            amountOfDoor,
                                                            amountOfSeats);

            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection
                                    .Where(x => x.Rental.Address.City == city);

            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection
                                    .Where(x => x.Rental.Title == rentalTitle);

            return await halfFilteredCarsCollection.CountAsync();
        }

        public async Task<List<Car>> GetAllSelectedCarsByRentalIdAsync(long rentalId, DateTime availableFrom, bool desiredSuvtype, bool desiredSporttype, bool desiredConvertibletype, bool desiredSedantype, bool hasAirCooling, bool hasHeatingSeats, bool hasAutomaticGearBox, bool hasBuildInNavigation, bool hasHybridDrive, bool hasElectricDrive, int pageNumber, int pageSize, decimal minPrice, decimal maxPrice, int amountOfDoor, int amountOfSeats)
        {
            var halfFilteredCarsCollection = await this.FilterCarsByForm
                                                            (availableFrom,
                                                            desiredSuvtype,
                                                            desiredSporttype,
                                                            desiredConvertibletype,
                                                            desiredSedantype,
                                                            hasAirCooling,
                                                            hasAirCooling,
                                                            hasAutomaticGearBox,
                                                            hasBuildInNavigation,
                                                            hasHybridDrive,
                                                            hasElectricDrive,
                                                            minPrice,
                                                            maxPrice,
                                                            amountOfDoor,
                                                            amountOfSeats);

            halfFilteredCarsCollection = 
                    halfFilteredCarsCollection.Where(x => x.RentalId == rentalId);

            // Order by ascending
            halfFilteredCarsCollection = 
                        halfFilteredCarsCollection.OrderBy(x => x.PriceForOneHour);

            return await halfFilteredCarsCollection
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        }

        public async Task<int> CountAllSelectedCarsByRentalIdAsync(long rentalId, DateTime availableFrom, bool desiredSuvtype, bool desiredSporttype, bool desiredConvertibletype, bool desiredSedantype, bool hasAirCooling, bool hasHeatingSeats, bool hasAutomaticGearBox, bool hasBuildInNavigation, bool hasHybridDrive, bool hasElectricDrive, decimal minPrice, decimal maxPrice, int amountOfDoor, int amountOfSeats)
        {
            var halfFilteredCarsCollection = await this.FilterCarsByForm
                                                            (availableFrom,
                                                            desiredSuvtype,
                                                            desiredSporttype,
                                                            desiredConvertibletype,
                                                            desiredSedantype,
                                                            hasAirCooling,
                                                            hasAirCooling,
                                                            hasAutomaticGearBox,
                                                            hasBuildInNavigation,
                                                            hasHybridDrive,
                                                            hasElectricDrive,
                                                            minPrice,
                                                            maxPrice,
                                                            amountOfDoor,
                                                            amountOfSeats);

            halfFilteredCarsCollection = 
                    halfFilteredCarsCollection.Where(x => x.RentalId == rentalId);

            return await halfFilteredCarsCollection.CountAsync();
        }

        private async Task<IQueryable<Car>> FilterCarsByForm(DateTime availableFrom,
                                                    bool desiredSuvtype,
                                                    bool desiredSporttype,
                                                    bool desiredConvertibletype,
                                                    bool desiredSedantype,
                                                    bool hasAirCooling,
                                                    bool hasHeatingSeats,
                                                    bool hasAutomaticGearBox,
                                                    bool hasBuildInNavigation,
                                                    bool hasHybridDrive,
                                                    bool hasElectricDrive,
                                                    decimal minPrice,
                                                    decimal maxPrice,
                                                    int amountOfDoor,
                                                    int amountOfSeats)
        {
            IQueryable<Car> collectionOfCars = this._dbContext.Cars;

            collectionOfCars = collectionOfCars.Where(x => x.RentedTo < availableFrom);

            // Filter by Type of Car
            if (desiredSuvtype)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.CarType == CarType.Suv);

            if (desiredSporttype)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.CarType == CarType.Sport);

            if (desiredConvertibletype)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.CarType == CarType.Convertible);

            if (desiredSedantype)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.CarType == CarType.Sedan);


            // Filter by Equipment
            if (hasAirCooling)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.Equipment.HasAirCooling);

            if (hasAutomaticGearBox)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.Equipment.HasAutomaticGearBox);

            if (hasHeatingSeats)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.Equipment.HasHeatingSeat);

            if (hasBuildInNavigation)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.Equipment.HasBuildInNavigation);


            // Filter by Type Of Fuel
            if (hasHybridDrive)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.DriveType == DriveOfCar.Hybrid);

            if (hasElectricDrive)
                collectionOfCars = 
                        collectionOfCars.Where(x => x.DriveType == DriveOfCar.Electric);


            // Filter by price
            collectionOfCars = collectionOfCars.Where(x => x.PriceForOneHour >= minPrice);
            collectionOfCars = collectionOfCars.Where(x => x.PriceForOneHour <= maxPrice);

            // Filter by amount of doors
            collectionOfCars = collectionOfCars.Where(x => x.AmountOfDoor == amountOfDoor);

            // Filter by amount of seats
            collectionOfCars = collectionOfCars.Where(x => x.AmountOfSeats == amountOfSeats);

            return await Task.FromResult(collectionOfCars);
        }
    }
}