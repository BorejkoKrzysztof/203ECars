using _2035Cars_Application.Commands;
using _2035Cars_Application.DTO;
using _2035Cars_Application.Interfaces;
using _2035Cars_Core.Domain;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;
using _2035Cars_Infrastructure.Interfaces;
using _2035Cars_Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace _2035Cars_Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly ILogger<EmployeeService> _logger;
    private readonly IJwtHandler _jwtHandler;

    public EmployeeService(IEmployeeRepository repository, ILogger<EmployeeService> logger, IJwtHandler jwtHandler)
    {
        this._repository = repository;
        this._logger = logger;
        this._jwtHandler = jwtHandler;
    }
    public async Task<TokenDTO> Login(string emailAddress, string password)
    {
        var tokens = new TokenDTO();
        try
        {
            var account = await this._repository.ReadAccount(emailAddress);
            if (account is null)
            {
                throw new ArgumentNullException("Invalid Credentials");
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(password, account.Password);
            if (!validPassword)
            {
                throw new ArgumentException("Invalid Credentials");
            }

            var employeeId = await this._repository.GetEmployeeIdByEmailAddress(emailAddress);
            string refreshToken = await _repository.GetRefreshToken(employeeId);

            if (refreshToken is null)
            {
                refreshToken = await _repository.CreateRefreshToken(employeeId);
            }

            var employeePosition = await this._repository.GetEmployeePositionById(employeeId);

            var jwt = this._jwtHandler.CreateToken(employeeId, account.EmailAddress, employeePosition);
            tokens.Token = jwt.Token;
            tokens.Expires = jwt.Expires;
            tokens.Role = $"{(int)employeePosition}";
            tokens.RefreshToken = refreshToken;
        }
        catch (Exception ex)
        {
            this._logger.LogError($"Error occured while login process, Error => {ex.Message}");
            return null!;
        }

        return tokens;
    }

    public async Task<TokenDTO> RefreshJwtToken(string refreshToken)
    {
        long employeeId = await this._repository.GetUserIdByRefreshToken(refreshToken);
        var employee = await this._repository.ReadByIDAsync(employeeId);

        var jwt = _jwtHandler.CreateToken(employeeId, employee.Account.EmailAddress, employee.Position);

        return new TokenDTO
        {
            Token = jwt.Token,
            Expires = jwt.Expires,
            Role = $"{(int)employee.Position}",
            RefreshToken = refreshToken,
        };
    }

    public async Task<TokenDTO> RegisterAccount(RegisterRequestAccount command)
    {
        TokenDTO tokens = new TokenDTO();
        try
        {
            var accountExists = await this._repository.IsAccountExisting(command.EmailAddress);

            if (accountExists)
            {
                this._logger.LogInformation($"Account with email: {command.EmailAddress} already exists.");
                throw new ArgumentOutOfRangeException($"Account with email: {command.EmailAddress} already exists.");
            }

            long rentalId = await this._repository
                                .GetEmployeeRentalIdByCityAndLocation
                                                (command.RentalCity, command.RentalLocation);

            Employee newEmployee = new Employee()
            {
                Person = new Person(command.FirstName, command.LastName, command.PhoneNumber),
                Address = new Address(command.Street, command.HouseNumber, command.City, command.ZipCode),
                Account = new Account(command.EmailAddress, BCrypt.Net.BCrypt.HashPassword(command.Password)),
                Department = (Department)command.Department,
                Position = (BuisnessPosition)command.BusinessPosition,
                AcceptedOrders = new List<Order>(),
                RentalId = rentalId
            };

            var emplID = await this._repository.CreateAsync(newEmployee);
            this._logger.LogInformation($"New Employee with ID: {newEmployee.Id} is registered.");

            var refreshToken = await this._repository.GetRefreshToken(emplID);

            if (refreshToken is null)
            {
                refreshToken = await _repository.CreateRefreshToken(emplID);
                this._logger.LogInformation($"New Refresh Token is created.");
            }

            var jwt = _jwtHandler.CreateToken(newEmployee.Id, newEmployee.Account.EmailAddress, newEmployee.Position);
            this._logger.LogInformation($"New JWT Token is created.");

            tokens.Token = jwt.Token;
            tokens.Expires = jwt.Expires;
            tokens.Role = $"{(int)command.BusinessPosition}";
            tokens.RefreshToken = refreshToken;

        }
        catch (Exception ex)
        {
            this._logger.LogError($"Error while registering, msg => {ex.Message}");
            return null!;
        }

        return tokens;
    }
}