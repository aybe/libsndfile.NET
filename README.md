# libsndfile.NET

This is [libsndfile](https://github.com/erikd/libsndfile) for .NET :)

[![NuGet](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/libsndfile.NET/1.0.0)

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
 - UWP support is somehow limited because of [storage restrictions](https://trac.ffmpeg.org/wiki/CompilationGuide/WinRT#WindowsStoreCertificationFileIOandOtherDetails), the [`SfVirtualStreamHelper`](https://github.com/aybe/libsndfile.NET/blob/master/libsndfile.NET/Helpers/SfVirtualStreamHelper.cs) shows how UWP file access could be virtualized; this allows seamless file access while [a patched libsndfile for UWP](https://github.com/Microsoft/vcpkg/pull/2216) makes its way to this project
 
