MediaThor
=======

[![Build Status](https://ci.appveyor.com/api/projects/status/github/jbogard/MediaThor?branch=master&svg=true)](https://ci.appveyor.com/project/jbogard/MediaThor) 
[![NuGet](https://img.shields.io/nuget/dt/MediaThor.svg)](https://www.nuget.org/packages/MediaThor) 
[![NuGet](https://img.shields.io/nuget/vpre/MediaThor.svg)](https://www.nuget.org/packages/MediaThor)

Simple mediator implementation in .NET

In-process messaging with no dependencies.

Supports request/response, commands, queries, notifications and events, synchronous and async with intelligent dispatching via C# generic variance.

Examples in the [wiki](https://github.com/jbogard/MediaThor/wiki).

### Installing MediaThor

You should install [MediaThor with NuGet](https://www.nuget.org/packages/MediaThor):

    Install-Package MediaThor
    
Or via the .NET Core command line interface:

    dotnet add package MediaThor

Either commands, from Package Manager Console or .NET Core CLI, will download and install MediaThor and all required dependencies.
