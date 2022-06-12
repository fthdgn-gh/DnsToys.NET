namespace DnsToysNET.Models;

public struct DnsToysTimeEntry : IDnsToysTimeEntry
{
    public DnsToysTimeEntry(string city, DateTimeOffset time)
    {
        City = city;
        Time = time;
    }
    public string City { get; }
    public DateTimeOffset Time { get; }
}

