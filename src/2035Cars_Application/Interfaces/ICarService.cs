using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;

namespace _2035Cars_Application.Interfaces
{
    public interface ICarService
    {
        Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalCityAndLocation
                                                            (string city, 
                                                            string location, 
                                                            PreferableCarFeatures carFeatures,
                                                            int pageNumber,
                                                            int pageSize);
        Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalId
                                                (long id, 
                                                PreferableCarFeatures carFeatures,
                                                int pageNumber,
                                                int pageSize);
    }
}