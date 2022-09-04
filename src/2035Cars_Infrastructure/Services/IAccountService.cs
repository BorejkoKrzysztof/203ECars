using _2035Cars_Infrastructure.Commands.Account;

namespace _2035Cars_Infrastructure.Services;

public interface IAccountService
{
    Task CreateAccount(RegisterRequestAccount accountInfo);
}