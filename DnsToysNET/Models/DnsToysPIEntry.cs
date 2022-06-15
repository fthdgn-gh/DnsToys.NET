namespace DnsToysNET.Models;

public struct DnsToysPIEntry : IDnsToysPIEntry
{
    public DnsToysPIEntry(double pi)
    {
        PI = pi;
    }
    public double PI { get; }
}
