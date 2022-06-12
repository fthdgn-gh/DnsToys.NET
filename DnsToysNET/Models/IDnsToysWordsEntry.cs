namespace DnsToysNET.Models;

public interface IDnsToysWordsEntry : IDnsToysEntry
{
    int Numbers { get; }
    string Words { get; }
}
