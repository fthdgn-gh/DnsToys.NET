<img width="150" src="https://raw.githubusercontent.com/fatihdgn/DnsToys.NET/master/icon.png?token=GHSAT0AAAAAABSXPGES74CS7A5LNXYCQVDUYVGEPUQ" />
<img height="20" src="https://img.shields.io/nuget/v/DnsToys" 

DnsToys.NET is a simple library for the [dns.toys](https://github.com/knadh/dns.toys) service.

## Install

You can install DnsToys.NET through [NuGet](https://www.nuget.org/packages/DnsToys).

Supported frameworks are; 
- .NET 6 and 5
- .NET Standard 2.1 and 2.0
- .NET Framework 4.7.1

Here are the available options.

### Using Package Manager
``` sh
Install-Package DnsToys
```

### Using .NET CLI
``` sh
dotnet add package DnsToys
```


### Using Paket CLI
``` sh
paket add DnsToys
```

### Using Cake
``` sh
// Install DnsToys as a Cake Addin
#addin nuget:?package=DnsToys&version=1.0.0

// Install DnsToys as a Cake Tool
#tool nuget:?package=DnsToys&version=1.0.0
```

## Getting Started
You can use the ```DnsToys``` class' parameterless constructor directly. Sample below fetches the current requesting IP using the service.

```
using System.Net;
using DnsToysNET;
using DnsToysNET.Models;

...

IDnsToys client = new DnsToys();
IDnsToysIpEntry result = await client.IpAsync();
IPAddress requestingIP = result.RequestingIP;
```

### Currently Supported dns.toys Services
- help
- time
- ip
- fx
- unit
- words
- cidr
- weather
- pi
- base

## Testing
Library is developed with unit testing in mind, so you can mock all the models, parsers, raw requester and the main client itself.
