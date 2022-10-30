using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
namespace _2035Cars_Application.Interfaces;

public interface IEmployeeService
{
    Task<TokenDTO> Login(string emailAddress, string password);
    Task<TokenDTO> RegisterAccount(RegisterRequestAccount command);

    Task<TokenDTO> RefreshJwtToken(string refreshToken);
}