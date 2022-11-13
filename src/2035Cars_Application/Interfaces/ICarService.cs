using _2035Cars_application.ViewModels;
using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.ViewModels;

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

        Task<CarsCollectionWithPagination> GetAllCarsAsync(int pageNumber, int pageSize);
        Task<CarsCollectionWithPagination> GetCarsByTypeAsync
                                                (int pageNumber, int pageSize, CarsByTypeCommand command);
        Task<CarsCollectionWithPagination> GetCarsByLocationAndEquipmentAsync(int pageNumber, int pageSize, GetCarsByEquipmentCommand command);
        Task<byte[]> GetImageForCarById(long carId);
        Task<CarsCollectionWithPaginationBasic> GetCarsForRental(long rentalId, int currentPage, int adminPageSize);
        Task<CarDetailsDTO> ReadCarByIdAsync(long carId);
        Task<bool> RemoveCarAsync(long carId);
        Task<bool> AddCarToRental(CreateCarCommand command);
        Task<bool> EditCarAsync(EditCarCommand command);
    }
}