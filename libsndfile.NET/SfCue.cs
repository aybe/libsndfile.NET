using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SfCue
    {
        public readonly int Index;
        public readonly uint Position;
        public readonly int FccChunk;
        public readonly int ChunkStart;
        public readonly int BlockStart;
        public readonly uint SampleOffset;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public readonly string Name;

        public SfCue(
            int index, uint position, int fccChunk, int chunkStart, int blockStart, uint sampleOffset, string name)
        {
            Index = index;
            Position = position;
            FccChunk = fccChunk;
            ChunkStart = chunkStart;
            BlockStart = blockStart;
            SampleOffset = sampleOffset;
            Name = name;
        }
    }
}