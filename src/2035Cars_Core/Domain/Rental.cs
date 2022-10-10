using _2035Cars_Core.ValueObjects;
using _2035Cars_Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain
{
    public class Rental : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public List<Car> Cars { get; set; }

        [Required]
        public List<Employee> Employees { get; set; }

        public Rental()
        {
            
        }

        // public Rental(string title, Address address)
        // {
        //     Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
        //     Address = address ?? throw new ArgumentNullException(nameof(address));
        //     Cars = new List<Car>();
        //     Employees = new List<Employee>();
        // }
    }
}