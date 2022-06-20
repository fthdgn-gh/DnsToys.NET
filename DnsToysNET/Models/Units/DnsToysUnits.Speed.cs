namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Speed
    {
        MeterPerSecond, // m/s
        MilePerHour, // mph
        FeetPerSecond, // ft/s
        KilometerPerHour, // kmph
        Knot // kn
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Speed, string> _speedSymbols = new Dictionary<DnsToysUnits.Speed, string> 
    {
        { DnsToysUnits.Speed.MeterPerSecond, "m/s" },
        { DnsToysUnits.Speed.MilePerHour, "mph" },
        { DnsToysUnits.Speed.FeetPerSecond, "ft/s" },
        { DnsToysUnits.Speed.KilometerPerHour, "kmph" },
        { DnsToysUnits.Speed.Knot, "kn" }
    };
    
    public static string AsSymbol(this DnsToysUnits.Speed self)
    {
        if (!_speedSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _speedSymbols[self];
    }
}