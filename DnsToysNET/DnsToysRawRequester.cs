using DnsClient;
using System.Net;

namespace DnsToysNET;

public class DnsToysRawRequester : IDnsToysRawRequester
{
    public const string DefaultHost = "dns.toys";
    private readonly ILookupClient _client;

    public DnsToysRawRequester(string? hostNameOrAddress = null) : this(Dns.GetHostAddresses(hostNameOrAddress ?? DefaultHost).First()) { }
    public DnsToysRawRequester(IPAddress hostIpAddress) : this(new LookupClient(hostIpAddress)) { }
    public DnsToysRawRequester(ILookupClient client)
    {
        _client = client;
    }

    public async Task<string[][]> RequestAsync(string request)
    {
        var response = await _client.QueryAsync(request, QueryType.TXT);
        return response.Answers.TxtRecords().Select(x => x.EscapedText.ToArray()).ToArray();
    }
}
