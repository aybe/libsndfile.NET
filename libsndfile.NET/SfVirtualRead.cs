using System;

namespace libsndfile.NET
{
    public delegate long SfVirtualRead(IntPtr ptr, long count, IntPtr userData);
}