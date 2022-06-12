namespace DnsToysNET.Models;

public struct DnsToysHelpEntry : IDnsToysHelpEntry
{
    public DnsToysHelpEntry(string description, string sampleRequest)
    {
        Description = description;
        SampleRequest = sampleRequest;
    }
    public string Description { get; }
    public string SampleRequest { get; }
}
