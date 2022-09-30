namespace _2035Cars_Application.Interfaces
{
    public interface IRentalService
    {
        Task<List<string>> GetRentalCitiesAsync();
        Task<List<string>> GetRentalLocationsAsync(string city);
    }
}