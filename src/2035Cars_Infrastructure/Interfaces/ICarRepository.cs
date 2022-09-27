using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        Task<List<Car>> GetAllNotRentedCarsByRentalLoactionAsync
                            (string city, string rentalTitle, int pageNumber, int pageSize);

        Task<List<Car>> GetAllCarsByCarTypeAsync(CarType carType, int pageNumber, int pageSize);

        
        // TODO: Metoda, która zwraca liste na strone availablecars z warunkami wyszukiwania +
        // paginacja

        // // // // // // Task<List<Car>> GetAllSelectedCars(string city, 
        // // // // // //                                     string rentalTitle, 
        // // // // // //                                     decimal minPrice = 0M, 
        // // // // // //                                     decimal maxPrice = decimal.MaxValue,
        // // // // // //                                     bool hasAirConditioning = false,
        // // // // // //                                     bool has );
    }
}