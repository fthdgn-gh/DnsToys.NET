using FluentAssertions;
using Moq;

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
    public async Task Time_GetsValidEntries()
    {
        _requesterMock.Setup(x => x.RequestAsync($"mumbai.time")).ReturnsAsync(new string[][] {
            new string[] { "Mumbai (Asia/Kolkata, IN)", "Sun, 12 Jun 2022 16:29:27 +0530" }
        });

        var result = await sut.TimeAsync("mumbai");

        result.Should().NotBeNull();
        result.City.Should().Be("Mumbai (Asia/Kolkata, IN)");
        result.Time.Should().Be(DateTimeOffset.Parse("Sun, 12 Jun 2022 16:29:27 +0530"));
    }
}