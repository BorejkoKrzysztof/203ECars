using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Core.Domain;
using _2035Cars_Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CarService> _logger;

        public CarService(ICarRepository repository, IMapper mapper, ILogger<CarService> logger)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._logger = logger;
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
                result.amountOfHours = hours;

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

                cars.ForEach(x => x.PriceForOneHour = x.PriceForOneHour * (decimal)hours);
                result.cars = this._mapper.Map<List<CarDTO>>(cars);
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
                result.amountOfHours = hours;
                cars.ForEach(x => x.PriceForOneHour = x.PriceForOneHour * (decimal)hours);

                result.cars = this._mapper.Map<List<CarDTO>>(cars);

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
    }
}