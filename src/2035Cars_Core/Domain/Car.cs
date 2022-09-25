using _2035Cars_Core.ValueObjects;
using _2035Cars_Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2035Cars_Core.Domain
{
    public class Car : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Brand { get; private set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string Model { get; private set; }

        [Required]
        public CarType CarType { get; private set; }

        [Required]
        public CarEquipment Equipment { get; private set; }

        [Required]
        public DriveOfCar DriveType { get; private set; }

        [Required]
        public int AmountOfDoor { get; private set; }

        [Required]
        public int AmountOfSeats { get; private set; }

        [Required]
        public decimal PriceForOneHour { get; private set; }

        [Required]
        public bool IsRented { get; private set; }

        [Required]
        public byte[] Image { get; private set; }

        [Required]
        // [ForeignKey("Rental")]
        public long RentalId { get; private set; }
        public Rental Rental { get; private set; }

        public Car()
        {
            
        }

        public Car(string brand, string model, CarType carType, CarEquipment equipment, DriveOfCar driveType, int amountOfDoor, int amountOfSeats, decimal priceForOneHour, byte[] image, Rental rental)
        {
            Brand = string.IsNullOrEmpty(brand) ? throw new ArgumentNullException(nameof(brand)) : brand;
            Model = string.IsNullOrEmpty(model) ? throw new ArgumentNullException(nameof(model)) : model;
            CarType = carType;
            Equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
            DriveType = driveType;
            AmountOfDoor = amountOfDoor;
            AmountOfSeats = amountOfSeats;
            PriceForOneHour = priceForOneHour;
            IsRented = false;
            Image = image ?? throw new ArgumentNullException(nameof(image));
            Rental = rental ?? throw new ArgumentNullException(nameof(rental));
            // CreatedDate = DateTime.UtcNow;
            // LastUpdateDate = DateTime.UtcNow;
        }

        public void RentCar()
        {
            IsRented = true;
            LastUpdateDate = DateTime.UtcNow;
        }

        public void FinishRental()
        {
            IsRented = false;
            LastUpdateDate = DateTime.UtcNow;
        }

    }
}