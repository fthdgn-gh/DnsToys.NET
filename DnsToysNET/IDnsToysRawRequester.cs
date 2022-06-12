namespace DnsToysNET;

public interface IDnsToysRawRequester
{
    Task<string[][]> RequestAsync(string request);
}
