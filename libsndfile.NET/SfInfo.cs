using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    internal struct SfInfo
    {
        public long Frames;
        public int SampleRate;
        public int Channels;
        public SfFormat__ Format;
        public int Sections;
        [MarshalAs(UnmanagedType.Bool)] public bool Seekable;
    }
}