using DnsToysNET.Models;

namespace DnsToysNET.Parsers;

public interface IDnsToysTimeEntryParser<TDnsToysTimeEntry> : IDnsToysEntryParser<TDnsToysTimeEntry> where TDnsToysTimeEntry : IDnsToysTimeEntry { }
public interface IDnsToysHelpEntryParser<TDnsToysHelpEntry> : IDnsToysEntryParser<TDnsToysHelpEntry> where TDnsToysHelpEntry : IDnsToysHelpEntry { }

