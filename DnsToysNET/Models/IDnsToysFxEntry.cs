namespace DnsToysNET.Models;

public interface IDnsToysFxEntry : IDnsToysEntry
{
    string Currency { get; }
    string ConvertedCurrency { get; }
    double Rate { get; }
    double ConvertedRate { get; }
    DateOnly Date { get; }
}
