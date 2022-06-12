namespace DnsToysNET.Models;

public interface IDnsToysTimeEntry : IDnsToysEntry
{
    string City { get; }
    DateTimeOffset Time { get; }
}

