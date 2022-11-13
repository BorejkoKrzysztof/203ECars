using Microsoft.AspNetCore.Http;

namespace _2035Cars_Application.Commands
{
    public class EditCarCommand
    {
        public long CarId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int CarType { get; set; }
        public int Drivetype { get; set; }
        public IFormFile? Image { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasHeatingSeats { get; set; }
        public bool HasAutomaticGearBox { get; set; }
        public bool HasBuildInNavigation { get; set; }
        public int AmountOfDoor { get; set; }
        public int AmountOfSeats { get; set; }
        public decimal PriceForHour { get; set; }
    }
}