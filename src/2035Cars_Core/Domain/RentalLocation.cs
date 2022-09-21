using _2035Cars_Core.ValueObjects;
using _2035Cars_Core.Enums;

namespace _2035Cars_Core.Domain;

public class RentalLocation : BaseEntity
{
    public string Title { get; private set; }
    
    public Address Address { get; private set; }
}