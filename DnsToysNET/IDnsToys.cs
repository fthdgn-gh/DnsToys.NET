using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToys
{
    Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync();
    Task<IDnsToysTimeEntry> TimeAsync(string city);
    Task<IDnsToysIpEntry> IpAsync();
    Task<IDnsToysFxEntry> FxAsync(double rate, string fromCurrencyCode, string toCurrencyCode);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, string fromSymbol, string toSymbol);
}