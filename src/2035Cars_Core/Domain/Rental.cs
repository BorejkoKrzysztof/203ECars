using _2035Cars_Core.ValueObjects;
using _2035Cars_Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace _2035Cars_Core.Domain
{
    public class Rental : BaseEntity
    {
        [Required]
        public string Title { get; private set; }

        [Required]
        public Address Address { get; private set; }

        [Required]
        public List<Car> Cars { get; private set; }

        [Required]
        public List<Employee> Employees { get; private set; }

        public Rental(string title, Address address)
        {
            Title = string.IsNullOrEmpty(title) ? throw new ArgumentNullException(nameof(title)) : title;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Cars = new List<Car>();
            Employees = new List<Employee>();
        }

        public void AddCar(Car carToAdd)
        {
            if (carToAdd is null)
                throw new ArgumentNullException(nameof(carToAdd));

            Cars.Add(carToAdd);
            // LastUpdateDate = DateTime.UtcNow;
        }

        public void AddEmployee(Employee employeeToAdd)
        {
            if (employeeToAdd is null)
                throw new ArgumentNullException(nameof(employeeToAdd));
                
            Employees.Add(employeeToAdd);
            // LastUpdateDate = DateTime.UtcNow;
        }
    }
}