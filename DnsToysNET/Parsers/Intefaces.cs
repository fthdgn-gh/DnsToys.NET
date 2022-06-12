using DnsToysNET.Models;

namespace DnsToysNET.Parsers;

public interface IDnsToysTimeEntryParser : IDnsToysEntryParser<IDnsToysTimeEntry> { }
public interface IDnsToysHelpEntryParser : IDnsToysEntryParser<IDnsToysHelpEntry> { }
public interface IDnsToysIpEntryParser : IDnsToysEntryParser<IDnsToysIpEntry> { }
public interface IDnsToysFxEntryParser : IDnsToysEntryParser<IDnsToysFxEntry> { }
public interface IDnsToysUnitEntryParser : IDnsToysEntryParser<IDnsToysUnitEntry> { }
public interface IDnsToysWordsEntryParser : IDnsToysEntryParser<IDnsToysWordsEntry> { }

