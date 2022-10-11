using _2035Cars_Core.Domain;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface IRentalRepository : IRepositoryBase<Rental>
    {
        Task<List<string>> ReadAllRentalCitiesAsync();

        Task<List<string>> ReadAllLocationsByCityAsync(string rentalCity);

        Task<object> GetRentalByCityAndLocationAsync(string city,string location);

        Task<long> ReturnRentalIdAsync(string city, string location);
    }
}