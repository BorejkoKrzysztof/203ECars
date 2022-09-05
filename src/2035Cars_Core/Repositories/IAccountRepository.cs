using _2035Cars_Core.Domain;

namespace _2035Cars_Core.Repositories;

public interface IAccountRepository
{
    Task CreateAccount(Account account);

    Task<Account> GetByEmail(string emailAddress);
}