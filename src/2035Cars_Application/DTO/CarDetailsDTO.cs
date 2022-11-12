namespace _2035Cars_Application.DTO
{
    public class CarDetailsDTO
    {
        public long CarUniqueReferrence { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int CarType { get; set; }
        public int DriveType { get; set; }
        public decimal PriceForRental { get; set; }
        public int AmountOfDoor { get; set; }
        public int AmountOfSeats { get; set; }
        public bool HasAirCooling { get; set; }
        public bool HasHeatingSeats { get; set; }
        public bool HasAutomaticGearBox { get; set; }
        public bool HasBuildInNavigation { get; set; }
        public bool IsRented { get; set; }
        public byte[] Image { get; set; }
    }
}