
namespace _2035Cars_Infrastructure.Commands.Account;

public class RegisterRequestAccount
{
    public string? FirstName { get; set; }

    public string? LastName{ get; set; }

    public string? EmailAddress { get; set; } 

    public string? Password { get; set; }

    public string? ConfirmPassword { get; set; }
}