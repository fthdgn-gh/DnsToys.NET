namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Volume
    {
        CubicMeter, // m3
        USGallon, // gal
        USPint, // pt
        USOz, // oz
        USTablespoon, // tbsp
        USTeaspoon, // tsp
        Liter, // l
        Milliliter, // ml
        ImperialGallon, // igal
        ImperialPint, // ipt
        ImperialOz, // ioz
        ImperialTablespoon, // itbsp
        ImperialTeaspoon, // itsp
        CubicFoot, // ft3
        CubicInch // In3
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Volume, string> _volumeSymbols = new Dictionary<DnsToysUnits.Volume, string>
    {
        { DnsToysUnits.Volume.CubicMeter, "m3" },
        { DnsToysUnits.Volume.USGallon, "gal" },
        { DnsToysUnits.Volume.USPint, "pt" },
        { DnsToysUnits.Volume.USOz, "oz" },
        { DnsToysUnits.Volume.USTablespoon, "tbsp" },
        { DnsToysUnits.Volume.USTeaspoon, "tsp" },
        { DnsToysUnits.Volume.Liter, "l" },
        { DnsToysUnits.Volume.Milliliter, "ml" },
        { DnsToysUnits.Volume.ImperialGallon, "igal" },
        { DnsToysUnits.Volume.ImperialPint, "ipt" },
        { DnsToysUnits.Volume.ImperialOz, "ioz" },
        { DnsToysUnits.Volume.ImperialTablespoon, "itbsp" },
        { DnsToysUnits.Volume.ImperialTeaspoon, "itsp" },
        { DnsToysUnits.Volume.CubicFoot, "ft3" },
        { DnsToysUnits.Volume.CubicInch, "In3" }
    };

    public static string AsSymbol(this DnsToysUnits.Volume self)
    {
        if (!_volumeSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _volumeSymbols[self];
    }
}