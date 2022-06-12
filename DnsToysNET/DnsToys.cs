using DnsClient;
using System.Net;

namespace DnsToysNET;

public class DnsToys : IDnsToys
{
    public const string DefaultHost = "dns.toys";
    private readonly string _host;
    private readonly ILookupClient _client;

    public DnsToys(string? host = null)
    {
        _host = host ?? DefaultHost;
        _client = new LookupClient(Dns.GetHostAddresses(_host).First());
    }
    
    public async Task<string[][]> RawAsync(string request)
    {
        var response = await _client.QueryAsync(request, QueryType.TXT);
        return response.Answers.TxtRecords().Select(x => x.EscapedText.ToArray()).ToArray();
    }
}