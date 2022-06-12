namespace DnsToysNET;

public interface IDnsToys
{
    Task<string[][]> RawAsync(string request);
}