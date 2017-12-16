using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    public sealed partial class SndFile : IDisposable
    {
        #region Public

        [PublicAPI]
        public SfFormat Format => new SfFormat(Info);

        [PublicAPI]
        public long Frames => Info.Frames;

        [PublicAPI]
        public int Sections => Info.Sections;

        [PublicAPI]
        public bool Seekable => Info.Seekable;

        [PublicAPI]
        public static bool FormatCheck(SfFormat format)
        {
            var info = (SfInfo) format;
            return sf_format_check(ref info);
        }

        /// <summary>
        ///     Gets the message of the last error that occurred for an instance.
        /// </summary>
        /// <param name="sndFile">
        ///     An instance to get the error message or <c>null</c> when an instance couldn't be opened.
        /// </param>
        /// <returns>
        ///     A string describing the error that occurred.
        /// </returns>
        [PublicAPI]
        public static unsafe string GetErrorMessage([CanBeNull] SndFile sndFile = null)
        {
            return GetErrorMessage(sndFile == null ? null : sndFile.Handle);
        }

        /// <summary>
        ///     Gets the current error that occurred on this instance, if any.
        /// </summary>
        /// <returns></returns>
        [PublicAPI]
        public unsafe SfError GetError()
        {
            return sf_error(Handle);
        }

        [PublicAPI]
        public unsafe string GetString(SfString @string)
        {
            var ptr = sf_get_string(Handle, @string);
            var s = Marshal.PtrToStringAnsi(ptr);
            return s;
        }

        [PublicAPI]
        public unsafe void SetString(SfString @string, [CanBeNull] string value)
        {
            var error = sf_set_string(Handle, @string, value);
            if (error != SfError.NoError)
                throw new InvalidOperationException(GetErrorMessage(error));
        }

        [PublicAPI]
        public unsafe long Seek(long frames, SfSeek seek = SfSeek.Begin)
        {
            if (!Seekable)
                throw new NotSupportedException();

            var position = sf_seek(Handle, frames, seek);
            if (position == -1)
                throw new InvalidOperationException(GetErrorMessage(Handle));

            return position;
        }

        #endregion

        #region IDisposable

        private bool IsDisposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [PublicAPI]
        public unsafe SfError Close()
        {
            return sf_close(Handle);
        }

        private void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            var error = Close();
            if (error != SfError.NoError)
                throw new InvalidOperationException(GetErrorMessage(error));

            if (disposing)
            {
                // nothing
            }

            IsDisposed = true;
        }

        ~SndFile()
        {
            Dispose(false);
        }

        #endregion

        #region Private

        internal unsafe SndFile__* Handle { get; }

        private SfInfo Info { get; }

        private static unsafe string GetErrorMessage(SndFile__* file)
        {
            var ptr = sf_strerror(file);
            var s = Marshal.PtrToStringAnsi(ptr);
            return s;
        }

        private static string GetErrorMessage(SfError error)
        {
            var ptr = sf_error_number(error);
            var s = Marshal.PtrToStringAnsi(ptr);
            return s;
        }

        #endregion

        #region Native methods

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool sf_format_check(
            ref SfInfo sfInfo
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SfError sf_close(
            SndFile__* sndFile
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_seek(
            SndFile__* sndFile,
            long frames,
            SfSeek whence
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr sf_get_string(
            SndFile__* sndFile,
            SfString sfString
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern unsafe SfError sf_set_string(
            SndFile__* sndFile,
            SfString sfString,
            [MarshalAs(UnmanagedType.LPStr)] string str
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SfError sf_error(
            SndFile__* sndFile
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr sf_error_number(
            SfError error
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr sf_strerror(
            [CanBeNull] SndFile__* sndFile
        );

        #endregion
    }
}