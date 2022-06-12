namespace DnsToysNET.Models;

public interface IDnsToysHelpEntry : IDnsToysEntry
{
    string Description { get; }
    string SampleRequest { get; }
}
