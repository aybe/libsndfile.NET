using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public struct SfFormat
    {
        public SfFormatMajor Major { get; }
        public SfFormatSubtype Subtype { get; }
        public SfFormatEndian Endian { get; }

        internal SfFormat(SfFormat__ format)
        {
            Major = (SfFormatMajor) (format & SfFormat__.SF_FORMAT_TYPEMASK);
            Subtype = (SfFormatSubtype) (format & SfFormat__.SF_FORMAT_SUBMASK);
            Endian = (SfFormatEndian) (format & SfFormat__.SF_FORMAT_ENDMASK);
        }

        public override string ToString()
        {
            return $"{nameof(Major)}: {Major}, {nameof(Subtype)}: {Subtype}, {nameof(Endian)}: {Endian}";
        }
    }
}