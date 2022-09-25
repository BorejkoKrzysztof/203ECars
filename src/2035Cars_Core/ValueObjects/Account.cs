using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.ValueObjects
{
    public class Account : ValueObject
    {
        [Required]
        [MinLength(5)]
        [MaxLength(35)]
        public string EmailAddress { get; private set; }

        [Required]
        [MinLength(15)]
        public string Password { get; private set; }
        
        public Account(string emailAddress, string password)
        {
            EmailAddress = string.IsNullOrEmpty(emailAddress) ? throw new ArgumentNullException(nameof(emailAddress)) : emailAddress;
            Password = string.IsNullOrEmpty(password) ? throw new ArgumentNullException(nameof(password)) : password;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
            yield return Password;
        }
    }
}