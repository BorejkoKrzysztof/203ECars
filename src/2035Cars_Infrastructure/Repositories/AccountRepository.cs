using _2035Cars_Core.Domain;
using _2035Cars_Core.Repositories;
using _2035Cars_Infrastructure.Database;

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
}