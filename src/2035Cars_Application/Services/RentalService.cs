using _2035Cars_Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Interfaces
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<string>> GetRentalCities()
        {
            return await this._repository.ReadAllRentalCitiesAsync();
        }

        public async Task<List<string>> GetRentalLocations(string city)
        {
            return await this._repository.ReadAllLocationsByCityAsync(city);
        }
    }
}