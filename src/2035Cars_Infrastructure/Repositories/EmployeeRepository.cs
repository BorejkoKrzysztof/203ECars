using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;

namespace _2035Cars_Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public Task<string?> CreateRefreshToken(long employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetEmployeeIdByEmailAddress(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<BuisnessPosition> GetEmployeePositionById(long employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRefreshToken(long employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetUserIdByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAccountExisting(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<Account> ReadAccount(string emailAddress)
        {
            throw new NotImplementedException();
        }
    }
}