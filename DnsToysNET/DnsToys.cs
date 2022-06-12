using DnsClient;
using DnsToysNET.Models;
using System.Net;

namespace DnsToysNET;

public class DnsToys : IDnsToys
{
    private readonly IDnsToysRawRequester _requester;
    private readonly IDnsToysEntryCompositeParser _compositeParser;

    public DnsToys(string? host = null, IDnsToysEntryCompositeParser? compositeParser = null) : this(new DnsToysRawRequester(host), compositeParser) { }
    public DnsToys(IPAddress hostIpAddress, IDnsToysEntryCompositeParser? compositeParser = null) : this(new DnsToysRawRequester(hostIpAddress), compositeParser) { }
    public DnsToys(ILookupClient client, IDnsToysEntryCompositeParser? compositeParser = null) : this(new DnsToysRawRequester(client), compositeParser) { }
    public DnsToys(IDnsToysRawRequester requester, IDnsToysEntryCompositeParser? compositeParser = null)
    {
        _requester = requester ?? throw new ArgumentNullException(nameof(requester));
        _compositeParser = compositeParser ?? new DefaultDnsToysEntryCompositeParser();
    }

    protected async Task<IEnumerable<TIDnsToysEntry>> GetAsync<TDnsToysEntry, TIDnsToysEntry>(string command)
        where TDnsToysEntry : TIDnsToysEntry
        where TIDnsToysEntry : IDnsToysEntry
    {
        var response = await _requester.RequestAsync(command);
        return response.Select(_compositeParser.Parse<TDnsToysEntry>).Cast<TIDnsToysEntry>();
    }

    private const string HelpRequest = "help";
    public async Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync() => await GetAsync<DnsToysHelpEntry, IDnsToysHelpEntry>(HelpRequest);

    private const string TimeRequestFormat = "{0}.time";
    public async Task<IDnsToysTimeEntry> TimeAsync(string city) => (await GetAsync<DnsToysTimeEntry, IDnsToysTimeEntry>(string.Format(TimeRequestFormat, city))).First();
}