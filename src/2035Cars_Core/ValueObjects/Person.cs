using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.ValueObjects
{
    public class Person : ValueObject
    {
        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string FirstName { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string LastName { get; private set; }

        [Required]
        [MinLength(9)]
        [MaxLength(35)]
        [Phone]
        public string PhoneNumber { get; private set; }

        public Person(string firstName, string lastName, string phoneNumber)
        {
            FirstName = string.IsNullOrEmpty(firstName) ? throw new ArgumentNullException(nameof(firstName)) : firstName;
            LastName = string.IsNullOrEmpty(lastName) ? throw new ArgumentNullException(nameof(lastName)) : lastName;
            PhoneNumber = string.IsNullOrEmpty(phoneNumber) ? throw new ArgumentNullException(nameof(phoneNumber)) : phoneNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return PhoneNumber;
        }
    }
}