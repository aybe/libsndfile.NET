namespace libsndfile.NET
{
    internal static class NativeLib
    {
#if MACOS
        internal const string Libsndfile = "libsndfile.dylib";
#elif LINUX
    #error Untested Platform
        internal const string Libsndfile = "libsndfile.so.1";
#elif WINDOWS
        internal const string Libsndfile = "libsndfile-1";
#else
    #error Unsupported Platform
        internal const string Libsndfile = "libsndfile.so.1";
#endif
    }
}