using System.ComponentModel.DataAnnotations;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain
{
    public class Client : BaseEntity
    {
        [Required]
        public Account Account { get; private set; }

        [Required]
        public Address Address { get; private set; }

        [Required]
        public Person Person { get; private set; }

        public Client()
        {
            
        }

        public Client(Account account, Address address, Person person)
        {
            Account = account ?? throw new ArgumentNullException(nameof(account));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Person = person ?? throw new ArgumentNullException(nameof(person));
            // CreatedDate = DateTime.UtcNow;
            // LastUpdateDate = DateTime.UtcNow;
        }
    }
}