using _2035Cars_Application.DTO;
namespace _2035Cars_Application.Interfaces;

public interface IAccountService
{
    Task<TokenDTO> Login(string emailAddress, string password);
    Task<TokenDTO> RegisterAccount(string firstName, string lastName, string emailAddress,
                        string password, int Department, int BusinessPosition);

    Task<TokenDTO> RefreshJwtToken(string refreshToken);
}