namespace _2035Cars_Application.Commands
{
    public class GetCarsByEquipmentCommand
    {
        public string CityFrom { get; set; }
        public string LocationFrom { get; set; }
        public string CityTo { get; set; }
        public string LocationTo { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public bool DesiredSuv { get; set; }
        public bool DesiredSedan { get; set; }
        public bool DesiredSport { get; set; }
        public bool DesiredCompact { get; set; }
        public bool DesiredAirConditioning { get; set; }
        public bool DesiredHeatingSeats { get; set; }
        public bool DesiredAutomaticGearBox { get; set; }
        public bool DesiredBuildInNavigation { get; set; }
        public bool DesiredHybridDrive { get; set; }
        public bool DesiredElectricDrive { get; set; }
        public int AmountOfDoors { get; set; }
        public int AmountOfSeats { get; set; }
    }
}