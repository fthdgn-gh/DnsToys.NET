using FluentAssertions;
using Moq;
using System.Net;

namespace DnsToysNET.Tests;

public class DnsToysTests
{
    private readonly Mock<IDnsToysRawRequester> _requesterMock;
    private readonly DnsToys sut;
    public DnsToysTests()
    {
        _requesterMock = new Mock<IDnsToysRawRequester>();
        sut = new DnsToys(_requesterMock.Object);
    }

    [Fact]
    public async Task Help_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync("help")).ReturnsAsync(new string[][] {
            new string[] { "hello", "dig there @dns.toys" }
        });

        var result = await sut.HelpAsync();

        result.Should().NotBeEmpty();
        var entry = result.FirstOrDefault();
        entry.Should().NotBeNull();
        entry!.Description.Should().Be("hello");
        entry!.SampleRequest.Should().Be("there");
    }

    [Fact]
    public async Task Time_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"mumbai.time")).ReturnsAsync(new string[][] {
            new string[] { "Mumbai (Asia/Kolkata, IN)", "Sun, 12 Jun 2022 16:29:27 +0530" }
        });

        var result = await sut.TimeAsync("mumbai");

        result.Should().NotBeNull();
        result.City.Should().Be("Mumbai (Asia/Kolkata, IN)");
        result.Time.Should().Be(DateTimeOffset.Parse("Sun, 12 Jun 2022 16:29:27 +0530"));
    }

    [Fact]
    public async Task Ip_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"ip")).ReturnsAsync(new string[][] {
            new string[] { "127.0.0.1" }
        });

        var result = await sut.IpAsync();

        result.Should().NotBeNull();
        result.RequestingIP.Should().Be(IPAddress.Parse("127.0.0.1"));
    }

    [Fact]
    public async Task Fx_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"99.12USD-INR.fx")).ReturnsAsync(new string[][] {
            new string[] { "99.12 USD = 7743.30 INR", "2022-06-12" }
        });

        var result = await sut.FxAsync(99.12, "USD", "INR");

        result.Should().NotBeNull();
        result.Currency.Should().Be("USD");
        result.Rate.Should().Be(99.12);
        result.ConvertedCurrency.Should().Be("INR");
        result.ConvertedRate.Should().Be(7743.30);
        result.Date.Should().Be(DateOnly.Parse("2022-06-12"));
    }

    [Fact]
    public async Task Unit_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"42.3km-cm.unit")).ReturnsAsync(new string[][] {
            new string[] { "42.30 Kilometer (km) = 4229999.92 Centimeter (cm)" }
        });

        var result = await sut.UnitAsync(42.3, "km", "cm");

        result.Should().NotBeNull();
        result.Value.Should().Be(42.3);
        result.Unit.Should().Be("Kilometer");
        result.Symbol.Should().Be("km");

        result.ConvertedValue.Should().Be(4229999.92);
        result.ConvertedUnit.Should().Be("Centimeter");
        result.ConvertedSymbol.Should().Be("cm");
    }

    [Fact]
    public async Task Words_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"123.words")).ReturnsAsync(new string[][] {
            new string[] { "123 = one hundred twenty-three" }
        });

        var result = await sut.WordsAsync(123);

        result.Should().NotBeNull();
        result.Numbers.Should().Be(123);
        result.Words.Should().Be("one hundred twenty-three");
    }

    [Fact]
    public async Task CIDR_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"10.100.0.0/24.cidr")).ReturnsAsync(new string[][] {
            new string[] {  "10.100.0.1","10.100.0.254", "256" }
        });

        var result = await sut.CIDRAsync("10.100.0.0", 24);

        result.Should().NotBeNull();
        result.FirstIPAddress.Should().Be(IPAddress.Parse("10.100.0.1"));
        result.LastIPAddress.Should().Be(IPAddress.Parse("10.100.0.254"));
        result.Cost.Should().Be(256);
    }

    [Fact]
    public async Task Weather_GetsValidEntry()
    {
        _requesterMock.Setup(x => x.RequestAsync($"berlin.weather")).ReturnsAsync(new string[][] {
            new string[] { "Berlin (DE)", "26.00C (78.80F)", "31.10% hu.", "partlycloudy_day","17:00, Sun" }
        });

        var result = await sut.WeatherAsync("berlin");

        result.Should().NotBeNull();
        var entry = result.FirstOrDefault();
        entry.Should().NotBeNull();
        entry!.City.Should().Be("Berlin");
        entry!.CountryCode.Should().Be("DE");
        entry!.Celsius.Should().Be(26f);
        entry!.Fahrenheit.Should().Be(78.80f);
        entry!.Humidity.Should().Be(31.10f);
        entry!.Forecast.Should().Be("partlycloudy_day");
        entry!.Time.Should().Be(TimeOnly.Parse("17:00"));
        entry!.Day.Should().Be(DayOfWeek.Sunday);
    }
}