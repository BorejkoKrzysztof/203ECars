using _2035Cars_Application.DTO;

namespace _2035Cars_Application.Interfaces
{
    public interface IRentalService
    {
        Task<List<string>> GetRentalCitiesAsync();
        Task<List<string>> GetRentalLocationsAsync(string city);
        Task<RentalBasicInfo> GetRentalInfo(string city, string location);
        Task<List<string>> GetRentalCitiesWithTitles();
    }
}