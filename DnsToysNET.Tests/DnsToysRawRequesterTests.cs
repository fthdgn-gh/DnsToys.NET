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
        var result = await sut.RequestAsync("help");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsTime()
    {
        var result = await sut.RequestAsync("mumbai.time");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsWeather()
    {
        var result = await sut.RequestAsync("newyork.weather");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsUnit()
    {
        var result = await sut.RequestAsync("42km-mi.unit");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsFx()
    {
        var result = await sut.RequestAsync("100USD-INR.fx");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsIp()
    {
        var result = await sut.RequestAsync("ip");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsWords()
    {
        var result = await sut.RequestAsync("987654321.words");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsPi()
    {
        var result = await sut.RequestAsync("pi");
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Raw_GetsBase()
    {
        var result = await sut.RequestAsync("100dec-hex.base");
        result.Should().NotBeEmpty();
    }
}
