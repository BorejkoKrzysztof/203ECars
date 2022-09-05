using _2035Cars_Infrastructure.Commands.Account;
using _2035Cars_Infrastructure.DTO;

namespace _2035Cars_Infrastructure.Services;

public interface IAccountService
{
    Task<TokenDTO> Login(string emailAddress, string password);
    Task RegisterAccount(string firstName, string lastName, string emailAddress,
                        string password, string confirmPassword);
}