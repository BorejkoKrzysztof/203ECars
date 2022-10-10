using System.ComponentModel.DataAnnotations;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain
{
    public class Employee : BaseEntity
    {
        [Required]
        public Person Person { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public Account Account { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public BuisnessPosition Position { get; set; }

        [Required]
        public DateTime LastLoggedAt { get; set; }

        [Required]
        public long RentalId { get; set; }
        public virtual Rental Rental { get; set; }

        public Employee()
        {
            
        }

        // public Employee(Person person, Address address, Account account, Department department, BuisnessPosition position, Rental rental)
        // {
        //     Person = person ?? throw new ArgumentNullException(nameof(person));
        //     Address = address ?? throw new ArgumentNullException(nameof(address));
        //     Account = account ?? throw new ArgumentNullException(nameof(account));
        //     Department = department;
        //     Position = position;
        //     LastLoggedAt = DateTime.UtcNow;
        //     Rental = rental ?? throw new ArgumentNullException(nameof(rental));
        //     // CreatedDate = DateTime.UtcNow;
        //     // LastUpdateDate = DateTime.UtcNow;
        // }
    }
}