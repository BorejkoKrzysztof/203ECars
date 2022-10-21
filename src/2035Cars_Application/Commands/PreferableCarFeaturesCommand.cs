namespace _2035Cars_Application.Commands
{
    public class PreferableCarFeaturesCommand
    {
        public DateTime AvailableFrom { get; set; }
        // public DateTime OrderFrom { get; set; }
        public DateTime OrderTo { get; set; }

        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }

        public bool DesiredSuvType { get; set; }
        public bool DesiredSportType { get; set; }
        public bool DesiredCompactType { get; set; }
        public bool DesiredSedanType { get; set; }

        public bool DesiredAirCooling { get; set; }
        public bool DesiredHeatingSeats { get; set; }
        public bool DesiredAutomaticGearBox { get; set; }
        public bool DesiredBuildInNavigation { get; set; }

        public bool DesiredHybridDrive { get; set; }
        public bool DesiredElectricDrive { get; set; }

        public int DesiredAmountOfDoors { get; set; }
        public int DesiredAmountOfSeats { get; set; }
    }
}