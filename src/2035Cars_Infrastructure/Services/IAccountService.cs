using _2035Cars_Infrastructure.Commands.Account;

namespace _2035Cars_Infrastructure.Services;

public interface IAccountService
{
    Task RegisterAccount(string firstName, string lastName, string emailAddress,
                        string password, string confirmPassword);
}