namespace DnsToysNET.Tests
{
    public class DnsToysTests
    {
        DnsToys sut;
        public DnsToysTests()
        {
            sut = new DnsToys();
        }
        
        [Fact]
        public async Task Raw_GetsHelp()
        {
            var result = await sut.RawAsync("help");
        }
    }
}