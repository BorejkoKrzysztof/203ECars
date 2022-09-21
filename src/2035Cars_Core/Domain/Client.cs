using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain
{
    public class Client : BaseEntity
    {
        public Account Account { get; private set; }
        public Address Address { get; private set; }
        public Person Person { get; private set; }
        public string PersonalIdNumber { get; private set; }
    }
}