namespace _2035Cars_Application.Commands
{
    public class RegisterRequestAccount
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public int Department { get; set; }
        public int BusinessPosition { get; set; }
        public string RentalCity { get; set; }
        public string RentalLocation { get; set; }
    }
}