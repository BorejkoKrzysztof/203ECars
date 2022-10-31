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

        public async Task<string?> CreateRefreshToken(long employeeId)
        {
            var token = RefreshToken.CreateRefreshToken(employeeId);

            await _dbContext.RefreshTokens.AddAsync(token);
            await _dbContext.SaveChangesAsync();

            return token.Token;
        }

        public async Task<long> GetEmployeeIdByEmailAddress(string emailAddress)
        {
            long id = this._dbContext.Employees
                            .FirstOrDefault(x => x.Account.EmailAddress == emailAddress)
                            .Id;

            return await Task.FromResult(id);
        }

        public async Task<BuisnessPosition> GetEmployeePositionById(long employeeId)
        {
            var position = this._dbContext.Employees
                                    .FirstOrDefault(x => x.Id == employeeId)
                                    .Position;

            return await Task.FromResult(position);
        }

        public async Task<string> GetRefreshToken(long employeeId)
        {
            var refreshToken = this._dbContext.RefreshTokens
                                        .Where(x => x.UserId == employeeId)
                                        .OrderByDescending(x => x.ExpiryDate)
                                        .FirstOrDefault()
                                        .Token;

            return await Task.FromResult(refreshToken);
        }

        public async Task<long> GetUserIdByRefreshToken(string refreshToken)
        {
            var userId = this._dbContext.RefreshTokens
                                    .FirstOrDefault(x => x.Token == refreshToken)
                                    .UserId;

            return await Task.FromResult(userId);
        }

        public async Task<bool> IsAccountExisting(string emailAddress)
        {
            bool exists = this._dbContext.Employees
                                    .Any(x => x.Account.EmailAddress == emailAddress);

            return await Task.FromResult(exists);
        }

        public async Task<Account> ReadAccount(string emailAddress)
        {
            var account = this._dbContext.Employees
                                .First(x => x.Account.EmailAddress == emailAddress)
                                .Account;

            return await Task.FromResult(account);
        }
    }
}