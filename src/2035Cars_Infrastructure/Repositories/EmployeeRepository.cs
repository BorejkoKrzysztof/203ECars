using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Database;
using _2035Cars_Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CarDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> CountEmployeesByRentalId(long rentalId)
        {
            var amountOfEmployees = this._dbContext.Rentals
                                                    .First(x => x.Id == rentalId)
                                                    .Employees.Count();

            return await Task.FromResult(amountOfEmployees);
        }

        public async Task<string?> CreateRefreshToken(long employeeId)
        {
            var token = RefreshToken.CreateRefreshToken(employeeId);

            await _dbContext.RefreshTokens.AddAsync(token);
            await _dbContext.SaveChangesAsync();

            return token.Token;
        }

        public async Task<object> GetEmployeeBasicDetails(long employeeId)
        {
            var details = this._dbContext.Employees
                                    .Where(x => x.Id == employeeId)
                                    .Select(s => new
                                    {
                                        Id = s.Id,
                                        FirstName = s.Person.FirstName,
                                        LastName = s.Person.LastName,
                                        Street = s.Address.Street,
                                        HouseNumber = s.Address.Number,
                                        ZipCode = s.Address.ZipCode,
                                        City = s.Address.City,
                                        EmailAddress = s.Account.EmailAddress,
                                        Department = (int)s.Department,
                                        BusinessPosition = (int)s.Position,
                                        PhoneNumber = s.Person.PhoneNumber
                                    }).First();

            return await Task.FromResult(details);
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

        public async Task<long> GetEmployeeRentalIdByCityAndLocation(string rentalCity, string renatlLocation)
        {
            var id = this._dbContext.Rentals.FirstOrDefault(x => x.Address.City == rentalCity &&
                                                                x.Title == renatlLocation).Id;

            return await Task.FromResult(id);
        }

        public async Task<List<Employee>> GetEmployeesByRentalId(long rentalId, int currentPage, int pageSize)
        {
            var employees = this._dbContext.Employees
                                            .Where(x => x.RentalId == rentalId)
                                            .Skip((currentPage - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();

            return await Task.FromResult(employees);
        }

        public async Task<string> GetRefreshToken(long employeeId)
        {
            var refreshToken = this._dbContext.RefreshTokens
                                        .Where(x => x.UserId == employeeId)
                                        .OrderByDescending(x => x.ExpiryDate)
                                        .FirstOrDefault();

            return await Task.FromResult(refreshToken?.Token);
        }

        public async Task<long> GetRentalIdByEmployeeId(long employeeId)
        {
            var rentalId = this._dbContext.Employees
                                            .First(x => x.Id == employeeId)
                                            .RentalId;

            return await Task.FromResult(rentalId);
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