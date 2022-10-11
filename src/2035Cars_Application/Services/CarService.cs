using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
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

        public async Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalCityAndLocation
                                                            (string city,
                                                            string location, 
                                                            PreferableCarFeaturesCommand carFeatures,
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
                                        carFeatures.desiredSuvType,
                                        carFeatures.desiredSportType,
                                        carFeatures.desiredConvertibleType,
                                        carFeatures.desiredSedanType,
                                        carFeatures.DesiredAirCooling,
                                        carFeatures.DesiredHeatingSeats,
                                        carFeatures.DesiredAutomaticGearBox,
                                        carFeatures.DesiredBuilInNavigation,
                                        carFeatures.DesiredHybridDrive,
                                        carFeatures.DesiredElectricDrive,
                                        pageNumber,
                                        pageSize,
                                        carFeatures.MinimumPrice,
                                        carFeatures.MaximumPrice,
                                        carFeatures.DesiredAmountOfDoors,
                                        carFeatures.DesiredAmountOfSeats
                                    );


                this._logger.LogInformation($"List Of Cars for rental in {city}, {location} is downloaded");

                // Count Total Price For Renting
                var hours = (carFeatures.OrderTo.ToUniversalTime() - DateTime.UtcNow).TotalHours;
                cars.ForEach(x => x.PriceForOneHour = x.PriceForOneHour * (decimal)hours);

                result.cars = this._mapper.Map<List<CarDTO>>(cars);

                result.amountOfPages = await this._repository.CountAllSelectedCarsByCityAndLocationAsync
                                        (
                                            city,
                                            location,
                                            carFeatures.AvailableFrom,
                                            carFeatures.desiredSuvType,
                                            carFeatures.desiredSportType,
                                            carFeatures.desiredConvertibleType,
                                            carFeatures.desiredSedanType,
                                            carFeatures.DesiredAirCooling,
                                            carFeatures.DesiredHeatingSeats,
                                            carFeatures.DesiredAutomaticGearBox,
                                            carFeatures.DesiredBuilInNavigation,
                                            carFeatures.DesiredHybridDrive,
                                            carFeatures.DesiredElectricDrive,
                                            carFeatures.MinimumPrice,
                                            carFeatures.MaximumPrice,
                                            carFeatures.DesiredAmountOfDoors,
                                            carFeatures.DesiredAmountOfSeats
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

        public async Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalId
                                                (long id, 
                                                PreferableCarFeaturesCommand carFeatures, 
                                                int pageNumber, 
                                                int pageSize)
        {
            CarsCollectionWithPagination result = new CarsCollectionWithPagination();

            try
            {
               var cars = await this._repository
                                .GetAllSelectedCarsByRentalIdAsync
                                    (
                                        id,
                                        carFeatures.AvailableFrom,
                                        carFeatures.desiredSuvType,
                                        carFeatures.desiredSportType,
                                        carFeatures.desiredConvertibleType,
                                        carFeatures.desiredSedanType,
                                        carFeatures.DesiredAirCooling,
                                        carFeatures.DesiredHeatingSeats,
                                        carFeatures.DesiredAutomaticGearBox,
                                        carFeatures.DesiredBuilInNavigation,
                                        carFeatures.DesiredHybridDrive,
                                        carFeatures.DesiredElectricDrive,
                                        pageNumber,
                                        pageSize,
                                        carFeatures.MinimumPrice,
                                        carFeatures.MaximumPrice,
                                        carFeatures.DesiredAmountOfDoors,
                                        carFeatures.DesiredAmountOfSeats
                                    );

                this._logger.LogInformation($"List Of Cars for rental with id: {id} is downloaded");

                result.cars = this._mapper.Map<List<CarDTO>>(cars);

                result.amountOfPages = await this._repository.CountAllSelectedCarsByRentalIdAsync
                                        (
                                            id,
                                            carFeatures.AvailableFrom,
                                            carFeatures.desiredSuvType,
                                            carFeatures.desiredSportType,
                                            carFeatures.desiredConvertibleType,
                                            carFeatures.desiredSedanType,
                                            carFeatures.DesiredAirCooling,
                                            carFeatures.DesiredHeatingSeats,
                                            carFeatures.DesiredAutomaticGearBox,
                                            carFeatures.DesiredBuilInNavigation,
                                            carFeatures.DesiredHybridDrive,
                                            carFeatures.DesiredElectricDrive,
                                            carFeatures.MinimumPrice,
                                            carFeatures.MaximumPrice,
                                            carFeatures.DesiredAmountOfDoors,
                                            carFeatures.DesiredAmountOfSeats
                                        ) / pageSize;

                this._logger.LogInformation($"Amount of pages for List Of Cars for rental with id => {id} is downloaded");

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