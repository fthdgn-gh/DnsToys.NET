using DnsToysNET.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DnsToysNET.Parsers;

public class DnsToysWeatherEntryParser : IDnsToysWeatherEntryParser
{
    private readonly static Regex CityAndCountryCodeParser = new Regex(@"(?'city'[a-zA-Z]+)\s[(](?'countryCode'[a-zA-Z]+)[)]", RegexOptions.Compiled | RegexOptions.Singleline);
    private readonly static Regex TemperatureParser = new Regex(@"(?'celsius'\d+[.]\d+)C\s[(](?'fahrenheit'\d+[.]\d+)F[)]", RegexOptions.Compiled | RegexOptions.Singleline);
    private readonly static Regex HumidityParser = new Regex(@"(?'humidity'\d+[.]\d+)% hu\.", RegexOptions.Compiled | RegexOptions.Singleline);
    private readonly static Regex TimeAndDayParser = new Regex(@"(?'time'\d+:\d+),\s(?'day'\w+)", RegexOptions.Compiled | RegexOptions.Singleline);
    public IDnsToysWeatherEntry Parse(string[] rawValue)
    {
        if (rawValue.Length < 5)
            throw new ArgumentException("rawValue must contain at least five elements");
        var cityAndCountryCode = rawValue[0];
        var temperature = rawValue[1];
        var humidityRawValue = rawValue[2];
        var forecast = rawValue[3];
        var timeAndDay = rawValue[4];
        
        var cityAndCountryCodeMatch = CityAndCountryCodeParser.Match(cityAndCountryCode);
        if (cityAndCountryCodeMatch is null || !cityAndCountryCodeMatch.Success) throw new InvalidDataException("City and country code value doesn't match the format");

        var temperatureMatch = TemperatureParser.Match(temperature);
        if (temperatureMatch is null || !temperatureMatch.Success) throw new InvalidDataException("Temperature value doesn't match the format");

        var humidityMatch = HumidityParser.Match(humidityRawValue);
        if (humidityMatch is null || !humidityMatch.Success) throw new InvalidDataException("Humidity value doesn't match the format");

        var timeAndDayMatch = TimeAndDayParser.Match(timeAndDay);
        if (timeAndDayMatch is null || !timeAndDayMatch.Success) throw new InvalidDataException("Time and day value doesn't match the format");

        string city = cityAndCountryCodeMatch!.Groups![nameof(city)]?.Value ?? string.Empty;
        string countryCode = cityAndCountryCodeMatch!.Groups![nameof(countryCode)]?.Value ?? string.Empty;
        string celsius = temperatureMatch!.Groups![nameof(celsius)]?.Value ?? string.Empty;
        string fahrenheit = temperatureMatch!.Groups![nameof(fahrenheit)]?.Value ?? string.Empty;
        string humidity = humidityMatch!.Groups![nameof(humidity)]?.Value ?? string.Empty;
        string time = timeAndDayMatch!.Groups![nameof(time)]?.Value ?? string.Empty;
        string day = timeAndDayMatch!.Groups![nameof(day)]?.Value ?? string.Empty;

        float.TryParse(celsius, NumberStyles.Any, CultureInfo.InvariantCulture, out var fCelsius);
        float.TryParse(fahrenheit, NumberStyles.Any, CultureInfo.InvariantCulture, out var fFahrenheit);
        float.TryParse(humidity, NumberStyles.Any, CultureInfo.InvariantCulture, out var fHumidity);
        TimeOnly.TryParse(time, out var toTime);
        var dowDay = DayOfWeekFromAbbreviation(day);
        return new DnsToysWeatherEntry(city, countryCode, fCelsius, fFahrenheit, fHumidity, forecast, toTime, dowDay);
    }

    private DayOfWeek DayOfWeekFromAbbreviation(string abbreviation)
    {
        switch (abbreviation)
        {
            case "Mon":
                return DayOfWeek.Monday;
            case "Tue":
                return DayOfWeek.Tuesday;
            case "Wed":
                return DayOfWeek.Wednesday;
            case "Thu":
                return DayOfWeek.Thursday;
            case "Fri":
                return DayOfWeek.Friday;
            case "Sat":
                return DayOfWeek.Saturday;
            case "Sun":
                return DayOfWeek.Sunday;
            default:
                throw new InvalidDataException("Day of week abbreviation is not valid");
        }
    }
}
