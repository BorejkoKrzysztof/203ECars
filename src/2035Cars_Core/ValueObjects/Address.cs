using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.ValueObjects
{
    public class Address : ValueObject
    {
        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string Street { get; private set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string Number { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string City { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(70)]
        public string ZipCode { get; private set; }


        public Address(string street, string number, string city, string zipCode)
        {
            Street = string.IsNullOrEmpty(street) ? throw new ArgumentNullException(nameof(street)) : street;
            Number = string.IsNullOrEmpty(number) ? throw new ArgumentNullException(nameof(number)) : number;
            City = string.IsNullOrEmpty(city) ? throw new ArgumentNullException(nameof(city)) : city;
            ZipCode = string.IsNullOrEmpty(zipCode) ? throw new ArgumentNullException(nameof(zipCode)) : zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Number;
            yield return City;
            yield return ZipCode;
        }
    }
}