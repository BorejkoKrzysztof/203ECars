namespace _2035Cars_Core.ValueObjects
{
    public class Account : ValueObject
    {
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        

        public Account()
        {
        }


        public Account(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
            yield return Password;
        }
    }
}