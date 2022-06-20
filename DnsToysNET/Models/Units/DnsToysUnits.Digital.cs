namespace DnsToysNET.Models;

public sealed partial class DnsToysUnits
{
    public enum Digital
    {
        Byte, // byte
        Bit, // b
        Kilobit, // Kb
        Kilobyte, // KB
        Megabit, // Mb
        Megabyte, // MB
        Gigabit, // Gb
        Gigabyte, // GB
        Terabit, // Tb
        Terabyte, // TB
        Petabit, // Pb
        Petabyte, // PB
    }
}

public static partial class DnsToysUnitsExtensions
{
    private static readonly Dictionary<DnsToysUnits.Digital, string> _digitalSymbols = new Dictionary<DnsToysUnits.Digital, string> {
        { DnsToysUnits.Digital.Byte, "byte" },
        { DnsToysUnits.Digital.Bit, "b" },
        { DnsToysUnits.Digital.Kilobit, "Kb" },
        { DnsToysUnits.Digital.Kilobyte, "KB" },
        { DnsToysUnits.Digital.Megabit, "Mb" },
        { DnsToysUnits.Digital.Megabyte, "MB" },
        { DnsToysUnits.Digital.Gigabit, "Gb" },
        { DnsToysUnits.Digital.Gigabyte, "GB" },
        { DnsToysUnits.Digital.Terabit, "Tb" },
        { DnsToysUnits.Digital.Terabyte, "TB" },
        { DnsToysUnits.Digital.Petabit, "Pb" },
        { DnsToysUnits.Digital.Petabyte, "PB" },
    };
    public static string AsSymbol(this DnsToysUnits.Digital self)
    {
        if (!_digitalSymbols.ContainsKey(self))
            throw new ArgumentOutOfRangeException(nameof(self));
        return _digitalSymbols[self];
    }
}