using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        Task<List<Car>> GetAllNotRentedCarsByRentalLoactionAsync
                            (string city, string rentalTitle, int pageNumber, int pageSize);

        Task<List<Car>> GetAllCarsByCarTypeAsync(CarType carType, int pageNumber, int pageSize);

        Task<List<Car>> GetAllSelectedCarsByCityAndLocationAsync(string city,
                                            string rentalTitle,
                                            DateTime availableFrom,
                                            bool desiredSuvtype,
                                            bool desiredSporttype,
                                            bool desiredConvertibletype,
                                            bool desiredSedantype,
                                            bool hasAirCooling,
                                            bool hasHeatingSeats,
                                            bool hasAutomaticGearBox,
                                            bool hasBuildInNavigation,
                                            bool hasHybridDrive,
                                            bool hasElectricDrive,
                                            int pageNumber,
                                            int pageSize,
                                            decimal minPrice,
                                            decimal maxPrice,
                                            int amountOfDoor,
                                            int amountOfSeats);

        Task<int> CountAllSelectedCarsByCityAndLocationAsync(string city,
                                            string rentalTitle,
                                            DateTime availableFrom,
                                            bool desiredSuvtype,
                                            bool desiredSporttype,
                                            bool desiredConvertibletype,
                                            bool desiredSedantype,
                                            bool hasAirCooling,
                                            bool hasHeatingSeats,
                                            bool hasAutomaticGearBox,
                                            bool hasBuildInNavigation,
                                            bool hasHybridDrive,
                                            bool hasElectricDrive,
                                            decimal minPrice,
                                            decimal maxPrice,
                                            int amountOfDoor,
                                            int amountOfSeats);

        Task<List<Car>> GetAllSelectedCarsByRentalIdAsync(long rentalId,
                                            DateTime availableFrom,
                                            bool desiredSuvtype,
                                            bool desiredSporttype,
                                            bool desiredConvertibletype,
                                            bool desiredSedantype,
                                            bool hasAirCooling,
                                            bool hasHeatingSeats,
                                            bool hasAutomaticGearBox,
                                            bool hasBuildInNavigation,
                                            bool hasHybridDrive,
                                            bool hasElectricDrive,
                                            int pageNumber,
                                            int pageSize,
                                            decimal minPrice,
                                            decimal maxPrice,
                                            int amountOfDoor,
                                            int amountOfSeats);

        Task<int> CountAllSelectedCarsByRentalIdAsync(long rentalId,
                                            DateTime availableFrom,
                                            bool desiredSuvtype,
                                            bool desiredSporttype,
                                            bool desiredConvertibletype,
                                            bool desiredSedantype,
                                            bool hasAirCooling,
                                            bool hasHeatingSeats,
                                            bool hasAutomaticGearBox,
                                            bool hasBuildInNavigation,
                                            bool hasHybridDrive,
                                            bool hasElectricDrive,
                                            decimal minPrice,
                                            decimal maxPrice,
                                            int amountOfDoor,
                                            int amountOfSeats);
    }
}