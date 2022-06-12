using DnsClient;
using DnsToysNET.Models;
using System.Globalization;
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

    protected async Task<IEnumerable<TIDnsToysEntry>> GetAsync<TIDnsToysEntry>(string command)
        where TIDnsToysEntry : IDnsToysEntry
    {
        var response = await _requester.RequestAsync(command);
        return response.Select(_compositeParser.Parse<TIDnsToysEntry>);
    }

    protected async Task<TIDnsToysEntry> GetFirstAsync<TIDnsToysEntry>(string command)
        where TIDnsToysEntry : IDnsToysEntry
    => (await GetAsync<TIDnsToysEntry>(command)).First();

    private const string HelpRequest = "help";
    public async Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync() => await GetAsync<IDnsToysHelpEntry>(HelpRequest);

    private const string TimeRequestFormat = "{0}.time";
    public async Task<IDnsToysTimeEntry> TimeAsync(string city) => await GetFirstAsync<IDnsToysTimeEntry>(string.Format(CultureInfo.InvariantCulture, TimeRequestFormat, city));

    private const string IpRequest = "ip";
    public async Task<IDnsToysIpEntry> IpAsync() => await GetFirstAsync<IDnsToysIpEntry>(IpRequest);

    private const string FxRequestFormat = "{0}{1}-{2}.fx";
    public async Task<IDnsToysFxEntry> FxAsync(double rate, string fromCurrencyCode, string toCurrencyCode) => await GetFirstAsync<IDnsToysFxEntry>(string.Format(CultureInfo.InvariantCulture, FxRequestFormat, rate, fromCurrencyCode, toCurrencyCode));
    
    private const string UnitRequestFormat = "{0}{1}-{2}.unit";
    public async Task<IDnsToysUnitEntry> UnitAsync(double unit, string fromSymbol, string toSymbol) => await GetFirstAsync<IDnsToysUnitEntry>(string.Format(CultureInfo.InvariantCulture, UnitRequestFormat, unit, fromSymbol, toSymbol));

    private const string WordsRequestFormat = "{0}.words";
    public async Task<IDnsToysWordsEntry> WordsAsync(int numbers) => await GetFirstAsync<IDnsToysWordsEntry>(string.Format(CultureInfo.InvariantCulture, WordsRequestFormat, numbers));
}