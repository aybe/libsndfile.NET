using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public struct SfVirtual
    {
        [NotNull]
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SfVirtualLength Length;

        [NotNull]
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SfVirtualSeek Seek;

        [NotNull]
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SfVirtualRead Read;

        [NotNull]
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SfVirtualWrite Write;

        [NotNull]
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public readonly SfVirtualTell Tell;

        public SfVirtual(
            [NotNull] SfVirtualLength length,
            [NotNull] SfVirtualSeek seek,
            [NotNull] SfVirtualRead read,
            [NotNull] SfVirtualWrite write,
            [NotNull] SfVirtualTell tell)
        {
            Length = length ?? throw new ArgumentNullException(nameof(length));
            Seek = seek ?? throw new ArgumentNullException(nameof(seek));
            Read = read ?? throw new ArgumentNullException(nameof(read));
            Write = write ?? throw new ArgumentNullException(nameof(write));
            Tell = tell ?? throw new ArgumentNullException(nameof(tell));
        }

        public static SfVirtual Empty { get; }

        #region Equality members

        public bool Equals(SfVirtual other)
        {
            return Length.Equals(other.Length) && Seek.Equals(other.Seek) && Read.Equals(other.Read) &&
                   Write.Equals(other.Write) && Tell.Equals(other.Tell);
        }

        public override bool Equals(object obj)
        {
            return !(obj is null) && obj is SfVirtual @virtual && Equals(@virtual);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Length.GetHashCode();
                hashCode = (hashCode * 397) ^ Seek.GetHashCode();
                hashCode = (hashCode * 397) ^ Read.GetHashCode();
                hashCode = (hashCode * 397) ^ Write.GetHashCode();
                hashCode = (hashCode * 397) ^ Tell.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(SfVirtual left, SfVirtual right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SfVirtual left, SfVirtual right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}