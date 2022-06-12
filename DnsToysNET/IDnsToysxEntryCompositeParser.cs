using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToysEntryCompositeParser
{
    public TDnsToysEntry Parse<TDnsToysEntry>(string[] rawValue) where TDnsToysEntry : IDnsToysEntry;
    public IDnsToysEntryCompositeParser Register<TDnsToysEntry>(IDnsToysEntryParser<TDnsToysEntry> parser) where TDnsToysEntry : IDnsToysEntry;
    public IDnsToysEntryCompositeParser Unregister<TDnsToysEntry>() where TDnsToysEntry : IDnsToysEntry;
}
