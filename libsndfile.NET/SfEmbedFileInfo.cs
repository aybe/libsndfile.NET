using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential)]
    public struct SfEmbedFileInfo
    {
        public static SfEmbedFileInfo Empty { get; }

        public readonly long Offset;
        public readonly long Length;

        public override string ToString()
        {
            return $"{nameof(Offset)}: {Offset}, {nameof(Length)}: {Length}";
        }
    }
}