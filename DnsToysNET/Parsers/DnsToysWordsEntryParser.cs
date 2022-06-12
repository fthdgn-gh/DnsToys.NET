using DnsToysNET.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysWordsEntryParser : IDnsToysWordsEntryParser
{
    private readonly static Regex ConversionParser = new Regex(@"(?'numbers'\d+)\s[=]\s(?'words'[a-zA-Z -]+)", RegexOptions.Compiled | RegexOptions.Singleline);
    public IDnsToysWordsEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 1)
            throw new ArgumentException("rawValue must contain at least two elements");
        var conversion = rawValue[0];
        var match = ConversionParser.Match(conversion);
        if (match is null || !match.Success) throw new InvalidDataException("Conversion value doesn't match the format");

        string numbers = match!.Groups!.GetValueOrDefault(nameof(numbers), null)?.Value ?? string.Empty;
        string words = match!.Groups!.GetValueOrDefault(nameof(words), null)?.Value ?? string.Empty;

        int.TryParse(numbers, NumberStyles.Any, CultureInfo.InvariantCulture, out var dNumbers);
        return new DnsToysWordsEntry(dNumbers, words);
    }
}
