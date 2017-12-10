using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public enum SfError
    {
        NoError = 0,
        UnrecognisedFormat = 1,
        System = 2,
        MalformedFile = 3,
        UnsupportedEncoding = 4
    }
}