
namespace _2035Cars_Core.Domain;

public class Account : BaseIdentity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public DateTime RegisteredAt { get; private set; }
    public DateTime LastLoggedAt { get; private set; }

    public Account()
    {
        
    }

    public Account Create(string firstName, string lastName, string emailAddress, 
                            string password, string role)
    {
        return new Account
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            Password = password,
            Role = role,
            RegisteredAt = DateTime.UtcNow,
            LastLoggedAt = DateTime.UtcNow
        };
    }
}