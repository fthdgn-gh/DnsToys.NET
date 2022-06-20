using DnsToysNET.Models;

namespace DnsToysNET;

public interface IDnsToys
{
    Task<IEnumerable<IDnsToysHelpEntry>> HelpAsync();
    Task<IDnsToysTimeEntry> TimeAsync(string city);
    Task<IDnsToysIpEntry> IpAsync();
    Task<IDnsToysFxEntry> FxAsync(double rate, string fromCurrencyCode, string toCurrencyCode);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, string fromSymbol, string toSymbol);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Area from, DnsToysUnits.Area to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Digital from, DnsToysUnits.Digital to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Length from, DnsToysUnits.Length to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Mass from, DnsToysUnits.Mass to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Speed from, DnsToysUnits.Speed to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Time from, DnsToysUnits.Time to);
    Task<IDnsToysUnitEntry> UnitAsync(double unit, DnsToysUnits.Volume from, DnsToysUnits.Volume to);
    Task<IDnsToysWordsEntry> WordsAsync(int numbers);
    Task<IDnsToysCIDREntry> CIDRAsync(string cidr);
    Task<IDnsToysCIDREntry> CIDRAsync(string ipAddress, byte bits);
    Task<IEnumerable<IDnsToysWeatherEntry>> WeatherAsync(string city);
    Task<IDnsToysPIEntry> PIAsync();
    Task<IDnsToysBaseEntry> BaseAsync(double value, string fromBase, string toBase);
}