using DnsToysNET.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysBaseEntryParser : IDnsToysBaseEntryParser
{
    private readonly static Regex ConversionParser = new Regex(@"(?'fromValue'\d+)\s(?'fromBase'\w+)\s[=]\s(?'toValue'\d+)\s(?'toBase'\w+)", RegexOptions.Compiled | RegexOptions.Singleline);
    public IDnsToysBaseEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 1)
            throw new ArgumentException("rawValue must contain at least two elements");
        var conversion = rawValue[0];
        var match = ConversionParser.Match(conversion);
        if (match is null || !match.Success) throw new InvalidDataException("Conversion value doesn't match the format");

        string fromValue = match!.Groups![nameof(fromValue)]?.Value ?? string.Empty;
        string fromBase = match!.Groups![nameof(fromBase)]?.Value ?? string.Empty;
        string toValue = match!.Groups![nameof(toValue)]?.Value ?? string.Empty;
        string toBase = match!.Groups![nameof(toBase)]?.Value ?? string.Empty;
        
        double.TryParse(fromValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var dFromValue);
        double.TryParse(toValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var dToValue);
        return new DnsToysBaseEntry(fromBase, dFromValue, toBase, dToValue);
    }
}
