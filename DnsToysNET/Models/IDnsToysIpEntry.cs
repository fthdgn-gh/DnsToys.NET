
using System.Net;

namespace DnsToysNET.Models;

public interface IDnsToysIpEntry : IDnsToysEntry
{
    IPAddress RequestingIP { get; }
}
