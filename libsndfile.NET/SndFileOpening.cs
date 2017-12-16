using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    public sealed partial class SndFile
    {
        #region Public

        [PublicAPI]
        [CanBeNull]
        public static SndFile OpenRead([NotNull] string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Open__(path, SfFormat.Empty, SfMode.Read);
        }

        [PublicAPI]
        [CanBeNull]
        public static SndFile OpenRead(SfVirtual @virtual, IntPtr userData = default)
        {
            return Open__(@virtual, SfMode.Read, userData, SfFormat.Empty);
        }

        [PublicAPI]
        [CanBeNull]
        public static SndFile OpenWrite([NotNull] string path, SfFormat format)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return Open__(path, format, SfMode.Write);
        }

        [PublicAPI]
        [CanBeNull]
        public static SndFile OpenWrite(SfVirtual @virtual, SfFormat format, IntPtr userData = default)
        {
            return Open__(@virtual, SfMode.Write, userData, format);
        }

        #endregion

        #region Private

        private unsafe SndFile([NotNull] SndFile__* file, SfInfo info)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            Handle = file;
            Info = info;
        }

        [AssertionMethod]
        private static void CheckOpenParameters(SfFormat format,
            [AssertionCondition(AssertionConditionType.IS_TRUE)] SfMode mode)
        {
            if (format == SfFormat.Empty && mode != SfMode.Read)
                throw new ArgumentNullException(nameof(format));
        }

        [CanBeNull]
        private static unsafe SndFile Open__(
            [NotNull] string path, SfFormat format, SfMode mode)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            CheckOpenParameters(format, mode);

            var info = format.ToInfo();
            var sndFile = sf_wchar_open(path, mode, ref info);
            return sndFile == null ? null : new SndFile(sndFile, info);
        }

        [CanBeNull]
        private static unsafe SndFile Open__(
            SfVirtual @virtual, SfMode mode, IntPtr userData, SfFormat format)
        {
            if (@virtual == SfVirtual.Empty)
                throw new ArgumentNullException(nameof(@virtual));

            CheckOpenParameters(format, mode);

            var info = format.ToInfo();
            var sndFile = sf_open_virtual(ref @virtual, mode, ref info, userData);
            return sndFile == null ? null : new SndFile(sndFile, info);
        }

        #endregion

        #region Native methods

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SndFile__* sf_wchar_open(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            SfMode mode,
            ref SfInfo info
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SndFile__* sf_open_virtual(
            ref SfVirtual @virtual,
            SfMode mode,
            ref SfInfo info,
            IntPtr userData
        );

        #endregion
    }
}