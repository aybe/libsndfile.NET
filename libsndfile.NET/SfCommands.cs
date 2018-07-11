using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToReturnStatement")]
    public static class SfCommands
    {
        #region Static

        [PublicAPI]
        public static unsafe string GetLibVersion()
        {
            return GetString(null, SfCommand.GetLibVersion, 128);
        }

        [PublicAPI]
        public static unsafe string GetLogInfo([CanBeNull] SndFile sndFile)
        {
            return GetString(sndFile != null ? sndFile.Handle : null, SfCommand.GetLogInfo, 2048);
        }

        private static SfFormatInfo? GetFormatInfo(SfCommand command, int format)
        {
            return GetStructure(null, command, new SfFormatInfo(format), 0);
        }

        [PublicAPI]
        public static SfFormatInfo? GetFormatInfo(SfFormatMajor major)
        {
            return GetFormatInfo(SfCommand.GetFormatInfo, (int) major);
        }

        [PublicAPI]
        public static SfFormatInfo? GetFormatInfo(SfFormatSubtype subtype)
        {
            return GetFormatInfo(SfCommand.GetFormatInfo, (int) subtype);
        }

        [PublicAPI]
        public static SfFormatInfo? GetFormatMajor(int major)
        {
            return GetFormatInfo(SfCommand.GetFormatMajor, major);
        }

        [PublicAPI]
        public static int GetFormatMajorCount()
        {
            return GetInt(SfCommand.GetFormatMajorCount);
        }

        [PublicAPI]
        public static SfFormatInfo? GetFormatSubtype(int subtype)
        {
            return GetFormatInfo(SfCommand.GetFormatSubtype, subtype);
        }

        [PublicAPI]
        public static int GetFormatSubtypeCount()
        {
            return GetInt(SfCommand.GetFormatSubtypeCount);
        }

        [PublicAPI]
        public static SfFormatInfo? GetSimpleFormat(int format)
        {
            return GetFormatInfo(SfCommand.GetSimpleFormat, format);
        }

        [PublicAPI]
        public static int GetSimpleFormatCount()
        {
            return GetInt(SfCommand.GetSimpleFormatCount);
        }

        #endregion

        #region Extensions

        [PublicAPI]
        public static double[] CalcMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.CalcMaxAllChannels, 0);
        }

        [PublicAPI]
        public static double[] CalcNormMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.CalcNormMaxAllChannels, 0);
        }

        [PublicAPI]
        public static double? CalcNormSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.CalcNormSignalMax, 0);
        }

        [PublicAPI]
        public static double? CalcSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.CalcSignalMax, 0);
        }

        [PublicAPI]
        public static bool FileTruncate([NotNull] this SndFile sndFile, long frames)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetLong(sndFile, SfCommand.FileTruncate, frames);
        }

        [PublicAPI]
        public static SfAmbisonic? GetAmbisonic([NotNull] this SndFile sndFile)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, SfCommand.WavexGetAmbisonic, IntPtr.Zero, 0);
            if (i == 0)
                return null;

            return (SfAmbisonic) i;
        }

        [PublicAPI]
        public static SfBroadcastInfo? GetBroadcastInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetBroadcastInfo, SfBroadcastInfo.Empty, SF_TRUE);
        }

        [PublicAPI]
        public static SfCartInfo? GetCartInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetCartInfo, SfCartInfo.Empty, SF_TRUE);
        }

        [PublicAPI]
        public static bool GetClipping(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetClipping);
        }

        [PublicAPI]
        public static SfCues? GetCue(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetCue, SfCues.Empty, SF_TRUE);
        }

        [PublicAPI]
        public static unsafe uint? GetCueCount(this SndFile sndFile)
        {
            var u = default(uint);

            var i = sf_command(sndFile, SfCommand.GetCueCount, &u, sizeof(uint));
            if (i != SF_TRUE)
                return null;

            return u;
        }

        [PublicAPI]
        public static SfEmbedFileInfo? GetEmbedFileInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetEmbedFileInfo, SfEmbedFileInfo.Empty, 0);
        }

        [PublicAPI]
        public static SfInstrument? GetInstrument(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetInstrument, SfInstrument.Empty, SF_TRUE);
        }

        [PublicAPI]
        public static SfLoopInfo? GetLoopInfo(this SndFile sndFile)
        {
            return GetStructure(sndFile, SfCommand.GetLoopInfo, SfLoopInfo.Empty, SF_TRUE);
        }

        [PublicAPI]
        public static double[] GetMaxAllChannels(this SndFile sndFile)
        {
            return GetDoubles(sndFile, SfCommand.GetMaxAllChannels, SF_TRUE);
        }

        [PublicAPI]
        public static bool GetNormDouble(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetNormDouble);
        }

        [PublicAPI]
        public static bool GetNormFloat(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.GetNormFloat);
        }

        [PublicAPI]
        public static double? GetSignalMax(this SndFile sndFile)
        {
            return GetDouble(sndFile, SfCommand.GetSignalMax, SF_TRUE);
        }

        [PublicAPI]
        public static bool RawNeedsEndswap(this SndFile sndFile)
        {
            return GetBool(sndFile, SfCommand.RawDataNeedsEndswap);
        }

        [PublicAPI]
        public static bool Rf64AutoDowngrade(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.Rf64AutoDowngrade, enable);
        }

        [PublicAPI]
        public static bool SetAddPeakChunk(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetAddPeakChunk, enable);
        }

        [PublicAPI]
        public static SfAmbisonic? SetAmbisonic([NotNull] this SndFile sndFile, SfAmbisonic ambisonic)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, SfCommand.WavexSetAmbisonic, IntPtr.Zero, (int) ambisonic);
            if (i == 0)
                return null;

            return (SfAmbisonic) i;
        }

        [PublicAPI]
        public static bool SetBroadcastInfo(this SndFile sndFile, SfBroadcastInfo broadcastInfo)
        {
            return SetStructure(sndFile, SfCommand.SetBroadcastInfo, broadcastInfo, SF_TRUE);
        }

        [PublicAPI]
        public static bool SetCartInfo(this SndFile sndFile, SfCartInfo cartInfo)
        {
            return SetStructure(sndFile, SfCommand.SetCartInfo, cartInfo, SF_TRUE);
        }

        [PublicAPI]
        public static bool SetClipping(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetClipping, enable);
        }

        [PublicAPI]
        public static bool SetCompressionLevel(this SndFile sndFile, double level)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            if (level < 0.0d || level > 1.0d)
                throw new ArgumentOutOfRangeException(nameof(level));

            return SetDouble(sndFile, SfCommand.SetCompressionLevel, level);
        }

        [PublicAPI]
        public static bool SetCue(this SndFile sndFile, SfCues cues)
        {
            return SetStructure(sndFile, SfCommand.SetCue, cues, SF_TRUE);
        }

        [PublicAPI]
        public static bool SetInstrument(this SndFile sndFile, SfInstrument instrument)
        {
            return SetStructure(sndFile, SfCommand.SetInstrument, instrument, SF_TRUE);
        }

        [PublicAPI]
        public static bool SetNormDouble(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetNormDouble, enable);
        }

        [PublicAPI]
        public static bool SetNormFloat(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetNormFloat, enable);
        }

        [PublicAPI]
        public static bool SetScaleIntFloatWrite(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetScaleIntFloatWrite, enable);
        }

        [PublicAPI]
        public static bool SetScaleFloatIntRead(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetScaleFloatIntRead, enable);
        }

        [PublicAPI]
        public static bool SetRawStartOffset(this SndFile sndFile, long offset)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetLong(sndFile, SfCommand.SetRawStartOffset, offset);
        }

        [PublicAPI]
        public static bool SetUpdateHeaderAuto(this SndFile sndFile, bool enable)
        {
            return SetBool(sndFile, SfCommand.SetUpdateHeaderAuto, enable);
        }

        [PublicAPI]
        public static bool SetVbrEncodingQuality(this SndFile sndFile, double quality)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            if (quality < 0.0d || quality > 1.0d)
                throw new ArgumentOutOfRangeException(nameof(quality));

            return SetDouble(sndFile, SfCommand.SetVbrEncodingQuality, quality);
        }

        [PublicAPI]
        public static void UpdateHeaderNow([NotNull] this SndFile sndFile)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            sf_command(sndFile, SfCommand.UpdateHeaderNow, IntPtr.Zero, 0);
        }

        #endregion

        #region Helpers

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int SF_FALSE = 0;

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private const int SF_TRUE = 1;

        private static bool GetBool([NotNull] SndFile sndFile, SfCommand command)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            return SetBool(sndFile, command, false);
        }

        private static unsafe double? GetDouble([NotNull] SndFile sndFile, SfCommand command, int match)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var d = default(double);

            var i = sf_command(sndFile, command, &d, sizeof(double));
            if (i != match)
                return null;

            return d;
        }

        private static unsafe double[] GetDoubles([NotNull] SndFile sndFile, SfCommand command, int match)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var doubles = new double[sndFile.Format.Channels];

            fixed (double* d = doubles)
            {
                var i = sf_command(sndFile.Handle, command, d, sizeof(double) * doubles.Length);
                if (i != match)
                    return null;

                return doubles;
            }
        }

        private static unsafe int GetInt(SfCommand command)
        {
            var i = default(int);
            sf_command((SndFile__*) null, command, &i, sizeof(int));
            return i;
        }

        private static unsafe string GetString([CanBeNull] SndFile__* sndFile, SfCommand command, int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            var ptr = stackalloc sbyte[size];
            var cmd = sf_command(sndFile, command, ptr, size);
            var str = new string(ptr);

            return str;
        }

        [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
        private static unsafe T? GetStructure<T>([CanBeNull] SndFile sndFile, SfCommand command, T structure, int valid)
            where T : struct
        {
            using (var m = new Marshaller<T>(structure))
            {
                var handle = sndFile != null ? sndFile.Handle : null;

                var i = sf_command(handle, command, m.Address, m.Size);
                if (i != valid)
                    return null;

                return m.Pop();
            }
        }

        private static bool SetBool([NotNull] SndFile sndFile, SfCommand command, bool value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, command, IntPtr.Zero, value ? SF_TRUE : SF_FALSE);

            switch (i)
            {
                case SF_TRUE:
                    return true;
                case SF_FALSE:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i));
            }
        }

        private static unsafe bool SetDouble([NotNull] SndFile sndFile, SfCommand command, double value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile, command, &value, sizeof(double));

            switch (i)
            {
                case SF_TRUE:
                    return true;
                case SF_FALSE:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(i));
            }
        }

        private static unsafe bool SetLong([NotNull] SndFile sndFile, SfCommand command, long value)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));


            var i = sf_command(sndFile, command, &value, sizeof(long));
            return i == 0;
        }

        private static bool SetStructure<T>(SndFile sndFile, SfCommand command, T structure, int valid) where T : struct
        {
            using (var m = new Marshaller<T>(structure))
            {
                var i = sf_command(sndFile, command, m.Address, m.Size);
                return i == valid;
            }
        }

        #endregion


        #region Native

        private static unsafe int sf_command([NotNull] SndFile sndFile, SfCommand cmd, IntPtr data, int dataSize)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile.Handle, cmd, data, dataSize);

            return i;
        }

        private static unsafe int sf_command([NotNull] SndFile sndFile, SfCommand cmd, void* data, int dataSize)
        {
            if (sndFile == null)
                throw new ArgumentNullException(nameof(sndFile));

            var i = sf_command(sndFile.Handle, cmd, data, dataSize);

            return i;
        }

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int sf_command(SndFile__* sndFile, SfCommand cmd, IntPtr data, int dataSize);

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int sf_command(SndFile__* sndFile, SfCommand cmd, void* data, int dataSize);

        #endregion
    }
}