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
        public string Brand { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(25)]
        public string Model { get; set; }

        [Required]
        public CarType CarType { get; set; }

        [Required]
        public CarEquipment Equipment { get; set; }

        [Required]
        public DriveOfCar DriveType { get; set; }

        [Required]
        public int AmountOfDoor { get; set; }

        [Required]
        public int AmountOfSeats { get; set; }

        [Required]
        public decimal PriceForOneHour { get; set; }

        [Required]
        public bool IsRented { get; set; }

        public DateTime RentedTo { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        // [ForeignKey("Rental")]
        public long RentalId { get; set; }
        public virtual Rental Rental { get; set; }

        protected Car()
        {
            
        }

        // public Car(string brand, string model, CarType carType, CarEquipment equipment, DriveOfCar driveType, int amountOfDoor, int amountOfSeats, decimal priceForOneHour, byte[] image, Rental rental)
        // {
        //     Brand = string.IsNullOrEmpty(brand) ? throw new ArgumentNullException(nameof(brand)) : brand;
        //     Model = string.IsNullOrEmpty(model) ? throw new ArgumentNullException(nameof(model)) : model;
        //     CarType = carType;
        //     Equipment = equipment ?? throw new ArgumentNullException(nameof(equipment));
        //     DriveType = driveType;
        //     AmountOfDoor = amountOfDoor;
        //     AmountOfSeats = amountOfSeats;
        //     PriceForOneHour = priceForOneHour;
        //     IsRented = false;
        //     Image = image ?? throw new ArgumentNullException(nameof(image));
        //     Rental = rental ?? throw new ArgumentNullException(nameof(rental));
        // }

    }
}