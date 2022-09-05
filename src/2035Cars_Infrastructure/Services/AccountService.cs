using _2035Cars_Core.Domain;
using _2035Cars_Core.Repositories;

namespace _2035Cars_Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        this._repository = repository;
    }

    public async Task RegisterAccount(string firstName, string lastName, string emailAddress,
                                        string password, string confirmPassword)
    {
        if (!string.Equals(password, confirmPassword))
        {
            throw new ArgumentException("Password must match ConfirmPassword");
        }

        var newAccount = Account.Create(firstName, lastName, emailAddress,
                                            BCrypt.Net.BCrypt.HashPassword(password));
        await this._repository.CreateAccount(newAccount);
    }
}