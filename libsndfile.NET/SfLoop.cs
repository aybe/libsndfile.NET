using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential)]
    public struct SfLoop
    {
        public SfLoopMode Mode;
        public uint Start;
        public uint End;
        public uint Count;
    }
}