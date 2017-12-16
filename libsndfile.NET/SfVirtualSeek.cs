using System;

namespace libsndfile.NET
{
    public delegate long SfVirtualSeek(long offset, SfSeek seek, IntPtr userData);
}