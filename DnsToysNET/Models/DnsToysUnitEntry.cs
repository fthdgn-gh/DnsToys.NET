namespace DnsToysNET.Models;

public struct DnsToysUnitEntry : IDnsToysUnitEntry
{
    public DnsToysUnitEntry(string unit, string symbol, double value, string convertedUnit, string convertedSymbol, double convertedValue)
    {
        Unit = unit;
        Symbol = symbol;
        Value = value;
        ConvertedUnit = convertedUnit;
        ConvertedSymbol = convertedSymbol;
        ConvertedValue = convertedValue;
    }
    public string Unit { get; }
    public string Symbol { get; }
    public double Value { get; }
    public string ConvertedUnit { get; }
    public string ConvertedSymbol { get; }
    public double ConvertedValue { get; }
}
