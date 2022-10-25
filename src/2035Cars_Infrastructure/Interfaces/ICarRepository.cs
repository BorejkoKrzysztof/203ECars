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
                                            int pageSize);
        Task<int> CountAllCarsAsync();
        Task<List<Car>> GetAllCarsPaginationAsync(int pageNumber, int pageSize);
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
                                            bool hasElectricDrive);
        Task<List<Car>> GetCarsByLocationAndEquipmentAsync(int pageNumber, int pageSize, string cityFrom, string locationFrom, decimal minPrice, decimal maxPrice, bool desiredSuv, bool desiredSedan, bool desiredSport, bool desiredCompact, bool desiredAirConditioning, bool desiredHeatingSeats, bool desiredAutomaticGearBox, bool desiredBuildInNavigation, bool desiredHybridDrive, bool desiredElectricDrive, int amountOfDoors, int amountOfSeats);
        Task<List<Car>> GetCarsByTypeAsync(int pageNumber, int pageSize, 
                                            bool desiredCompactType, 
                                            bool desiredSedanType, 
                                            bool desiredSportType, 
                                            bool desiredSuvType);

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
        Task<int> CountAllCarsByLocationAndEquimentAsync(string cityFrom, string locationFrom, decimal minPrice, decimal maxPrice, bool desiredSuv, bool desiredSedan, bool desiredSport, bool desiredCompact, bool desiredAirConditioning, bool desiredHeatingSeats, bool desiredAutomaticGearBox, bool desiredBuildInNavigation, bool desiredHybridDrive, bool desiredElectricDrive, int amountOfDoors, int amountOfSeats);
        Task<int> CountListOfCarsByTypeAsync(bool desiredCompactType, bool desiredSedanType, bool desiredSportType, bool desiredSuvType);
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