namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Mass
    {
        Gram, // g
        MetricTon, // t
        Kilogram, // kg
        Milligram, // mg
        Microgram, // mug
        LongTon, // lt
        ShortTon, // st
        Stone, // sto
        Pound, // lb
        Ounce // oz
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Mass, string> _massSymbols = new Dictionary<DnsToysUnits.Mass, string> 
    {
        { DnsToysUnits.Mass.Gram, "g" },
        { DnsToysUnits.Mass.MetricTon, "t" },
        { DnsToysUnits.Mass.Kilogram, "kg" },
        { DnsToysUnits.Mass.Milligram, "mg" },
        { DnsToysUnits.Mass.Microgram, "mug" },
        { DnsToysUnits.Mass.LongTon, "lt" },
        { DnsToysUnits.Mass.ShortTon, "st" },
        { DnsToysUnits.Mass.Stone, "sto" },
        { DnsToysUnits.Mass.Pound, "lb" },
        { DnsToysUnits.Mass.Ounce, "oz" },
    };
    public static string AsSymbol(this DnsToysUnits.Mass self)
    {
        if (!_massSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _massSymbols[self];
    }
}