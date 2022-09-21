// using _2035Cars_Core.Domain;
// using _2035Cars_Infrastructure.Repositories;
// using _2035Cars_Infrastructure.Database;
// using Microsoft.EntityFrameworkCore;
// using _2035Cars_Infrastructure.Interfaces;

// namespace _2035Cars_Infrastructure.Repositories;

// public class AccountRepository : RepositoryBase<Account>, IAccountRepository
// {
//     public AccountRepository(CarsDbContext dbContext) : base(dbContext)
//     {
//     }

//     public Task<string> CreateRefreshTokenAsync(Guid accountId)
//     {
//         throw new NotImplementedException();
//     }

//     public async Task<Account> GetByEmailAsync(string emailAddress)
//     {
//         return await this._dbContext.Accounts.
//                     FirstOrDefaultAsync(x => string.Equals(x.EmailAddress, emailAddress));
//     }

//     public Task<string> GetRefreshTokenAsync(Guid accountId)
//     {
//         throw new NotImplementedException();
//     }
// }