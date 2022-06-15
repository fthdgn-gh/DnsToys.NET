using DnsToysNET.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysPIEntryParser : IDnsToysPIEntryParser
{
    public IDnsToysPIEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 1)
            throw new ArgumentException("rawValue must contain at least two elements");
        var value = rawValue[0];
        double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out var dValue);
        return new DnsToysPIEntry(dValue);
    }
}
