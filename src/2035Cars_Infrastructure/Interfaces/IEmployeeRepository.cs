using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Infrastructure.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<bool> IsAccountExisting(string emailAddress);
        Task<Account> ReadAccount(string emailAddress);
        Task<long> GetEmployeeIdByEmailAddress(string emailAddress);
        Task<BuisnessPosition> GetEmployeePositionById(long employeeId);
        Task<string> GetRefreshToken(long employeeId);
        Task<string?> CreateRefreshToken(long employeeId);
        Task<long> GetUserIdByRefreshToken(string refreshToken);
        Task<long> GetEmployeeRentalIdByCityAndLocation(string rentalCity, string renatlLocation);
        Task<long> GetRentalIdByEmployeeId(long employeeId);
        Task<List<Employee>> GetEmployeesByRentalId(long rentalId, int currentPage, int pageSize);
        Task<int> CountEmployeesByRentalId(long rentalId);
    }
}