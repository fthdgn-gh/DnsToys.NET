using System.Net;

namespace DnsToysNET.Models;

public struct DnsToysCIDREntry : IDnsToysCIDREntry
{
    public DnsToysCIDREntry(IPAddress firstIPAddress, IPAddress lastIPAddress, ulong cost)
    {
        FirstIPAddress = firstIPAddress;
        LastIPAddress = lastIPAddress;
        Cost = cost;
    }
    public IPAddress FirstIPAddress { get; }
    public IPAddress LastIPAddress { get; }
    public ulong Cost { get; }
}
