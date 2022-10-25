using System.Linq.Expressions;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using _2035Cars_Infrastructure.Repositories.CarDriveTypeDecorator;
using _2035Cars_Infrastructure.Repositories.CarEquipmentDecorator;
using _2035Cars_Infrastructure.Repositories.CarTypeExpressionDecorator;
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
                                                            int pageSize)
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
                                                            hasElectricDrive);

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

        public async Task<int> CountAllSelectedCarsByCityAndLocationAsync(string city, string rentalTitle, DateTime availableFrom, bool desiredSuvtype, bool desiredSporttype, bool desiredConvertibletype, bool desiredSedantype, bool hasAirCooling, bool hasHeatingSeats, bool hasAutomaticGearBox, bool hasBuildInNavigation, bool hasHybridDrive, bool hasElectricDrive)
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
                                                            hasElectricDrive);

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
                                                            hasElectricDrive);
            halfFilteredCarsCollection =
                    halfFilteredCarsCollection.Include(x => x.Rental);

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
                                                            hasElectricDrive);

            halfFilteredCarsCollection =
                    halfFilteredCarsCollection.Where(x => x.RentalId == rentalId);

            return await halfFilteredCarsCollection.CountAsync();
        }

        public async Task<int> CountAllCarsAsync()
        {
            return await this._dbContext.Cars.CountAsync();
        }

        public async Task<List<Car>> GetAllCarsPaginationAsync(int pageNumber, int pageSize)
        {
            return await this._dbContext.Cars.Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToListAsync();
        }

        public async Task<List<Car>> GetCarsByTypeAsync(int pageNumber, int pageSize, bool desiredCompactType, bool desiredSedanType, bool desiredSportType, bool desiredSuvType)
        {
            IQueryable<Car> carsCollection = this._dbContext.Cars;

            if (desiredCompactType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Compact);

            if (desiredSedanType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Sedan);

            if (desiredSportType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Sport);

            if (desiredSuvType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Suv);


            return await carsCollection.Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
        }

        public async Task<int> CountListOfCarsByTypeAsync(bool desiredCompactType, bool desiredSedanType, bool desiredSportType, bool desiredSuvType)
        {
            IQueryable<Car> carsCollection = this._dbContext.Cars;

            if (desiredCompactType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Compact);

            if (desiredSedanType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Sedan);

            if (desiredSportType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Sport);

            if (desiredSuvType)
                carsCollection = carsCollection.Where(x => x.CarType == CarType.Suv);


            return await carsCollection.CountAsync();
        }

        public async Task<List<Car>> GetCarsByLocationAndEquipmentAsync
                                (int pageNumber, int pageSize,
                                        string cityFrom, string locationFrom,
                                        decimal minPrice, decimal maxPrice,
                                        bool desiredSuv, bool desiredSedan,
                                        bool desiredSport, bool desiredCompact,
                                        bool desiredAirConditioning, bool desiredHeatingSeats,
                                        bool desiredAutomaticGearBox, bool desiredBuildInNavigation,
                                        bool desiredHybridDrive, bool desiredElectricDrive,
                                        int amountOfDoors, int amountOfSeats, double hours)
        {
            IQueryable<Car> carsCollection = this._dbContext.Cars;

            if (!string.IsNullOrEmpty(cityFrom) && !string.IsNullOrEmpty(locationFrom))
                carsCollection = carsCollection.Where(x => x.Rental.Address.City == cityFrom && x.Rental.Title == locationFrom);

            // Filter by Price
            carsCollection = carsCollection.Where(x => (x.PriceForOneHour * (decimal)hours) >= minPrice);
            carsCollection = carsCollection.Where(x => (x.PriceForOneHour * (decimal)hours) <= maxPrice);

            // Filter by Car Body Type
            if (desiredSuv || desiredSedan || desiredSport || desiredCompact)
            {
                Expression<Func<Car, bool>> carTypeExpression = null!;

                if (desiredSuv)
                    carTypeExpression = new SuvCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredSedan)
                    carTypeExpression = new SedanCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredSport)
                    carTypeExpression = new SportCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredCompact)
                    carTypeExpression = new CompactCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                carsCollection = carsCollection.Where(carTypeExpression);
            }

            // Filter by Equipment
            if (desiredAirConditioning || desiredAutomaticGearBox ||
                       desiredBuildInNavigation || desiredHeatingSeats)
            {
                Expression<Func<Car, bool>> carEquipmentExpression = null!;

                if (desiredAirConditioning)
                    carEquipmentExpression =
                            new AirCoolingExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredAutomaticGearBox)
                    carEquipmentExpression =
                            new AutomaticGearBoxExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredBuildInNavigation)
                    carEquipmentExpression =
                            new BuildInNavigationExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredHeatingSeats)
                    carEquipmentExpression =
                            new HeatingSeatsExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                carsCollection = carsCollection.Where(carEquipmentExpression);
            }

            // Filter by Drive type
            if (desiredHybridDrive || desiredElectricDrive)
            {
                Expression<Func<Car, bool>> carDriveTypeExpression = null!;

                if (desiredHybridDrive)
                    carDriveTypeExpression =
                            new HybridDriveTypeExpressionDecorator(carDriveTypeExpression)
                            .GetExpression();

                if (desiredElectricDrive)
                    carDriveTypeExpression =
                            new ElectricDriveTypeExpressionDecorator(carDriveTypeExpression)
                            .GetExpression();

                carsCollection = carsCollection.Where(carDriveTypeExpression);
            }

            // Filter by Amount Of Doors
            if (amountOfDoors > 0)
                carsCollection = carsCollection.Where(x => x.AmountOfDoor == amountOfDoors);

            // Filter by Amount Of Seats
            if (amountOfSeats > 0)
                carsCollection = carsCollection.Where(x => x.AmountOfSeats == amountOfSeats);

            // Ordering Collection
            carsCollection = carsCollection.OrderBy(x => x.PriceForOneHour);

            return await carsCollection.Skip((pageNumber - 1) * pageSize)
                                                    .Take(pageSize)
                                                    .ToListAsync();
        }

        public async Task<int> CountAllCarsByLocationAndEquimentAsync(string cityFrom, string locationFrom,
                                                decimal minPrice, decimal maxPrice,
                                                bool desiredSuv, bool desiredSedan,
                                                bool desiredSport, bool desiredCompact,
                                                bool desiredAirConditioning, bool desiredHeatingSeats,
                                                bool desiredAutomaticGearBox, bool desiredBuildInNavigation,
                                                bool desiredHybridDrive, bool desiredElectricDrive,
                                                int amountOfDoors, int amountOfSeats, double hours)
        {
            IQueryable<Car> carsCollection = this._dbContext.Cars;

            if (!string.IsNullOrEmpty(cityFrom) && !string.IsNullOrEmpty(locationFrom))
                carsCollection = carsCollection.Where(x => x.Rental.Address.City == cityFrom && x.Rental.Title == locationFrom);

            // Filter by Price
            carsCollection = carsCollection.Where(x => (x.PriceForOneHour * (decimal)hours) >= minPrice);
            carsCollection = carsCollection.Where(x => (x.PriceForOneHour * (decimal)hours) <= maxPrice);

            // Filter by Car Body Type
            if (desiredSuv || desiredSedan || desiredSport || desiredCompact)
            {
                Expression<Func<Car, bool>> carTypeExpression = null!;

                if (desiredSuv)
                    carTypeExpression = new SuvCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredSedan)
                    carTypeExpression = new SedanCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredSport)
                    carTypeExpression = new SportCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                if (desiredCompact)
                    carTypeExpression = new CompactCarTypeExpressionDecorator(carTypeExpression).GetExpression();

                carsCollection = carsCollection.Where(carTypeExpression);
            }

            // Filter by Equipment
            if (desiredAirConditioning || desiredAutomaticGearBox ||
                        desiredBuildInNavigation || desiredHeatingSeats)
            {
                Expression<Func<Car, bool>> carEquipmentExpression = null!;

                if (desiredAirConditioning)
                    carEquipmentExpression =
                            new AirCoolingExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredAutomaticGearBox)
                    carEquipmentExpression =
                            new AutomaticGearBoxExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredBuildInNavigation)
                    carEquipmentExpression =
                            new BuildInNavigationExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                if (desiredHeatingSeats)
                    carEquipmentExpression =
                            new HeatingSeatsExpressionDecorator(carEquipmentExpression)
                            .GetExpression();

                carsCollection = carsCollection.Where(carEquipmentExpression);
            }

            // Filter by Drive type
            if (desiredHybridDrive || desiredElectricDrive)
            {
                Expression<Func<Car, bool>> carDriveTypeExpression = null!;

                if (desiredHybridDrive)
                    carDriveTypeExpression =
                            new HybridDriveTypeExpressionDecorator(carDriveTypeExpression)
                            .GetExpression();

                if (desiredElectricDrive)
                    carDriveTypeExpression =
                            new ElectricDriveTypeExpressionDecorator(carDriveTypeExpression)
                            .GetExpression();

                carsCollection = carsCollection.Where(carDriveTypeExpression);
            }

            // Filter by Amount Of Doors
            if (amountOfDoors > 0)
                carsCollection = carsCollection.Where(x => x.AmountOfDoor == amountOfDoors);

            // Filter by Amount Of Seats
            if (amountOfSeats > 0)
                carsCollection = carsCollection.Where(x => x.AmountOfSeats == amountOfSeats);

            return await carsCollection.CountAsync();
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
                                                    bool hasElectricDrive)
        {
            IQueryable<Car> collectionOfCars = this._dbContext.Cars
                                                    .Include(x => x.Rental);

            // var car = collectionOfCars.First();
            // List<Rental> list = this._dbContext.Rentals.ToList();
            // List<Car> list = this._dbContext.Set<Car>().ToList();
            // collectionOfCars = collectionOfCars.Where(x => !x.IsRented || 
            //                                             (x.IsRented && x.RentedTo != null && x.RentedTo < availableFrom));

            // collectionOfCars = collectionOfCars.Where(x => !x.IsRented && x.RentedTo == null ?
            //                                                     !x.IsRented : x.RentedTo < availableFrom.ToUniversalTime());

            collectionOfCars = collectionOfCars.Where(x => !x.IsRented);

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


            // // Filter by price
            // collectionOfCars = collectionOfCars.Where(x => x.PriceForOneHour >= minPrice);
            // collectionOfCars = collectionOfCars.Where(x => x.PriceForOneHour <= maxPrice);

            // // Filter by amount of doors
            // collectionOfCars = collectionOfCars.Where(x => x.AmountOfDoor == amountOfDoor);

            // // Filter by amount of seats
            // collectionOfCars = collectionOfCars.Where(x => x.AmountOfSeats == amountOfSeats);

            return await Task.FromResult(collectionOfCars);
        }
    }
}