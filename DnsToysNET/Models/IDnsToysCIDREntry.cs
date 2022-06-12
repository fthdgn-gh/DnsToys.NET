using System.Net;

namespace DnsToysNET.Models;

public interface IDnsToysCIDREntry : IDnsToysEntry
{
    IPAddress FirstIPAddress { get; }
    IPAddress LastIPAddress { get; }
    ulong Cost { get; }
}
