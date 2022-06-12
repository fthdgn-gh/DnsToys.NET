using DnsToysNET.Models;

namespace DnsToysNET.Parsers;

public class DnsToysTimeEntryParser : IDnsToysTimeEntryParser<DnsToysTimeEntry>
{
    public DnsToysTimeEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 2)
            throw new ArgumentException("rawValue must contain at least two elements");
        var city = rawValue[0];
        var time = rawValue[1];
        DateTimeOffset.TryParse(time, out var timeValue);
        return new DnsToysTimeEntry(city, timeValue);
    }
}
