using _2035Cars_Core.Domain;
using _2035Cars_Core.Repositories;
using _2035Cars_Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace _2035Cars_Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly CarsDbContext context;

    public AccountRepository(CarsDbContext context)
    {
        this.context = context;
    }

    public async Task CreateAccount(Account account)
    {
        await this.context.Accounts.AddAsync(account);
        await this.context.SaveChangesAsync();
    }

    public async Task<Account> GetByEmail(string emailAddress)
    {
        var account = this.context.Accounts
                        .FirstOrDefault(x => string.Equals(x.EmailAddress, emailAddress));

        return await Task.FromResult(account!);
    }
}