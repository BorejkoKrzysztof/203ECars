namespace _2035Cars_Core.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Address()
        {   
        }

        public Address(string street, string number, string city, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            ZipCode = zipCode;
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