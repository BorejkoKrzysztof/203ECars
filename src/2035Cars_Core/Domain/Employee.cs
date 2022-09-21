using System.ComponentModel.DataAnnotations;
using _2035Cars_Core.Enums;
using _2035Cars_Core.ValueObjects;

namespace _2035Cars_Core.Domain;

public class Employee : BaseEntity
{
    public Person Person { get; private set; }
    public Address Address { get; private set; }
    public Account Account { get; private set; }
    public Department Department { get; private set; }
    public BuisnessPosition Position { get; private set; }

    [Required]
    public DateTime LastLoggedAt { get; private set; }

    public Employee()
    {
    }

    // public static Employee Create(string firstName, string lastName, string emailAddress, 
    //                         string password)
    // {
    //     // return new Employee
    //     // {
    //     //     FirstName = firstName,
    //     //     LastName = lastName,
    //     //     EmailAddress = emailAddress,
    //     //     Password = password,
    //     //     CreatedDate = DateTime.UtcNow,
    //     //     LastLoggedAt = DateTime.UtcNow
    //     // };
    // }
}