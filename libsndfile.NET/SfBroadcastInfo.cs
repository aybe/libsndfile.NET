using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SfBroadcastInfo
    {
        public const int DescriptionSize = 256;
        public const int OriginatorSize = 32;
        public const int OriginatorReferenceSize = 32;
        public const int OriginationDateSize = 10;
        public const int OriginationTimeSize = 8;
        public const int UmidSize = 64;
        public const int ReservedSize = 190;
        public const int CodingHistorySizeDefault = 256;

        public static SfBroadcastInfo Empty { get; }

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DescriptionSize)]
        public readonly string Description;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OriginatorSize)]
        public readonly string Originator;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OriginatorReferenceSize)]
        public readonly string OriginatorReference;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OriginationDateSize)]
        public readonly string OriginationDate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OriginationTimeSize)]
        public readonly string OriginationTime;

        public readonly uint TimeReferenceLow;

        public readonly uint TimeReferenceHigh;

        public readonly short Version;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UmidSize)]
        public readonly string Umid;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ReservedSize)]
        public readonly string Reserved;

        public readonly uint CodingHistorySize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CodingHistorySizeDefault)]
        public readonly string CodingHistory;
    }
}