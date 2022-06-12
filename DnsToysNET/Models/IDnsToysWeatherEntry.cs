namespace DnsToysNET.Models;

public interface IDnsToysWeatherEntry : IDnsToysEntry
{
    string City { get; }
    string CountryCode { get; }
    float Celsius { get; }
    float Fahrenheit { get; }
    float Humidity { get; }
    string Forecast { get; }
    TimeOnly Time { get; }
    DayOfWeek Day { get; }
}
