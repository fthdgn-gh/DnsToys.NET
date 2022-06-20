namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Length
    {
        Meter, // m
        Kilometer, // km
        Centimeter, // cm
        Millimeter, // mm
        Mile, // mi
        Yard, // yd
        Foot, // ft
        Inch, // in
        NauticalMile // nmi
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Length, string> _lengthSymbols = new Dictionary<DnsToysUnits.Length, string> {
        { DnsToysUnits.Length.Meter, "m" },
        { DnsToysUnits.Length.Kilometer, "km" },
        { DnsToysUnits.Length.Centimeter, "cm" },
        { DnsToysUnits.Length.Millimeter, "mm" },
        { DnsToysUnits.Length.Mile, "mi" },
        { DnsToysUnits.Length.Yard, "yd" },
        { DnsToysUnits.Length.Foot, "ft" },
        { DnsToysUnits.Length.Inch, "in" },
        { DnsToysUnits.Length.NauticalMile, "nmi" }
    };
    public static string AsSymbol(this DnsToysUnits.Length self)
    {
        if (!_lengthSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _lengthSymbols[self];
    }
}