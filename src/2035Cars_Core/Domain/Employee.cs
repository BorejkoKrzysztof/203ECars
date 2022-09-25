using System.ComponentModel.DataAnnotations;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain
{
    public class Employee : BaseEntity
    {
        [Required]
        public Person Person { get; private set; }

        [Required]
        public Address Address { get; private set; }

        [Required]
        public Account Account { get; private set; }

        [Required]
        public Department Department { get; private set; }

        [Required]
        public BuisnessPosition Position { get; private set; }

        [Required]
        public DateTime LastLoggedAt { get; private set; }

        [Required]
        public long RentalId { get; private set; }
        public Rental Rental { get; private set; }

        public Employee()
        {
            
        }

        public Employee(Person person, Address address, Account account, Department department, BuisnessPosition position, DateTime lastLoggedAt, Rental rental)
        {
            Person = person ?? throw new ArgumentNullException(nameof(person));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Account = account ?? throw new ArgumentNullException(nameof(account));
            Department = department;
            Position = position;
            LastLoggedAt = lastLoggedAt;
            Rental = rental ?? throw new ArgumentNullException(nameof(rental));
            // CreatedDate = DateTime.UtcNow;
            // LastUpdateDate = DateTime.UtcNow;
        }
    }
}