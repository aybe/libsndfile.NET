using System;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using libsndfile.NET;

namespace Examples
{
    /// <summary>
    ///     <para>
    ///         This is an example of wrapping a stream for virtual system usage.
    ///     </para>
    ///     <para>
    ///         Here, things are obvious because we own the Stream and no one else uses it.
    ///         If you were to pass a stream SafeFileHandle as user data in your callbacks,
    ///         then instantiate a new stream from that pointer, sooner or later you will
    ///         experience weird behavior where, say, X bytes were read but position advanced by Y.
    ///     </para>
    ///     <para>
    ///         This is because of the following issue: 'Detection of Stream Position Changes' in
    ///         https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=netframework-4.7.1#Remarks
    ///     </para>
    /// </summary>
    public sealed class SfVirtualStreamHelper : IDisposable
    {
        public SfVirtualStreamHelper([NotNull] Stream stream, bool disposeStream = true)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            DisposeStream = disposeStream;
            Virtual = new SfVirtual(Length, Seek, Read, Write, Tell);
        }

        private bool Disposed { get; set; }

        private bool DisposeStream { get; }

        [NotNull]
        private Stream Stream { get; }

        [PublicAPI]
        public SfVirtual Virtual { get; }

        public void Dispose()
        {
            if (Disposed)
                return;

            if (DisposeStream)
                Stream.Dispose();

            Disposed = true;
        }

        private long Length(IntPtr userData)
        {
            return Stream.Length;
        }

        private long Seek(long offset, SfSeek seek, IntPtr userData)
        {
            return Stream.Seek(offset, seek.ToSeekOrigin());
        }

        private long Read(IntPtr ptr, long count, IntPtr userData)
        {
            var buffer = new byte[count];
            var read = Stream.Read(buffer, 0, buffer.Length);
            Marshal.Copy(buffer, 0, ptr, read);
            return read;
        }

        private long Write(IntPtr ptr, long count, IntPtr userData)
        {
            var buffer = new byte[count];
            Marshal.Copy(ptr, buffer, 0, buffer.Length);
            Stream.Write(buffer, 0, buffer.Length);
            return count;
        }

        private long Tell(IntPtr userData)
        {
            return Stream.Position;
        }
    }
}