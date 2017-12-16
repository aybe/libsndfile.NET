using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SfCartInfo
    {
        public const int VersionSize = 4;
        public const int TitleSize = 64;
        public const int ArtistSize = 64;
        public const int CutIdSize = 64;
        public const int ClientIdSize = 64;
        public const int CategorySize = 64;
        public const int ClassificationSize = 64;
        public const int OutCueSize = 64;
        public const int StartDateSize = 10;
        public const int StartTimeSize = 8;
        public const int EndDateSize = 10;
        public const int EndTimeSize = 8;
        public const int ProducerAppIdSize = 64;
        public const int ProducerAppVersionSize = 64;
        public const int UserDefSize = 64;
        public const int PostTimersSize = 8;
        public const int ReservedSize = 276;
        public const int UrlSize = 1024;
        public const int TagTextSizeDefault = 256;

        public static SfCartInfo Empty { get; } = new SfCartInfo {PostTimers = new SfCartTimer[PostTimersSize]};

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VersionSize)]
        public string Version;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TitleSize)]
        public string Title;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ArtistSize)]
        public string Artist;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CutIdSize)]
        public string CutId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ClientIdSize)]
        public string ClientId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CategorySize)]
        public string Category;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ClassificationSize)]
        public string Classification;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = OutCueSize)]
        public string OutCue;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = StartDateSize)]
        public string StartDate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = StartTimeSize)]
        public string StartTime;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EndDateSize)]
        public string EndDate;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = EndTimeSize)]
        public string EndTime;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ProducerAppIdSize)]
        public string ProducerAppId;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ProducerAppVersionSize)]
        public string ProducerAppVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UserDefSize)]
        public string UserDef;

        public int LevelReference;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = PostTimersSize, ArraySubType = UnmanagedType.Struct)]
        public SfCartTimer[] PostTimers;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ReservedSize)]
        public string Reserved;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = UrlSize)]
        public string Url;

        public uint TagTextSize;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TagTextSizeDefault)]
        public string TagText;
    }
}