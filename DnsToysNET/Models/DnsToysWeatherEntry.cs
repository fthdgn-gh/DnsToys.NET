namespace DnsToysNET.Models;

public struct DnsToysWeatherEntry : IDnsToysWeatherEntry
{
    public DnsToysWeatherEntry(string city, string countryCode, float celsius, float fahrenheit, float humidity, string forecast, TimeOnly time, DayOfWeek day)
    {
        City = city;
        CountryCode = countryCode;
        Celsius = celsius;
        Fahrenheit = fahrenheit;
        Humidity = humidity;
        Forecast = forecast;
        Time = time;
        Day = day;
    }
    public string City { get; }
    public string CountryCode { get; }
    public float Celsius { get; }
    public float Fahrenheit { get; }
    public float Humidity { get; }
    public string Forecast { get; }
    public TimeOnly Time { get; }
    public DayOfWeek Day { get; }
}
