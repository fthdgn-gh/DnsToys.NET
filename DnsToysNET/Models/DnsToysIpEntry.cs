using System.Net;

namespace DnsToysNET.Models;

public struct DnsToysIpEntry : IDnsToysIpEntry
{
    public DnsToysIpEntry(IPAddress requestingIP)
    {
        RequestingIP = requestingIP;
    }
    public IPAddress RequestingIP { get; }
}
