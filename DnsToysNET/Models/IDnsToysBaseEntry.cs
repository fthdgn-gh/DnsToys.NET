namespace DnsToysNET.Models;

public interface IDnsToysBaseEntry : IDnsToysEntry
{
    string FromBase { get; }
    double FromValue { get; }
    string ToBase { get; }
    double ToValue { get; }
}
