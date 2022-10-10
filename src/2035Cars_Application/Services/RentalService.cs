using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;
        private readonly ILogger<RentalService> _logger;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository repository, ILogger<RentalService> logger, IMapper mapper)
        {
            this._repository = repository;
            this._logger = logger;
            this._mapper = mapper;
        }
        public async Task<List<string>> GetRentalCitiesAsync()
        {
            List<string> rentalCities;
            try
            {
                rentalCities = await this._repository.ReadAllRentalCitiesAsync();
                this._logger.LogInformation("List of rental cities is downloaded");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to download list of rental cities - Exception: {ex.Message}");
                return null!;
            }

            return rentalCities;
        }

        public async Task<RentalBasicInfo> GetRentalInfo(string city, string location)
        {
            if (string.IsNullOrEmpty(city))
            {
                this._logger.LogError(nameof(city), "City parameter is null or empty string");
                throw new ArgumentNullException(nameof(city), "City parameter is null or empty string");
            }

            if (string.IsNullOrEmpty(location))
            {
                this._logger.LogError(nameof(location), "location parameter is null or empty string");
                throw new ArgumentNullException(nameof(location), "location parameter is null or empty string");
            }

            RentalBasicInfo rentalInfo;
            try
            {
                rentalInfo = (RentalBasicInfo) 
                    await this._repository.GetRentalByCityAndLocationAsync(city, location);
                this._logger.LogInformation($"RentalBasicInfo with city {city} and location {location} is downloaded");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to download rentalBasicInfo - Exception: {ex.Message}");
                return null!;
            }

            return rentalInfo;
        }

        public async Task<List<string>> GetRentalLocationsAsync(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                this._logger.LogError(nameof(city), "City parameter is null or empty string");
                throw new ArgumentNullException(nameof(city), "City parameter is null or empty string");
            }
            
            List<string> rentalLocations;

            try
            {
                rentalLocations = await this._repository.ReadAllLocationsByCityAsync(city);
                this._logger.LogInformation("List of rental locations is downloaded");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to download list of rental locations - Exception: {ex.Message}");
                return null!;
            }

            return rentalLocations;
        }
    }
}