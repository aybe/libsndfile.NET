using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential)]
    public struct SfInstrument
    {
        public static SfInstrument Empty { get; } = new SfInstrument {Loops = new SfLoop[LoopsSize]};

        public const int LoopsSize = 16;

        public int Gain;

        public byte BaseNote;

        public byte Detune;

        public byte VelocityLo;

        public byte VelocityHi;

        public byte KeyLo;

        public byte KeyHi;

        public int LoopCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = LoopsSize, ArraySubType = UnmanagedType.Struct)]
        public SfLoop[] Loops;
    }
}