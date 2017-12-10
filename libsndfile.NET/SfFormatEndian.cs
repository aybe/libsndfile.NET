using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SfFormatEndian
    {
        /// <summary>
        ///     Default file endian-ness.
        /// </summary>
        FILE = SfFormat__.SF_ENDIAN_FILE,

        /// <summary>
        ///     Force little endian-ness.
        /// </summary>
        LITTLE = SfFormat__.SF_ENDIAN_LITTLE,

        /// <summary>
        ///     Force big endian-ness.
        /// </summary>
        BIG = SfFormat__.SF_ENDIAN_BIG,

        /// <summary>
        ///     Force CPU endian-ness.
        /// </summary>
        CPU = SfFormat__.SF_ENDIAN_CPU
    }
}