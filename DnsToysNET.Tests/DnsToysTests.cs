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
    public async Task Help_GetsEntries()
    {
        _requesterMock.Setup(x => x.RequestAsync("help")).ReturnsAsync(new string[][] {
            new string[] { "hello", "there" }
        });

        var result = await sut.HelpAsync();

        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Help_GetsValidEntries()
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
}