namespace _2035Cars_Core.ValueObjects;

public class CarEquipment : ValueObject
{
    public bool HasAirCooling { get; private set; }
    public bool HasHeatingSeat { get; private set; }
    public bool HasAutomaticGearBox { get; private set; }
    public bool HasBuildInNavigation{ get; private set; }

    public CarEquipment()
    {
    }

    public CarEquipment(bool hasAirCooling, bool hasHeatingSeat, bool hasAutomaticGearBox, bool hasBuildInNavigation)
    {
        HasAirCooling = hasAirCooling;
        HasHeatingSeat = hasHeatingSeat;
        HasAutomaticGearBox = hasAutomaticGearBox;
        HasBuildInNavigation = hasBuildInNavigation;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return HasAirCooling;
        yield return HasHeatingSeat;
        yield return HasAutomaticGearBox;
        yield return HasBuildInNavigation;
    }
}