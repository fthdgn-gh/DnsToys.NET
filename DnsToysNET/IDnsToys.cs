using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToys
{
    Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync();
    Task<IDnsToysTimeEntry> TimeAsync(string city);
}