namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Time
    {
        Second, // s
        Nanosecond, // ns
        Microsecond, // mu
        Millisecond, // ms
        Minute, // min
        Hour, // h
        Day, // d
        Week, // w
        Month, // mo
        Year, // y
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Time, string> _timeSymbols = new Dictionary<DnsToysUnits.Time, string>
    {
        { DnsToysUnits.Time.Second, "s" },
        { DnsToysUnits.Time.Nanosecond, "ns" },
        { DnsToysUnits.Time.Microsecond, "mu" },
        { DnsToysUnits.Time.Millisecond, "ms" },
        { DnsToysUnits.Time.Minute, "min" },
        { DnsToysUnits.Time.Hour, "h" },
        { DnsToysUnits.Time.Day, "d" },
        { DnsToysUnits.Time.Week, "w" },
        { DnsToysUnits.Time.Month, "mo" },
        { DnsToysUnits.Time.Year, "y" },
    };

    public static string AsSymbol(this DnsToysUnits.Time self)
    {
        if (!_timeSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _timeSymbols[self];
    }
}