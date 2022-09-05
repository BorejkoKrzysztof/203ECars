using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain;

public class Account : BaseEntity
{
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string FirstName { get; private set; }

    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string LastName { get; private set; }

    [Required]
    [EmailAddress]
    [MinLength(5)]
    [MaxLength(70)]
    public string EmailAddress { get; private set; }

    [Required]
    [MinLength(10)]
    [MaxLength(100)]
    public string Password { get; private set; }

    // [Required]
    // [MinLength(3)]
    // [MaxLength(30)]
    // public string Role { get; private set; }

    [Required]
    public DateTime RegisteredAt { get; private set; }

    [Required]
    public DateTime LastLoggedAt { get; private set; }

    public Account()
    {
        
    }

    public Account Create(string firstName, string lastName, string emailAddress, 
                            string password)
    {
        return new Account
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            Password = password,
            RegisteredAt = DateTime.UtcNow,
            LastLoggedAt = DateTime.UtcNow
        };
    }
}