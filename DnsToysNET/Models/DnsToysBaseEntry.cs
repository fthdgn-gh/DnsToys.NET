namespace DnsToysNET.Models;

public struct DnsToysBaseEntry : IDnsToysBaseEntry
{
    public DnsToysBaseEntry(string fromBase, double fromValue, string toBase, double toValue)
    {
        FromBase = fromBase;
        FromValue = fromValue;
        ToBase = toBase;
        ToValue = toValue;
    }

    public string FromBase { get; }
    public double FromValue { get; }
    public string ToBase { get; }
    public double ToValue { get; }
}
