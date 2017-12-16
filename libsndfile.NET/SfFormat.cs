using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public struct SfFormat
    {
        #region Static

        /// <summary>
        ///     An empty instance.
        /// </summary>
        public static SfFormat Empty { get; }

        /// <summary>
        ///     Default FLAC format: 2 channels, 16-bit, 44.1Khz.
        /// </summary>
        public static SfFormat DefaultFlac { get; } =
            new SfFormat(SfFormatMajor.FLAC, SfFormatSubtype.PCM_16, SfFormatEndian.FILE, 2, 44100);

        /// <summary>
        ///     Default WAV format: 2 channels, 16-bit, 44.1Khz.
        /// </summary>
        public static SfFormat DefaultWav { get; } =
            new SfFormat(SfFormatMajor.WAV, SfFormatSubtype.PCM_16, SfFormatEndian.FILE, 2, 44100);

        #endregion

        #region Instance

        public SfFormatMajor Major { get; }
        public SfFormatSubtype Subtype { get; }
        public SfFormatEndian Endian { get; }
        public int Channels { get; }
        public int SampleRate { get; }

        public SfFormat(
            SfFormatMajor major, SfFormatSubtype subtype, SfFormatEndian endian, int channels, int sampleRate)
        {
            Major = major;
            Subtype = subtype;
            Endian = endian;
            Channels = channels;
            SampleRate = sampleRate;
        }

        internal SfFormat(SfInfo info)
        {
            var format = info.Format;
            Major = (SfFormatMajor) (format & SfFormat__.SF_FORMAT_TYPEMASK);
            Subtype = (SfFormatSubtype) (format & SfFormat__.SF_FORMAT_SUBMASK);
            Endian = (SfFormatEndian) (format & SfFormat__.SF_FORMAT_ENDMASK);
            Channels = info.Channels;
            SampleRate = info.SampleRate;
        }

        public override string ToString()
        {
            return $"{nameof(Major)}: {Major}, {nameof(Subtype)}: {Subtype}, {nameof(Endian)}: {Endian}";
        }

        internal SfInfo ToInfo()
        {
            var info = new SfInfo
            {
                Format = (SfFormat__) Major | (SfFormat__) Subtype | (SfFormat__) Endian,
                Channels = Channels,
                SampleRate = SampleRate
            };
            return info;
        }

        #endregion

        #region Equality members

        public bool Equals(SfFormat other)
        {
            return Major == other.Major &&
                   Subtype == other.Subtype &&
                   Endian == other.Endian &&
                   Channels == other.Channels &&
                   SampleRate == other.SampleRate;
        }

        public override bool Equals(object obj)
        {
            return !(obj is null) && obj is SfFormat format && Equals(format);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Major;
                hashCode = (hashCode * 397) ^ (int) Subtype;
                hashCode = (hashCode * 397) ^ (int) Endian;
                hashCode = (hashCode * 397) ^ Channels;
                hashCode = (hashCode * 397) ^ SampleRate;
                return hashCode;
            }
        }

        public static bool operator ==(SfFormat left, SfFormat right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SfFormat left, SfFormat right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}