namespace DnsToysNET.Models;

public struct DnsToysWordsEntry : IDnsToysWordsEntry
{
    public DnsToysWordsEntry(int numbers, string words)
    {
        Numbers = numbers;
        Words = words;
    }

    public int Numbers { get; }
    public string Words { get; }
}
