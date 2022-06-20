namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Area
    {
        SquareMeter, // sqm
        SquareKilometer, // sqkm
        Hectare, // ha
        SquareMile, // sqmi
        Acre, // ac
        SquareYard, // sqyd
        SquareFoot, // sqft
        SquareInch, // sqin
        Cent // ct
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Area, string> _areaSymbols = new Dictionary<DnsToysUnits.Area, string> {
        { DnsToysUnits.Area.SquareMeter, "sqm" },
        { DnsToysUnits.Area.SquareKilometer, "sqkm" },
        { DnsToysUnits.Area.Hectare, "ha" },
        { DnsToysUnits.Area.SquareMile, "sqmi" },
        { DnsToysUnits.Area.Acre, "ac" },
        { DnsToysUnits.Area.SquareYard, "sqyd" },
        { DnsToysUnits.Area.SquareFoot, "sqft" },
        { DnsToysUnits.Area.SquareInch, "sqin" },
        { DnsToysUnits.Area.Cent, "ct" },

    };
    public static string AsSymbol(this DnsToysUnits.Area self)
    {
        if (!_areaSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _areaSymbols[self];
    }
}