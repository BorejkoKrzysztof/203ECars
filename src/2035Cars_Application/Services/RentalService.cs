using _2035Cars_Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Interfaces
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;
        private readonly ILogger<RentalService> _logger;

        public RentalService(IRentalRepository repository, ILogger<RentalService> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }
        public async Task<List<string>> GetRentalCities()
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

        public async Task<List<string>> GetRentalLocations(string city)
        {
            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException(nameof(city), "City parameter is null or empty string");
            
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