using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToysEntryParser<TEntry>
    where TEntry : IDnsToysEntry
{
    TEntry Parse(string[] rawValue);
}
