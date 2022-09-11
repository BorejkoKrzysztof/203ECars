using _2035Cars_Core.Domain;
using _2035Cars_Core.Repositories;
using _2035Cars_Infrastructure.DTO;

namespace _2035Cars_Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly IJwtHandler _jwtHandler;

    public AccountService(IAccountRepository repository, IJwtHandler jwtHandler)
    {
        this._repository = repository;
        this._jwtHandler = jwtHandler;
    }

    public async Task<TokenDTO> Login(string emailAddress, string password)
    {
        var account = await this._repository.GetByEmail(emailAddress);
        if (account is null)
        {
            throw new ArgumentNullException("Invalid Credentials");
        }

        var validPassword = BCrypt.Net.BCrypt.Verify(password, account.Password);
        if (!validPassword)
        {
            throw new ArgumentNullException("Invalid Credentials");
        }

        string refreshToken = await this._repository.GetRefreshToken(account.Id);
        if (refreshToken is null)
        {
             refreshToken = await this._repository.CreateRefreshToken(account.Id);
        }

         var jwt = _jwtHandler.CreateToken(account.Id, account.EmailAddress);

        return new TokenDTO
        {
            Token = jwt.Token,
            Expires = jwt.Expires,
            RefreshToken = refreshToken,
        };
    }

    public Task<TokenDTO> RefreshJwtToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<TokenDTO> RegisterAccount(string firstName, string lastName, string emailAddress,
                                        string password, string confirmPassword)
    {
        var account = await this._repository.GetByEmail(emailAddress);
        if (account is not null)
        {
            throw new ArgumentException($"Account with EmailAddress: {emailAddress} exists.");
        }
        
        if (!string.Equals(password, confirmPassword))
        {
            throw new ArgumentException("Password must match ConfirmPassword");
        }

        account = Account.Create(firstName, lastName, emailAddress,
                                            BCrypt.Net.BCrypt.HashPassword(password));
        await this._repository.CreateAccount(account);

        string refreshToken = await _repository.GetRefreshToken(account.Id);

        if (refreshToken is null)
        {
            refreshToken = await _repository.CreateRefreshToken(account.Id);
        }

        var jwt = _jwtHandler.CreateToken(account.Id, account.EmailAddress);

        return new TokenDTO()
        {
            Token = jwt.Token,
            Expires = jwt.Expires,
            RefreshToken = refreshToken,
        };
    }
}