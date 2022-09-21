namespace _2035Cars_Core.ValueObjects
{
    public class Person : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return PhoneNumber;
        }
    }
}