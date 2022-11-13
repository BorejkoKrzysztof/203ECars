using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Application.ViewModels;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CarService> _logger;

        public CarService(ICarRepository repository, IRentalRepository rentalRepository,
                                IMapper mapper, ILogger<CarService> logger)
        {
            this._repository = repository;
            this._rentalRepository = rentalRepository;
            this._mapper = mapper;
            this._logger = logger;
        }

        public async Task<bool> AddCarToRental(CreateCarCommand command)
        {
            var result = false;

            try
            {
                var rental = await this._rentalRepository.ReadByIDAsync(command.RentalId);
                this._logger.LogInformation($"In order to add a Car Rental with Id: {command.RentalId} is downloaded");
                var carToAdd = new Car()
                {
                    Brand = command.Brand,
                    Model = command.Model,
                    CarType = (CarType)command.CarType,
                    Equipment = new CarEquipment(command.HasAirConditioning, command.HasHeatingSeats, command.HasAutomaticGearBox, command.HasBuildInNavigation),
                    DriveType = (DriveOfCar)command.DriveType,
                    AmountOfDoor = command.AmountOfDoor,
                    AmountOfSeats = command.AmountOfSeats,
                    PriceForOneHour = command.PriceForHour,
                    IsRented = false,
                    Image = await ConvertImageToByteArray(command.Image),
                    Rental = rental,
                    RentalId = rental.Id,
                    CreatedDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                };
                this._logger.LogInformation("New Car to add is created");
                long id = await this._repository.CreateAsync(carToAdd);
                this._logger.LogInformation($"New Car ({command.Brand}) ({command.Model}) is added to Rental with id: {rental.Id}");
                result = true;
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Error occurred while adding a Car for Rental with id: {command.RentalId}, error MSG => {ex.Message}");
                return await Task.FromResult(false);
            }

            return result;
        }

        public async Task<CarsCollectionWithPagination> GetAllCarsAsync(int pageNumber, int pageSize)
        {
            CarsCollectionWithPagination result = new CarsCollectionWithPagination();

            try
            {
                var cars = await this._repository.GetAllCarsPaginationAsync(pageNumber, pageSize);
                this._logger.LogInformation($"List Of All Cars (Pagination) is downloaded");
                result.amountOfHours = 1;
                result.cars = this._mapper.Map<List<CarDTO>>(cars);

                result.carMinPrice = await this._repository.MinPriceCollectionOfCarsAllCars(1d);
                result.carMaxPrice = await this._repository.MaxPriceCollectionOfCarsAllCars(1d);
                this._logger.LogInformation("Min and Max price for all cars is downloaded");

                result.amountOfPages = await this._repository.CountAllCarsAsync() / pageSize;
                this._logger.LogInformation($"Amount of pages for List Of All Cars (Pagination) is downloaded");
                result.currentPage = pageNumber;
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Unable to read List Of All Cars (Pagination) => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<CarsCollectionWithPagination> GetCarsByLocationAndEquipmentAsync(int pageNumber, int pageSize, GetCarsByEquipmentCommand command)
        {
            CarsCollectionWithPagination result = new CarsCollectionWithPagination();

            try
            {
                var hours = (command.DateTimeTo.ToUniversalTime()
                                        - command.DateTimeFrom.ToUniversalTime()).TotalHours;

                if (hours == 0)
                    hours = 1;
                result.amountOfHours = Math.Round(hours, 2);

                var cars = await this._repository
                                .GetCarsByLocationAndEquipmentAsync
                                (pageNumber, pageSize,
                                    command.CityFrom, command.LocationFrom,
                                    command.MinPrice, command.MaxPrice,
                                    command.DesiredSuv, command.DesiredSedan,
                                    command.DesiredSport, command.DesiredCompact,
                                    command.DesiredAirConditioning, command.DesiredHeatingSeats,
                                    command.DesiredAutomaticGearBox, command.DesiredBuildInNavigation,
                                    command.DesiredHybridDrive, command.DesiredElectricDrive,
                                    command.AmountOfDoors, command.AmountOfSeats, hours);

                this._logger.LogInformation("List Of Car by Location and Equipment is donwloaded");

                cars.ForEach(x => x.PriceForOneHour =
                                Math.Round(x.PriceForOneHour = x.PriceForOneHour * (decimal)hours, 2));
                result.cars = this._mapper.Map<List<CarDTO>>(cars);
                result.carMinPrice = await this._repository.MinPriceCollectionOfCarsByLocationAndEquipment
                                                                            (
                                                                                command.CityFrom, command.LocationFrom,
                                                                                command.MinPrice, command.MaxPrice,
                                                                                command.DesiredSuv, command.DesiredSedan,
                                                                                command.DesiredSport, command.DesiredCompact,
                                                                                command.DesiredAirConditioning, command.DesiredHeatingSeats,
                                                                                command.DesiredAutomaticGearBox, command.DesiredBuildInNavigation,
                                                                                command.DesiredHybridDrive, command.DesiredElectricDrive,
                                                                                command.AmountOfDoors, command.AmountOfSeats, hours
                                                                            ) * (decimal)hours;
                result.carMaxPrice = await this._repository.MaxPriceCollectionOfCarsByLocationAndEquipment
                                                                            (
                                                                                command.CityFrom, command.LocationFrom,
                                                                                command.MinPrice, command.MaxPrice,
                                                                                command.DesiredSuv, command.DesiredSedan,
                                                                                command.DesiredSport, command.DesiredCompact,
                                                                                command.DesiredAirConditioning, command.DesiredHeatingSeats,
                                                                                command.DesiredAutomaticGearBox, command.DesiredBuildInNavigation,
                                                                                command.DesiredHybridDrive, command.DesiredElectricDrive,
                                                                                command.AmountOfDoors, command.AmountOfSeats, hours
                                                                            ) * (decimal)hours;
                this._logger.LogInformation("Min and max price for cars by location and equipment is downloaded");
                result.currentPage = pageNumber;
                result.amountOfPages = await this._repository
                                            .CountAllCarsByLocationAndEquimentAsync
                                                (
                                                    command.CityFrom, command.LocationFrom,
                                                    command.MinPrice, command.MaxPrice,
                                                    command.DesiredSuv, command.DesiredSedan,
                                                    command.DesiredSport, command.DesiredCompact,
                                                    command.DesiredAirConditioning, command.DesiredHeatingSeats,
                                                    command.DesiredAutomaticGearBox, command.DesiredBuildInNavigation,
                                                    command.DesiredHybridDrive, command.DesiredElectricDrive,
                                                    command.AmountOfDoors, command.AmountOfSeats, hours
                                                ) / pageSize;

            }
            catch (Exception ex)
            {
                this._logger.LogError($"Unable to read List Of Cars by Location and Car Equipment, error => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<CarsCollectionWithPagination> GetCarsByTypeAsync
                                (int pageNumber, int pageSize, CarsByTypeCommand command)
        {
            CarsCollectionWithPagination result = new CarsCollectionWithPagination();

            try
            {
                var cars =
                await this._repository.GetCarsByTypeAsync
                                            (pageNumber, pageSize,
                                                command.DesiredCompactType,
                                                command.DesiredSedanType,
                                                command.DesiredSportType,
                                                command.DesiredSuvType);
                this._logger.LogInformation("List of Cars by type is downloaded");
                result.amountOfHours = 1;
                result.cars = this._mapper.Map<List<CarDTO>>(cars);
                result.carMinPrice = await this._repository.MinPriceCollectionCarsByCarType
                                                                                        (
                                                                                            command.DesiredCompactType,
                                                                                            command.DesiredSedanType,
                                                                                            command.DesiredSportType,
                                                                                            command.DesiredSuvType,
                                                                                            1d
                                                                                        );
                result.carMaxPrice = await this._repository.MaxPriceCollectionCarsByCarType
                                                                                        (
                                                                                            command.DesiredCompactType,
                                                                                            command.DesiredSedanType,
                                                                                            command.DesiredSportType,
                                                                                            command.DesiredSuvType,
                                                                                            1d
                                                                                        );
                this._logger.LogInformation("Min and max prices for cars by car type is downlaoded");
                result.currentPage = pageNumber;
                result.amountOfPages = await this._repository
                        .CountListOfCarsByTypeAsync(command.DesiredCompactType,
                                                command.DesiredSedanType,
                                                command.DesiredSportType,
                                                command.DesiredSuvType) / pageSize;
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Unable to read List Of Cars by body type => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<CarsCollectionWithPaginationBasic> GetCarsForRental(long rentalId,
                                                                        int currentPage,
                                                                        int adminPageSize)
        {
            var result = new CarsCollectionWithPaginationBasic();

            try
            {
                result.currentPage = currentPage;
                List<Car> carsCollection = await this._repository.GetCarsForRental
                                                            (rentalId, currentPage, adminPageSize);
                this._logger.LogInformation($"Cars for rental with id: {rentalId} are downloaded.");
                result.cars = this._mapper.Map<List<CarDTO>>(carsCollection);
                this._logger.LogInformation($"Cars for rental with id: {rentalId} are mapped.");
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Error occured while downloading cars for rental with id: {rentalId}, error msg => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalCityAndLocation
                                                            (string city,
                                                            string location,
                                                            PreferableCarFeaturesSearchWithLocationCommand carFeatures,
                                                            int pageNumber,
                                                            int pageSize)
        {
            CarsCollectionWithPagination result = new CarsCollectionWithPagination();

            try
            {
                var cars = await this._repository
                                 .GetAllSelectedCarsByCityAndLocationAsync
                                     (
                                         city,
                                         location,
                                         carFeatures.AvailableFrom,
                                         carFeatures.DesiredSuvType,
                                         carFeatures.DesiredSportType,
                                         carFeatures.DesiredCompactType,
                                         carFeatures.DesiredSedanType,
                                         carFeatures.DesiredAirCooling,
                                         carFeatures.DesiredHeatingSeats,
                                         carFeatures.DesiredAutomaticGearBox,
                                         carFeatures.DesiredBuildInNavigation,
                                         carFeatures.DesiredHybridDrive,
                                         carFeatures.DesiredElectricDrive,
                                         pageNumber,
                                         pageSize
                                     );


                this._logger.LogInformation($"List Of Cars for rental in {city}, {location} is downloaded");

                // Count Total Price For Renting
                var hours = (carFeatures.OrderTo.ToUniversalTime()
                                        - carFeatures.AvailableFrom.ToUniversalTime()).TotalHours;
                result.amountOfHours = Math.Round(hours, 2);
                cars.ForEach(x => x.PriceForOneHour =
                                Math.Round(x.PriceForOneHour = x.PriceForOneHour * (decimal)hours, 2));

                result.cars = this._mapper.Map<List<CarDTO>>(cars);

                result.carMinPrice = await this._repository.MinPriceCollectionOfCarsByCityAndLocation
                                                                                        (
                                                                                            city,
                                                                                            location,
                                                                                            carFeatures.AvailableFrom,
                                                                                            carFeatures.DesiredSuvType,
                                                                                            carFeatures.DesiredSportType,
                                                                                            carFeatures.DesiredCompactType,
                                                                                            carFeatures.DesiredSedanType,
                                                                                            carFeatures.DesiredAirCooling,
                                                                                            carFeatures.DesiredHeatingSeats,
                                                                                            carFeatures.DesiredAutomaticGearBox,
                                                                                            carFeatures.DesiredBuildInNavigation,
                                                                                            carFeatures.DesiredHybridDrive,
                                                                                            carFeatures.DesiredElectricDrive,
                                                                                            hours
                                                                                        ) * (decimal)hours;
                result.carMaxPrice = await this._repository.MaxPriceCollectionOfCarsByCityAndLocation
                                                                                        (
                                                                                            city,
                                                                                            location,
                                                                                            carFeatures.AvailableFrom,
                                                                                            carFeatures.DesiredSuvType,
                                                                                            carFeatures.DesiredSportType,
                                                                                            carFeatures.DesiredCompactType,
                                                                                            carFeatures.DesiredSedanType,
                                                                                            carFeatures.DesiredAirCooling,
                                                                                            carFeatures.DesiredHeatingSeats,
                                                                                            carFeatures.DesiredAutomaticGearBox,
                                                                                            carFeatures.DesiredBuildInNavigation,
                                                                                            carFeatures.DesiredHybridDrive,
                                                                                            carFeatures.DesiredElectricDrive,
                                                                                            hours
                                                                                        ) * (decimal)hours;

                this._logger.LogInformation("Min and max prices for cars by city and location is downloaded");


                result.amountOfPages = await this._repository.CountAllSelectedCarsByCityAndLocationAsync
                                        (
                                            city,
                                            location,
                                            carFeatures.AvailableFrom,
                                            carFeatures.DesiredSuvType,
                                            carFeatures.DesiredSportType,
                                            carFeatures.DesiredCompactType,
                                            carFeatures.DesiredSedanType,
                                            carFeatures.DesiredAirCooling,
                                            carFeatures.DesiredHeatingSeats,
                                            carFeatures.DesiredAutomaticGearBox,
                                            carFeatures.DesiredBuildInNavigation,
                                            carFeatures.DesiredHybridDrive,
                                            carFeatures.DesiredElectricDrive
                                        ) / pageSize;

                this._logger.LogInformation($"Amount of pages for List Of Cars for rental in {city}, {location} is downloaded");

                result.currentPage = pageNumber;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Unable to read List Of Cars with specific features => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<byte[]> GetImageForCarById(long carId)
        {
            byte[] imageResult = null!;

            try
            {
                imageResult = await this._repository.GetCarImageByIdAsync(carId);
                this._logger.LogInformation($"Image for Car with Id equals {carId} is downloaded");
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Unable to download car image with id equals {carId}, error => {ex.Message}");
                return null!;
            }

            return imageResult;
        }

        public async Task<CarDetailsDTO> ReadCarByIdAsync(long carId)
        {
            CarDetailsDTO result = new CarDetailsDTO();

            try
            {
                result = this._mapper.Map<CarDetailsDTO>(await this._repository.ReadByIDAsync(carId));
                this._logger.LogInformation($"Car info for car with id: {carId} is downloaded");
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Error occured while downloading car data's, error msg => {ex.Message}");
                return null!;
            }

            return result;
        }

        public async Task<bool> RemoveCarAsync(long carId)
        {
            bool result = false;

            try
            {
                var carToDelete = await this._repository.ReadByIDAsync(carId);
                this._logger.LogInformation($"Car with id: {carId} is downloaded.");
                await this._repository.DeleteAsync(carToDelete);
                this._logger.LogInformation($"Car with id: {carId} is removed.");
                result = true;
            }
            catch (System.Exception ex)
            {
                this._logger.LogError($"Error while removing Car with id: {carId}, MSG => {ex.Message}");
                return await Task.FromResult(false);
            }

            return result;
        }

        private async Task<byte[]> ConvertImageToByteArray(IFormFile imgFile)
        {
            if (imgFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    imgFile.CopyTo(ms);
                    var byteArrayImg = ms.ToArray();

                    return await Task.FromResult(byteArrayImg);
                }
            }

            return await Task.FromResult(new byte[0]);
        }
    }
}