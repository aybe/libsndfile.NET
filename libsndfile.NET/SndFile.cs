using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    public sealed class SndFile : IDisposable
    {
        #region Private

        private readonly unsafe SndFile__* _file;
        private readonly SfInfo _info;

        private unsafe SndFile([NotNull] SndFile__* file, SfInfo info)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            _file = file;
            _info = info;
        }

        private static unsafe string GetErrorMessage(SndFile__* file)
        {
            var ptr = sf_strerror(file);
            return GetErrorMessage(ptr);
        }

        private static string GetErrorMessage(SfError error)
        {
            var ptr = sf_error_number(error);
            return GetErrorMessage(ptr);
        }

        private static string GetErrorMessage(IntPtr intPtr)
        {
            return Marshal.PtrToStringAnsi(intPtr);
        }

        private void ReadCheck(Array array, long frames)
        {
            if (array == null || array.Length < Channels)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (frames < 0)
                throw new ArgumentOutOfRangeException(nameof(frames));
        }

        #endregion

        #region Public

        [PublicAPI]
        public int Channels => _info.Channels;

        [PublicAPI]
        public SfFormat Format => new SfFormat(_info.Format);

        [PublicAPI]
        public long Frames => _info.Frames;

        [PublicAPI]
        public int SampleRate => _info.SampleRate;

        [PublicAPI]
        public int Sections => _info.Sections;

        [PublicAPI]
        public bool Seekable => _info.Seekable;

        [PublicAPI]
        public static unsafe bool TryOpenRead([NotNull] string path, out SndFile result)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            result = null;

            var info = new SfInfo();

            var sndFile = sf_wchar_open(path, SfMode.Read, ref info);
            if (sndFile == null)
                return false;

            result = new SndFile(sndFile, info);
            return true;
        }

        [PublicAPI]
        public unsafe long Read([NotNull] short[] buffer, long frames)
        {
            ReadCheck(buffer, frames);
            return sf_readf_short(_file, buffer, frames);
        }

        [PublicAPI]
        public unsafe long Read([NotNull] int[] buffer, long frames)
        {
            ReadCheck(buffer, frames);
            return sf_readf_int(_file, buffer, frames);
        }

        [PublicAPI]
        public unsafe long Read([NotNull] float[] buffer, long frames)
        {
            ReadCheck(buffer, frames);
            return sf_readf_float(_file, buffer, frames);
        }

        [PublicAPI]
        public unsafe long Read([NotNull] double[] buffer, long frames)
        {
            ReadCheck(buffer, frames);
            return sf_readf_double(_file, buffer, frames);
        }

        [PublicAPI]
        public unsafe long Seek(long frames, SfSeek seek = SfSeek.Begin)
        {
            if (!Seekable)
                throw new NotSupportedException();

            var position = sf_seek(_file, frames, seek);
            if (position != -1)
                return position;

            var message = GetErrorMessage(_file);
            throw new InvalidOperationException(message);
        }

        #endregion

        #region IDisposable

        private bool IsDisposed { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private unsafe void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            var error = sf_close(_file);
            if (error != SfError.NoError)
            {
                var message = GetErrorMessage(error);
                throw new InvalidOperationException(message);
            }

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

        #region Native methods

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SfError sf_close(
            SndFile__* sndFile
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long frames
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_seek(
            SndFile__* sndFile,
            long frames,
            SfSeek whence
        );

        [DllImport("libsndfile-1", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe SndFile__* sf_wchar_open(
            [MarshalAs(UnmanagedType.LPWStr)] string path,
            SfMode mode,
            ref SfInfo sfInfo
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