using _2035Cars_Core.ValueObjects;
using _2035Cars_Core.Enums;

namespace _2035Cars_Core.Domain;

public class Car : BaseEntity
{
    public string Brand { get; private set; }

    public string Model { get; private set; }

    public CarType CarType { get; private set; }

    public CarEquipment Equipment { get; private set; }

    public DriveOfCar DriveType { get; private set; }

    public int AmountOfDoor { get; private set; }

    public int AmountOfSeats { get; private set; }
    
    public decimal PriceForOneHour { get; private set; }

    public bool IsRented { get; private set; }

    public Guid CurrentRentalLocation { get; private set; }

}