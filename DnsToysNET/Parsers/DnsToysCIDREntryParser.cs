using DnsToysNET.Models;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysCIDREntryParser : IDnsToysCIDREntryParser
{
    public IDnsToysCIDREntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 3)
            throw new ArgumentException("rawValue must contain at least two elements");
        var firstIpAddress = rawValue[0];
        var lastIpAddress = rawValue[1];
        var cost = rawValue[2];

        if (!IPAddress.TryParse(firstIpAddress, out var iaFirstIpAddress))
            throw new ArgumentException("firstIpAddress is not a valid IP address");
        if (!IPAddress.TryParse(lastIpAddress, out var iaLastIpAddress))
            throw new ArgumentException("lastIpAddress is not a valid IP address");
        ulong.TryParse(cost, NumberStyles.Any, CultureInfo.InvariantCulture, out var uCost);
        return new DnsToysCIDREntry(iaFirstIpAddress, iaLastIpAddress, uCost);
    }
}
