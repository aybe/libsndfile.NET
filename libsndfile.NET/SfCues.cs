using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential)]
    public struct SfCues
    {
        public const int Size = 100;

        public static SfCues Empty { get; } = new SfCues(Size, new SfCue[Size]);

        public readonly int CueCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Size, ArraySubType = UnmanagedType.Struct)]
        public readonly SfCue[] CuePoints;

        private SfCues(int cueCount, SfCue[] cuePoints)
        {
            CueCount = cueCount;
            CuePoints = cuePoints ?? throw new ArgumentNullException(nameof(cuePoints));
        }

        public SfCues(params SfCue[] cues)
        {
            var min = Math.Min(Size, cues.Length);
            CueCount = min;
            CuePoints = new SfCue[Size];
            Array.Copy(cues, 0, CuePoints, 0, min);
        }
    }
}