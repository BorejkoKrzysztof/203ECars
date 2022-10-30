namespace _2035Cars_Application.Commands
{
    public class RegisterRequestAccount
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public int Department { get; set; }
        public int BusinessPosition { get; set; }
    }
}