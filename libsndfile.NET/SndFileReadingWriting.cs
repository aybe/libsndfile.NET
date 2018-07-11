using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    public sealed partial class SndFile
    {
        #region Items

        private void CheckReadWriteItemsParameters([NotNull] Array array, long items)
        {
            if (array == null || array.Length < 1)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (items <= 0)
                throw new ArgumentOutOfRangeException(nameof(items));
        }

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_read_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long items
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_write_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long items
        );

        [PublicAPI]
        public unsafe long ReadItems([NotNull] short[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_short(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long ReadItems([NotNull] int[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_int(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long ReadItems([NotNull] float[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_float(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long ReadItems([NotNull] double[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_read_double(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long WriteItems([NotNull] short[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_short(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long WriteItems([NotNull] int[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_int(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long WriteItems([NotNull] float[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_float(Handle, buffer, items);
        }

        [PublicAPI]
        public unsafe long WriteItems([NotNull] double[] buffer, long items)
        {
            CheckReadWriteItemsParameters(buffer, items);
            return sf_write_double(Handle, buffer, items);
        }

        #endregion

        #region Frames

        private void CheckReadWriteFramesParameters([NotNull] Array array, long frames)
        {
            if (array == null || array.Length < Format.Channels)
                throw new ArgumentOutOfRangeException(nameof(array));

            if (frames <= 0)
                throw new ArgumentOutOfRangeException(nameof(frames));
        }

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_readf_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_short(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] short[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_int(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] int[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_float(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] float[] buffer,
            long frames
        );

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe long sf_writef_double(
            SndFile__* sndFile,
            [MarshalAs(UnmanagedType.LPArray)] double[] buffer,
            long frames
        );

        [PublicAPI]
        public unsafe long ReadFrames([NotNull] short[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_short(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long ReadFrames([NotNull] int[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_int(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long ReadFrames([NotNull] float[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_float(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long ReadFrames([NotNull] double[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_readf_double(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long WriteFrames([NotNull] short[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_short(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long WriteFrames([NotNull] int[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_int(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long WriteFrames([NotNull] float[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_float(Handle, buffer, frames);
        }

        [PublicAPI]
        public unsafe long WriteFrames([NotNull] double[] buffer, long frames)
        {
            CheckReadWriteFramesParameters(buffer, frames);
            return sf_writef_double(Handle, buffer, frames);
        }

        #endregion

        #region Other

        [DllImport(NativeLib.Libsndfile, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe void sf_write_sync(
            SndFile__* sndFile
        );

        [PublicAPI]
        public unsafe void WriteSync()
        {
            sf_write_sync(Handle);
        }

        #endregion
    }
}