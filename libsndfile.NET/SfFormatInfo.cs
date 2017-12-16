using System.Runtime.InteropServices;

namespace libsndfile.NET
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SfFormatInfo
    {
        // TODO split this
        public readonly int Format;

        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Name;

        [MarshalAs(UnmanagedType.LPStr)]
        public readonly string Extension;

        public SfFormatInfo(int format)
        {
            Format = format;
            Name = null;
            Extension = null;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}