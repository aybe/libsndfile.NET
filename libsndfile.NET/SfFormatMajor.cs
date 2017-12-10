using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum SfFormatMajor
    {
        /// <summary>
        ///     Microsoft WAV format (little endian default).
        /// </summary>
        WAV = SfFormat__.SF_FORMAT_WAV,

        /// <summary>
        ///     Apple/SGI AIFF format (big endian).
        /// </summary>
        AIFF = SfFormat__.SF_FORMAT_AIFF,

        /// <summary>
        ///     Sun/NeXT AU format (big endian).
        /// </summary>
        AU = SfFormat__.SF_FORMAT_AU,

        /// <summary>
        ///     RAW PCM data.
        /// </summary>
        RAW = SfFormat__.SF_FORMAT_RAW,

        /// <summary>
        ///     Ensoniq PARIS file format.
        /// </summary>
        PAF = SfFormat__.SF_FORMAT_PAF,

        /// <summary>
        ///     Amiga IFF / SVX8 / SV16 format.
        /// </summary>
        SVX = SfFormat__.SF_FORMAT_SVX,

        /// <summary>
        ///     Sphere NIST format.
        /// </summary>
        NIST = SfFormat__.SF_FORMAT_NIST,

        /// <summary>
        ///     VOC files.
        /// </summary>
        VOC = SfFormat__.SF_FORMAT_VOC,

        /// <summary>
        ///     Berkeley/IRCAM/CARL.
        /// </summary>
        IRCAM = SfFormat__.SF_FORMAT_IRCAM,

        /// <summary>
        ///     Sonic Foundry's 64 bit RIFF/WAV.
        /// </summary>
        W64 = SfFormat__.SF_FORMAT_W64,

        /// <summary>
        ///     Matlab (tm) V4.2 / GNU Octave 2.0.
        /// </summary>
        MAT4 = SfFormat__.SF_FORMAT_MAT4,

        /// <summary>
        ///     Matlab (tm) V5.0 / GNU Octave 2.1.
        /// </summary>
        MAT5 = SfFormat__.SF_FORMAT_MAT5,

        /// <summary>
        ///     Portable Voice Format.
        /// </summary>
        PVF = SfFormat__.SF_FORMAT_PVF,

        /// <summary>
        ///     Fasttracker 2 Extended Instrument.
        /// </summary>
        XI = SfFormat__.SF_FORMAT_XI,

        /// <summary>
        ///     HMM Tool Kit format.
        /// </summary>
        HTK = SfFormat__.SF_FORMAT_HTK,

        /// <summary>
        ///     Midi Sample Dump Standard.
        /// </summary>
        SDS = SfFormat__.SF_FORMAT_SDS,

        /// <summary>
        ///     Audio Visual Research.
        /// </summary>
        AVR = SfFormat__.SF_FORMAT_AVR,

        /// <summary>
        ///     MS WAVE with WAVEFORMATEX.
        /// </summary>
        WAVEX = SfFormat__.SF_FORMAT_WAVEX,

        /// <summary>
        ///     Sound Designer 2.
        /// </summary>
        SD2 = SfFormat__.SF_FORMAT_SD2,

        /// <summary>
        ///     FLAC lossless file format.
        /// </summary>
        FLAC = SfFormat__.SF_FORMAT_FLAC,

        /// <summary>
        ///     Core Audio File format.
        /// </summary>
        CAF = SfFormat__.SF_FORMAT_CAF,

        /// <summary>
        ///     Psion WVE format.
        /// </summary>
        WVE = SfFormat__.SF_FORMAT_WVE,

        /// <summary>
        ///     Xiph OGG container.
        /// </summary>
        OGG = SfFormat__.SF_FORMAT_OGG,

        /// <summary>
        ///     Akai MPC 2000 sampler.
        /// </summary>
        MPC2K = SfFormat__.SF_FORMAT_MPC2K,

        /// <summary>
        ///     RF64 WAV file.
        /// </summary>
        RF64 = SfFormat__.SF_FORMAT_RF64
    }
}