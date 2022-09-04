using _2035Cars_Core.Repositories;
using _2035Cars_Infrastructure.Commands.Account;

namespace _2035Cars_Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        this._repository = repository;
    }
    public Task CreateAccount(RegisterRequestAccount accountInfo)
    {
        // this._repository.CreateAccount()
        throw new NotImplementedException();
    }
}