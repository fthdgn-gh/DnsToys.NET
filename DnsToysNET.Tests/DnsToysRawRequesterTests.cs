using FluentAssertions;

namespace DnsToysNET.Tests;

public class DnsToysRawRequesterTests
{
    private readonly DnsToysRawRequester sut;
    public DnsToysRawRequesterTests()
    {
        sut = new DnsToysRawRequester();
    }
    
    [Fact]
    public async Task Raw_GetsHelp()
    {
        var result = await sut.RequestAsync("ip");
        result.Should().NotBeEmpty();
    }
}
