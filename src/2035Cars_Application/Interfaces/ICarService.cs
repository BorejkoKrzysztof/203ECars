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
                                                            PreferableCarFeaturesSearchWithLocationCommand carFeatures,
                                                            int pageNumber,
                                                            int pageSize);
        // Task<CarsCollectionWithPagination> GetCollectionOfCarsByRentalId
        //                                         (long id, 
        //                                         PreferableCarFeaturesSearchWithLocationCommand carFeatures,
        //                                         int pageNumber,
        //                                         int pageSize);

        Task<CarsCollectionWithPagination> GetAllCarsAsync(int pageNumber, int pageSize);
        Task<CarsCollectionWithPagination> GetCarsByTypeAsync
                                                (int pageNumber, int pageSize, CarsByTypeCommand command);
        Task<CarsCollectionWithPagination> GetCarsByLocationAndEquipmentAsync(int pageNumber, int pageSize, GetCarsByEquipmentCommand command);
        Task<byte[]> GetImageForCarById(long carId);
    }
}