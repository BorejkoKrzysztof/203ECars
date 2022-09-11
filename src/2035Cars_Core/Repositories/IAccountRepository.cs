using _2035Cars_Core.Domain;

namespace _2035Cars_Core.Repositories;

public interface IAccountRepository
{
    Task CreateAccount(Account account);

    Task<Account> GetByEmail(string emailAddress);

    Task<string> GetRefreshToken(Guid accountId);

    Task<string> CreateRefreshToken(Guid accountId);
}