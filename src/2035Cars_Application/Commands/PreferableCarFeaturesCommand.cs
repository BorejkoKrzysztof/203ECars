namespace _2035Cars_Application.Commands
{
    public class PreferableCarFeaturesCommand
    {
        public DateTime AvailableFrom { get; set; }
        public DateTime OrderTo { get; set; }

        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }

        public bool desiredSuvType { get; set; }
        public bool desiredSportType { get; set; }
        public bool desiredConvertibleType { get; set; }
        public bool desiredSedanType { get; set; }

        public bool DesiredAirCooling { get; set; }
        public bool DesiredHeatingSeats { get; set; }
        public bool DesiredAutomaticGearBox { get; set; }
        public bool DesiredBuilInNavigation { get; set; }

        public bool DesiredHybridDrive { get; set; }
        public bool DesiredElectricDrive { get; set; }

        public int DesiredAmountOfDoors { get; set; }
        public int DesiredAmountOfSeats { get; set; }
    }
}