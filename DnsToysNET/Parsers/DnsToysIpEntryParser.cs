using DnsToysNET.Models;
using System.Net;

namespace DnsToysNET.Parsers;

public class DnsToysIpEntryParser : IDnsToysIpEntryParser
{
    public IDnsToysIpEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 1)
            throw new ArgumentException("rawValue must contain at least one element");
        var requestingIp = rawValue[0];
        if (string.IsNullOrWhiteSpace(requestingIp))
            throw new ArgumentException("requestingIp must not be null or empty");
        return new DnsToysIpEntry(IPAddress.Parse(requestingIp));
    }
}
