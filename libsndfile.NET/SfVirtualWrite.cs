using System;

namespace libsndfile.NET
{
    public delegate long SfVirtualWrite(IntPtr ptr, long count, IntPtr userData);
}