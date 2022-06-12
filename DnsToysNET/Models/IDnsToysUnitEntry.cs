namespace DnsToysNET.Models;

public interface IDnsToysUnitEntry : IDnsToysEntry
{
    string Unit { get; }
    string Symbol { get; }
    double Value { get; }
    string ConvertedUnit { get; }
    string ConvertedSymbol { get; }
    double ConvertedValue { get; }
}
