namespace DnsToysNET.Models;

public struct DnsToysFxEntry : IDnsToysFxEntry
{
    public DnsToysFxEntry(string currency, string convertedCurrency, double rate, double convertedRate, DateOnly date)
    {
        Currency = currency;
        ConvertedCurrency = convertedCurrency;
        Rate = rate;
        ConvertedRate = convertedRate;
        Date = date;
    }
    public string Currency { get; }
    public string ConvertedCurrency { get; }
    public double Rate { get; }
    public double ConvertedRate { get; }
    public DateOnly Date { get; }
}
