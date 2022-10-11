using System.ComponentModel.DataAnnotations;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain
{
    public class Client : BaseEntity
    {
        // [Required]
        // public Account Account { get; set; }

        // [Required]
        // public Address Address { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public Person Person { get; set; }

        [Required]
        public List<Order> Orders { get; set; }

        public Client()
        {
            
        }

        // public Client(string emailAddress, Person person)
        // {
        //     EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        //     // Account = account ?? throw new ArgumentNullException(nameof(account));
        //     // Address = address ?? throw new ArgumentNullException(nameof(address));
        //     Person = person ?? throw new ArgumentNullException(nameof(person));
        //     // CreatedDate = DateTime.UtcNow;
        //     // LastUpdateDate = DateTime.UtcNow;
        // }
    }
}