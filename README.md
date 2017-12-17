# libsndfile.NET

This is [libsndfile](https://github.com/erikd/libsndfile) for .NET :)

[![NuGet](https://img.shields.io/badge/nuget-v1.0.1-blue.svg)](https://www.nuget.org/packages/libsndfile.NET/1.0.1)

## Features
- fully-featured libsndfile: full API and all additional formats are supported (FLAC, Ogg/Vorbis)
- friendly interface with patterns familiar to .NET coders, no need to deal with pointers whatsoever
- supported frameworks: .NET Core, Windows Classic Desktop, Windows Universal (see notes)
- supported platforms: AnyCPU, x86, x64

## Requirements

[Microsoft Visual C++ Redistributable for Visual Studio 2017](https://www.visualstudio.com/downloads/) for the native libraries.

## Notes
 - basic features have been tested thoroughly
 - advanced features like special tags reading needs further testing
 - for now the only documentation available is the [official one](http://www.mega-nerd.com/libsndfile/api.html)
 - currently the NuGet package configuration is `Debug` but libsndfile itself is `Release`, this will be addressed soon
 - UWP support is somehow limited because of [storage restrictions](https://trac.ffmpeg.org/wiki/CompilationGuide/WinRT#WindowsStoreCertificationFileIOandOtherDetails), the [`SfVirtualStreamHelper`](https://github.com/aybe/libsndfile.NET/blob/master/Examples/SfVirtualStreamHelper.cs) shows how UWP file access could be virtualized; this allows seamless file access while [a patched libsndfile for UWP](https://github.com/Microsoft/vcpkg/pull/2216) makes its way to this project

## Changelog

1.0.0 (17/12/2017)

First release !

1.0.1  (17/12/2017)

- fixed virtualized file system callbacks (wrong calling convention)
- refactored example project
- `SfVirtualStreamHelper` is now in the example project since it was its first intent
