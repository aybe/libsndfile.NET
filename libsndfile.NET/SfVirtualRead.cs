using System;
using System.Runtime.InteropServices;

namespace libsndfile.NET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SfVirtualRead(IntPtr ptr, long count, IntPtr userData);
}