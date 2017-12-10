using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SfFormatSubtype
    {
        /// <summary>
        ///     Signed 8 bit data.
        /// </summary>
        PCM_S8 = SfFormat__.SF_FORMAT_PCM_S8,

        /// <summary>
        ///     Signed 16 bit data.
        /// </summary>
        PCM_16 = SfFormat__.SF_FORMAT_PCM_16,

        /// <summary>
        ///     Signed 24 bit data.
        /// </summary>
        PCM_24 = SfFormat__.SF_FORMAT_PCM_24,

        /// <summary>
        ///     Signed 32 bit data.
        /// </summary>
        PCM_32 = SfFormat__.SF_FORMAT_PCM_32,

        /// <summary>
        ///     Unsigned 8 bit data (WAV and RAW only).
        /// </summary>
        PCM_U8 = SfFormat__.SF_FORMAT_PCM_U8,

        /// <summary>
        ///     32 bit float data.
        /// </summary>
        FLOAT = SfFormat__.SF_FORMAT_FLOAT,

        /// <summary>
        ///     64 bit float data.
        /// </summary>
        DOUBLE = SfFormat__.SF_FORMAT_DOUBLE,

        /// <summary>
        ///     U-Law encoded.
        /// </summary>
        ULAW = SfFormat__.SF_FORMAT_ULAW,

        /// <summary>
        ///     A-Law encoded.
        /// </summary>
        ALAW = SfFormat__.SF_FORMAT_ALAW,

        /// <summary>
        ///     IMA ADPCM.
        /// </summary>
        IMA_ADPCM = SfFormat__.SF_FORMAT_IMA_ADPCM,

        /// <summary>
        ///     Microsoft ADPCM.
        /// </summary>
        MS_ADPCM = SfFormat__.SF_FORMAT_MS_ADPCM,

        /// <summary>
        ///     GSM 6.10 encoding.
        /// </summary>
        GSM610 = SfFormat__.SF_FORMAT_GSM610,

        /// <summary>
        ///     OKI / Dialogix ADPCM.
        /// </summary>
        VOX_ADPCM = SfFormat__.SF_FORMAT_VOX_ADPCM,

        /// <summary>
        ///     32kbs G721 ADPCM encoding.
        /// </summary>
        G721_32 = SfFormat__.SF_FORMAT_G721_32,

        /// <summary>
        ///     24kbs G723 ADPCM encoding.
        /// </summary>
        G723_24 = SfFormat__.SF_FORMAT_G723_24,

        /// <summary>
        ///     40kbs G723 ADPCM encoding.
        /// </summary>
        G723_40 = SfFormat__.SF_FORMAT_G723_40,

        /// <summary>
        ///     12 bit Delta Width Variable Word encoding.
        /// </summary>
        DWVW_12 = SfFormat__.SF_FORMAT_DWVW_12,

        /// <summary>
        ///     16 bit Delta Width Variable Word encoding.
        /// </summary>
        DWVW_16 = SfFormat__.SF_FORMAT_DWVW_16,

        /// <summary>
        ///     24 bit Delta Width Variable Word encoding.
        /// </summary>
        DWVW_24 = SfFormat__.SF_FORMAT_DWVW_24,

        /// <summary>
        ///     N bit Delta Width Variable Word encoding.
        /// </summary>
        DWVW_N = SfFormat__.SF_FORMAT_DWVW_N,

        /// <summary>
        ///     8 bit differential PCM (XI only).
        /// </summary>
        DPCM_8 = SfFormat__.SF_FORMAT_DPCM_8,

        /// <summary>
        ///     16 bit differential PCM (XI only).
        /// </summary>
        DPCM_16 = SfFormat__.SF_FORMAT_DPCM_16,

        /// <summary>
        ///     Xiph Vorbis encoding.
        /// </summary>
        VORBIS = SfFormat__.SF_FORMAT_VORBIS,

        /// <summary>
        ///     Apple Lossless Audio Codec (16 bit).
        /// </summary>
        ALAC_16 = SfFormat__.SF_FORMAT_ALAC_16,

        /// <summary>
        ///     Apple Lossless Audio Codec (20 bit).
        /// </summary>
        ALAC_20 = SfFormat__.SF_FORMAT_ALAC_20,

        /// <summary>
        ///     Apple Lossless Audio Codec (24 bit).
        /// </summary>
        ALAC_24 = SfFormat__.SF_FORMAT_ALAC_24,

        /// <summary>
        ///     Apple Lossless Audio Codec (32 bit).
        /// </summary>
        ALAC_32 = SfFormat__.SF_FORMAT_ALAC_32
    }
}