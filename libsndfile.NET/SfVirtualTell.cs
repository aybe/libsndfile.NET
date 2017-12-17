using System;
using System.Runtime.InteropServices;

namespace libsndfile.NET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate long SfVirtualTell(IntPtr userData);
}