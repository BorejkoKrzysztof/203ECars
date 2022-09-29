namespace _2035Cars_Application.Interfaces
{
    public interface IRentalService
    {
        Task<List<string>> GetRentalCities();
        Task<List<string>> GetRentalLocations(string city);
    }
}