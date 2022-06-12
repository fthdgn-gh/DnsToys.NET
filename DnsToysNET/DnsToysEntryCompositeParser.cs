using DnsToysNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnsToysNET
{
    public class DnsToysEntryCompositeParser : IDnsToysEntryCompositeParser
    {
        private readonly Dictionary<Type, object> parsers = new Dictionary<Type, object>();
        public TDnsToysEntry Parse<TDnsToysEntry>(string[] rawValue) where TDnsToysEntry : IDnsToysEntry
        {
            if (parsers.TryGetValue(typeof(TDnsToysEntry), out var parser))
            {
                return ((IDnsToysEntryParser<TDnsToysEntry>)parser).Parse(rawValue);
            }
            else
                throw new KeyNotFoundException("Parser is not registered");
        }

        public IDnsToysEntryCompositeParser Register<TDnsToysEntry>(IDnsToysEntryParser<TDnsToysEntry> parser) where TDnsToysEntry : IDnsToysEntry
        {
            parsers[typeof(TDnsToysEntry)] = parser;
            return this;
        }

        public IDnsToysEntryCompositeParser Unregister<TDnsToysEntry>() where TDnsToysEntry : IDnsToysEntry
        {
            var type = typeof(TDnsToysEntry);
            if (parsers.ContainsKey(type))
                parsers.Remove(type);
            return this;
        }
    }
}
