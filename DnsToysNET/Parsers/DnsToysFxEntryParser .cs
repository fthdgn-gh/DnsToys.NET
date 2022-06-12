using DnsToysNET.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysFxEntryParser : IDnsToysFxEntryParser
{
    private readonly static Regex ConversionParser = new Regex(@"(?'rate'\d+[.]\d+)\s(?'currency'\w+)\s[=]\s(?'convertedRate'\d+[.]\d+)\s(?'convertedCurrency'\w+)", RegexOptions.Compiled | RegexOptions.Singleline);
    public IDnsToysFxEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 1)
            throw new ArgumentException("rawValue must contain at least two elements");
        var conversion = rawValue[0];
        var date = rawValue[1];
        var match = ConversionParser.Match(conversion);
        if (match is null) throw new InvalidCastException("Conversion value doesn't match the format");
        if (!match.Success) throw new InvalidCastException("Conversion value doesn't match the format");

        string rate = match!.Groups!.GetValueOrDefault(nameof(rate), null)?.Value ?? string.Empty;
        string currency = match!.Groups!.GetValueOrDefault(nameof(currency), null)?.Value ?? string.Empty;
        string convertedRate = match!.Groups!.GetValueOrDefault(nameof(convertedRate), null)?.Value ?? string.Empty;
        string convertedCurrency = match!.Groups!.GetValueOrDefault(nameof(convertedCurrency), null)?.Value ?? string.Empty;



        double.TryParse(rate, NumberStyles.Any, CultureInfo.InvariantCulture, out var dRate);
        double.TryParse(convertedRate, NumberStyles.Any, CultureInfo.InvariantCulture, out var dConvertedRate);
        DateOnly.TryParse(date, out var dateValue);
        return new DnsToysFxEntry(currency, convertedCurrency, dRate, dConvertedRate, dateValue);
    }
}
