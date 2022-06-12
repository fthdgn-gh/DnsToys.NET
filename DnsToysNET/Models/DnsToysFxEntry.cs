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
    public string Currency { get; set; }
    public string ConvertedCurrency { get; set; }
    public double Rate { get; set; }
    public double ConvertedRate { get; set; }
    public DateOnly Date { get; set; }
}
