using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToys
{
    Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync();
    Task<IDnsToysTimeEntry> TimeAsync(string city);
    Task<IDnsToysIpEntry> IpAsync();
    Task<IDnsToysFxEntry> FxAsync(double rate, string from, string to);
}