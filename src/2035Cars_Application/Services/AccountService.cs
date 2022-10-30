using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;

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

    public Task<TokenDTO> RegisterAccount(string firstName, string lastName,
                                            string emailAddress, string password,
                                            int Department, int BusinessPosition)
    {
        throw new NotImplementedException();
    }
}