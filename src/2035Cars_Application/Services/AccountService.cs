using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Core.Domain;

namespace _2035Cars_Application.Services;

public class AccountService : IAccountService
{
    public Task<TokenDTO> Login(string emailAddress, string password)
    {
        throw new NotImplementedException();
    }

    public Task<TokenDTO> RefreshJwtToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<TokenDTO> RegisterAccount(string firstName, string lastName, string emailAddress, string password, string confirmPassword)
    {
        throw new NotImplementedException();
    }
}